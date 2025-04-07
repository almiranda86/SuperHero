using MediatR;
using SuperHero.Core.Pagination;

namespace SuperHero.Service.DTO
{
    public record ListHeroesRequest : IPagedRequest, IRequest<ListHeroesResponse>
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
    }
}
