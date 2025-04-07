using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using SuperHero.Domain.Model.BaseModel;
using System.Text.Json.Serialization;

namespace SuperHero.Domain.Model.CustomModel
{
    public class CompleteHero : IGuidId
    {
        [JsonPropertyName("powerstats")]
        public Powerstats Powerstats { get; set; }

        [JsonPropertyName("biography")]
        public Biography Biography { get; set; }

        [JsonPropertyName("appearance")]
        public Appearance Appearance { get; set; }

        [JsonPropertyName("work")]
        public Work Work { get; set; }

        [JsonPropertyName("connections")]
        public Connections Connections { get; set; }

        [JsonPropertyName("image")]
        public Image Image { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [BsonId]
        [JsonPropertyName("public_id")]
        public string PublicId { get; set; }

    }
}
