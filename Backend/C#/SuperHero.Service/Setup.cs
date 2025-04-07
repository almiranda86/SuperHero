using SuperHero.Domain.Behavior;
using SuperHero.Domain.Behavior.Service;
using SuperHero.Domain.Model;
using SuperHero.Security.Domain.Behavior;
using System.Reflection;
using Constants = SuperHero.Domain.Common.Constants;

namespace SuperHero.Service
{
    public class Setup : IInitializeDbService, IInitializeSecurityService
    {
        private readonly IBaseHeroService _baseHeroService;
        private readonly ISetupSecurityService _setupSecurityService;

        public Setup(IBaseHeroService baseHeroService, ISetupSecurityService setupSecurityService)
        {
            _baseHeroService = baseHeroService;
            _setupSecurityService = setupSecurityService;
        }

        public void InitializeDb()
        {
            try
            {
                const string ResourceTextFilePath = "Resources.heroes.txt";
                const string SuperHeroDomainPath = "SuperHero.Domain";

                var domainAssembly = RetrieveAssemblyResourceByAssemblyName(SuperHeroDomainPath);
                if (domainAssembly is null)
                    throw new DllNotFoundException($"{Constants.DLL_NOT_FOUND}{SuperHeroDomainPath}");

                var resouceFileContent = ReadResourceTextFile(domainAssembly, $"{SuperHeroDomainPath}.{ResourceTextFilePath}");

                if (string.IsNullOrEmpty(resouceFileContent))
                    throw new Exception(Constants.INPUT_SOURCE_NOT_PROVIDED);

                var heroes = GenerateHeroesFromResourceContent(resouceFileContent);

                if (heroes is null)
                    throw new Exception(Constants.INPUT_SOURCE_NOT_PROVIDED);

                _baseHeroService.CreateBaseHero(heroes);
            }
            catch (Exception ex)
            {

            }
        }

        public void InitializeSecurity()
        {
            _setupSecurityService.CreateRoles();
            _setupSecurityService.CreateRootUser();
        }

        private IEnumerable<BaseHero> GenerateHeroesFromResourceContent(string resouceFileContent)
        {
            var newLineDelimiter = new[] { '\r', '\n' };
            var tabDelimiter = '\t';

            var splitedResource = resouceFileContent.Split(newLineDelimiter);

            List<BaseHero> baseHeroCollection = new List<BaseHero>();

            foreach (var resource in splitedResource)
            {
                if (!string.IsNullOrEmpty(resource))
                {
                    var line = resource.Split(tabDelimiter);

                    baseHeroCollection.Add(new BaseHero(Convert.ToInt32(line[0]), line[1].Replace(@"\r", " ")));
                }
            }

            return baseHeroCollection;
        }

        private string ReadResourceTextFile(in Assembly? domainAssembly, string resourceName)
        {
            using Stream? stream = domainAssembly?.GetManifestResourceStream(resourceName);
            using StreamReader sr = new StreamReader(stream);
            string heroTextFileContent = sr.ReadToEnd();

            return heroTextFileContent;
        }

        private Assembly? RetrieveAssemblyResourceByAssemblyName(in string SuperHeroDomainPath)
        {
            return Assembly.Load(SuperHeroDomainPath);
        }
    }
}
