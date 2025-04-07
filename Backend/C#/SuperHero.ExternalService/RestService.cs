using RestSharp;
using SuperHero.ExternalService.Behavior;

namespace SuperHero.ExternalService
{
    public class RestService : IRestService
    {
        public async Task<string> DoRestCall(string uri, string uriParams)
        {
            var fullPath = $"{uri}/{uriParams}";

            var client = new RestClient(fullPath);
            var RSClient = new RestRequest() { RequestFormat = DataFormat.Json };

            var restResponse = await client.ExecuteAsync(RSClient);

            if (restResponse.StatusCode == System.Net.HttpStatusCode.OK)
                return restResponse.Content;

            return string.Empty;
        }
    }
}
