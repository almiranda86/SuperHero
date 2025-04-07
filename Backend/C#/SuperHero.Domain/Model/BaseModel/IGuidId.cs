using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json.Serialization;

namespace SuperHero.Domain.Model.BaseModel
{
    public interface IGuidId
    {
        [JsonPropertyName("public_id")]
        [BsonRepresentation(BsonType.String)]
        public string PublicId { get; set; }
    }
}
