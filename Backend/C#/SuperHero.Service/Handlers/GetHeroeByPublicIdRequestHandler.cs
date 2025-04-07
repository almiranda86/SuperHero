using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using SuperHero.Domain.Behavior.Event;
using SuperHero.Domain.Behavior.Repository;
using SuperHero.Domain.Model.CustomModel;
using SuperHero.Infrastructure.Settings;
using SuperHero.Redis.Extension;
using SuperHero.Service.DTO;

namespace SuperHero.Service.Handlers
{
    public class GetHeroeByPublicIdRequestHandler : IRequestHandler<GetHeroeByPublicIdRequest, GetHeroeByPublicIdResponse>
    {
        private readonly IDistributedCache _redisCache;
        private readonly ICompleteHeroLookup _completeHeroLookup;
        private readonly IBaseHeroLookup _baseHeroLookup;
        private readonly IExternalApiLookup _externalApiLookup;
        private readonly IOptions<RabbitMqQueueSettings> _queueSettings;
        private readonly ICompleteHeroProducer _completeHeroProducer;

        public GetHeroeByPublicIdRequestHandler(IDistributedCache redisCache,
                                                ICompleteHeroLookup completeHeroLookup,
                                                IBaseHeroLookup baseHeroLookup,
                                                IExternalApiLookup externalApiLookup,
                                                IOptions<RabbitMqQueueSettings> queueSettings,
                                                ICompleteHeroProducer completeHeroProducer)
        {
            _redisCache = redisCache;
            _completeHeroLookup = completeHeroLookup;
            _baseHeroLookup = baseHeroLookup;
            _externalApiLookup = externalApiLookup;
            _queueSettings = queueSettings;
            _completeHeroProducer = completeHeroProducer;
        }

        public async Task<GetHeroeByPublicIdResponse> Handle(GetHeroeByPublicIdRequest request, CancellationToken cancellationToken)
        {
            GetHeroeByPublicIdResponse response = new GetHeroeByPublicIdResponse();

            var cachedHero = await _redisCache.GetRecordAsync<CompleteHero>(request.PublicId);

            if (cachedHero is null)
            {
                var completeHero = await _completeHeroLookup.GetCompleteHeroByPublicId(request.PublicId);

                if (completeHero is null)
                {
                    var baseHero = await _baseHeroLookup.GetBaseHeroByPublicId(request.PublicId);
                    var externalHero = await _externalApiLookup.GetCompleteHeroById(baseHero.PrivateId);
                    externalHero.PublicId = request.PublicId;

                    response.SetCompleteHero(externalHero);
                    _completeHeroProducer.SendMessage(externalHero);
                    
                }
                else
                {
                    completeHero.PublicId = request.PublicId;
                    response.SetCompleteHero(completeHero);
                    _completeHeroProducer.SendMessage(cachedHero, _queueSettings.Value.Queues[1]);
                }
            }
            else
            {
                cachedHero.PublicId = request.PublicId;
                response.SetCompleteHero(cachedHero);
            }

            return response;
        }
    }
}
