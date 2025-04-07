using System.Reflection;

namespace SuperHero.Infrastructure.Extensions
{
    public static class AssemblyExtensions
    {
        public static List<Type> GetTypeAssignableFrom<T>(this Assembly assembly)
        {
            return assembly.GetTypesAssignableFrom(typeof(T));
        }

        public static List<Type> GetTypesAssignableFrom(this Assembly assembly, Type compareType)
        {
            const string SuperHeroRabbitMqConsumer = "SuperHero.RabbitMq.Consumer";

            List<Type> result = new List<Type>();

            var consumerAssembly = assembly.RetrieveAssemblyResourceByAssemblyName(SuperHeroRabbitMqConsumer);

            result.AddRange(consumerAssembly.GetTypes().Where(a => compareType.IsAssignableFrom(a) && !a.IsInterface && !a.IsAbstract));

            return result;
        }

        public static Assembly? RetrieveAssemblyResourceByAssemblyName(this Assembly assembly, in string assemblyPath)
        {
            return Assembly.Load(assemblyPath);
        }
    }
}
