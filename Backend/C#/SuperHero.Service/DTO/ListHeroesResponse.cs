using SuperHero.Core.Pagination;
using SuperHero.Core.Service;
using SuperHero.Domain.Model;
using System.Text.Json.Serialization;

namespace SuperHero.Service.DTO
{
    public class ListHeroesResponse : ServiceResponse, IPagedResponse
    {
        [JsonPropertyName("heroes")]
        public IEnumerable<BaseHero> Heroes { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }

        public ListHeroesResponse()
        {
            Heroes = new List<BaseHero>();
        }
    }
}
