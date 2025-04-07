using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SuperHero.API.Extensions;
using SuperHero.API.Filter;
using SuperHero.Service.DTO;

namespace SuperHero.API.Controllers
{
    [ApiController]
    [Route("hero")]
    public class HeroController : ControllerBase
    {
        /// <summary>
        /// List all heroes with pagination
        /// </summary>
        /// <query name="pageNumber">1</query>
        /// <query name="PageSize">10</query>
        /// <param name="cancellationToken"></param>
        [HttpGet("list_all_heroes_paginated")]
        [Produces(typeof(ListHeroesResponse))]
        public Task<IActionResult> ListAllHeroesPaginated([FromQuery] PaginationFilter paginationFilter, CancellationToken cancellationToken = default)
        {
            ListHeroesRequest request = new ListHeroesRequest()
            {
                CurrentPage = paginationFilter.PageNumber,
                PageSize = paginationFilter.PageSize
            };

            return this.HandleQueryRequest<ListHeroesRequest, ListHeroesResponse>(request, cancellationToken);
        }

        /// <summary>
        /// Get one specific hero by its public identifier
        /// </summary>
        /// <param name="publicid">GUID Value</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("get_hero_by_publicid/{publicid}")]
        [Produces(typeof(GetHeroeByPublicIdResponse))]
        public Task<IActionResult> GetHeroByGuid([FromRoute] string publicid, CancellationToken cancellationToken = default)
        {
            GetHeroeByPublicIdRequest request = new(publicid);

            return this.HandleQueryRequest<GetHeroeByPublicIdRequest, GetHeroeByPublicIdResponse>(request, cancellationToken);
        }
    }
}
