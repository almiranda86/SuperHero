using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SuperHero.Domain.Behavior.Repository;
using SuperHero.Domain.Model.CustomModel;
using SuperHero.ExternalService.Behavior;
using SuperHero.ExternalService.Settings;

namespace SuperHero.ExternalService.Lookup
{
    public class ExternalApiLookup : IExternalApiLookup
    {
        private readonly IRestService _restService;
        IOptions<HeroApiSettings> _heroApiSettings;

        public ExternalApiLookup(IRestService restService,
                                 IOptions<HeroApiSettings> heroApiSettings)
        {
            _restService = restService; 
            _heroApiSettings = heroApiSettings;
        }

        public async Task<CompleteHero> GetCompleteHeroById(int heroId)
        {
            var restResponse = await _restService.DoRestCall($"{_heroApiSettings.Value.ApiURL}{_heroApiSettings.Value.ApiToken}", heroId.ToString());

            var apiResponseModel = JsonConvert.DeserializeObject<CompleteHero>(restResponse);

            return apiResponseModel;
        }
    }
}
