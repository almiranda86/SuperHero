using System.Text.Json.Serialization;

namespace SuperHero.Domain.Model.BaseModel
{
    public interface IPrivateId
    {
        [JsonPropertyName("id")]
        public string PrivateId { get; set; }
    }
}
