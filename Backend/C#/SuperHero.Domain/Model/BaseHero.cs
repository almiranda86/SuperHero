using SuperHero.Domain.Model.BaseModel;
using System.Text.Json.Serialization;

namespace SuperHero.Domain.Model
{
    public record BaseHero : IGuidId
    {
        [JsonPropertyName("public_id")]
        public string PublicId { get; set; }

        [JsonIgnore]
        public int PrivateId { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        public BaseHero(int privateId, string name)
        {
            PublicId = Guid.NewGuid().ToString();
            PrivateId = privateId;
            Name = name;
        }
    }
}
