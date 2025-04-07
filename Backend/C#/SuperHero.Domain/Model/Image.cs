using SuperHero.Domain.Model.BaseModel;
using System.Text.Json.Serialization;

namespace SuperHero.Domain.Model
{
    public class Image 
    {
        [JsonPropertyName("url")]
        public string URL { get; set; }

    }
}
