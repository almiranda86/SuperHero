using SuperHero.Domain.Model.BaseModel;
using System.Text.Json.Serialization;

namespace SuperHero.Domain.Model
{
    public class Work 
    {
        [JsonPropertyName("occupation")]
        public string Occupation { get; set; }

        [JsonPropertyName("base")]
        public string BaseOfOperation { get; set; }
    }
}
