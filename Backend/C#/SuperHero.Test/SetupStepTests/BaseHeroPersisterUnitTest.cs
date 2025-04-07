using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.AutoMock;
using SuperHero.Core.Pagination;
using SuperHero.Domain.Model;
using SuperHero.Repository.Behavior;
using SuperHero.Repository.Context;
using SuperHero.Repository.Persister;
using SuperHero.UnitTest.Core;

namespace SuperHero.UnitTest.SetupStepTests
{
    public class BaseHeroPersisterUnitTest : TestBase
    {
        public BaseHeroPersisterUnitTest()
        {
            _mocker = new AutoMocker();
        }

        [Fact]
        public async Task CreateBaseHero_Success()
        {
            //Arrange
            IEnumerable<BaseHero> listHeroes = new List<BaseHero>();
            listHeroes = listHeroes.Append(new BaseHero(1, "TesteHero1") { PublicId = Guid.NewGuid().ToString() });
            listHeroes = listHeroes.Append(new BaseHero(2, "TesteHero2") { PublicId = Guid.NewGuid().ToString() });
            listHeroes = listHeroes.Append(new BaseHero(3, "TesteHero3") { PublicId = Guid.NewGuid().ToString() });

            var mockSet = new Mock<DbSet<BaseHero>>();

            var dbOption = new DbContextOptions<HeroContext>();
            var mockDbContext = new Mock<HeroContext>(dbOption);
            var instance = new BaseHeroPersister(mockDbContext.Object);

            mockDbContext.Setup(x => x.AddRangeAsync(It.IsAny<IEnumerable<BaseHero>>(), default)).Verifiable(); ;

            mockSet.Setup(x => x.AddRangeAsync(It.IsAny<IEnumerable<BaseHero>>(), It.IsAny<CancellationToken>())).Verifiable(); ;

            //Act
            var result = await instance.CreateBaseHero(listHeroes);


            //Assert
            Assert.IsType<bool>(result);
            mockDbContext.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}