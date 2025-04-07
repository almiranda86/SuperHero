using SuperHero.API.Configuration;
using SuperHero.IoC.Configurations;

try
{
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    builder.Services.AddCorsForLocalhost();
    builder.Services.AddBearerDefinition(builder.Configuration);
    builder.Services.AddSwaggerGenInfo();
    builder.Services.AddServices();
    builder.Services.AddRepositories();
    builder.Services.AddDbContext();
    builder.Services.AddGlobalExceptionMiddleware();
    builder.Services.AddHandlers();
    builder.Services.AddMongoDB(builder.Configuration);
    builder.Services.AddRedisCache(builder.Configuration);
    builder.Services.AddHeroAPI(builder.Configuration);
    builder.Services.AddRabbitMq(builder.Configuration);
    builder.Services.AddBackroundServices();
    builder.Services.AddRabbitConsumerResolver();
    builder.Services.AddRabbitConsumerStrategyResolver();

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();

    var app = builder.Build();

    app.UseGlobalExceptionMiddleware();

    // Configure the HTTP request pipeline.

    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseCorsForLocalhost();

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Services.DoSetup();

    app.Services.SetHanlerProvider();

    app.Run();
}
catch (Exception ex)
{

}

