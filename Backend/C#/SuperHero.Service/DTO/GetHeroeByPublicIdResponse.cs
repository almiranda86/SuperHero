using SuperHero.Core.Service;
using SuperHero.Domain.Model.CustomModel;
using System.Text.Json.Serialization;

namespace SuperHero.Service.DTO
{
    public class GetHeroeByPublicIdResponse : ServiceResponse
    {
        [JsonPropertyName("hero")]

        public CompleteHero Hero { get; set; }

        public GetHeroeByPublicIdResponse()
        {
            Hero = new CompleteHero();
        }

        public void SetCompleteHero(CompleteHero hero)
        {
            Hero = hero;
        }
    }
}
