namespace SuperHero.ExternalService.Behavior
{
    public interface IRestService
    {
        Task<string> DoRestCall(string uri, string uriParams);
    }
}
