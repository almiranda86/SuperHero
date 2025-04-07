using MediatR;
using SuperHero.Domain.Behavior.Repository;
using SuperHero.Service.DTO;

namespace SuperHero.Service.Handlers
{
    public class ListAllHeroesPaginatedRequestHandler : IRequestHandler<ListHeroesRequest, ListHeroesResponse>
    {
        private readonly IBaseHeroLookup _baseHeroLookup;

        public ListAllHeroesPaginatedRequestHandler(IBaseHeroLookup baseHeroLookup)
        {
            _baseHeroLookup = baseHeroLookup;
        }

        public async Task<ListHeroesResponse> Handle(ListHeroesRequest request, CancellationToken cancellationToken)
        {
            var (heroesCollection, totalPages) = await _baseHeroLookup.ListAllHeroesPaginated(request.CurrentPage, request.PageSize, cancellationToken);

            ListHeroesResponse responseresponse = new ListHeroesResponse()
            {
                Heroes = heroesCollection,
                PageNumber = request.CurrentPage,
                PageSize = request.PageSize,
                TotalCount = totalPages
            };

            return responseresponse;
        }
    }
}
