using SuperHero.Domain.Model.BaseModel;
using System.Text.Json.Serialization;

namespace SuperHero.Domain.Model
{
    public class Connections
    {

        [JsonPropertyName("group-affiliation")]
        public string GroupAffiliation { get; set; }

        [JsonPropertyName("relatives")]
        public string Relatives { get; set; }
    }
}
