import { inject, injectable } from "tsyringe";
import type { GetHeroByPublicIdRequest } from "../domain/behavior/service/dto/GetHeroeByPublicIdRequest.js";
import type { GetHeroByPublicIdResponse } from "../domain/behavior/service/dto/GetHeroeByPublicIdResponse.js";
import type { IHeroService } from "../domain/behavior/service/hero-service.interface.js";
import type { IHeroLookup } from "../domain/behavior/repository/hero-lookup.interface.js";
import type { ListHeroesResponse } from "../domain/behavior/service/dto/ListHeroesResponse.js";
import type { IBaseHeroLookup } from "../domain/behavior/repository/base-hero-lookup.interface.js";
import type { IExternalApiLookup } from "../domain/behavior/repository/external-api-lookup.interface.js";
import type { ICacheService } from "../domain/behavior/service/cache/cache-service.interface.js";
import type { CompleteHero } from "../domain/entities/custom/complete-hero.js";

@injectable()
export class HeroService implements IHeroService {
    constructor(@inject("IHeroLookup") private heroLookup: IHeroLookup,
                @inject("IBaseHeroLookup") private baseHeroLookup: IBaseHeroLookup,
                @inject("IExternalApiLookup") private externalApiLookup: IExternalApiLookup,
                @inject("ICacheService") private cacheService: ICacheService) { }

    async listAllHeroes(): Promise<ListHeroesResponse> {
        try {
            const heroes = await this.heroLookup.listAllHeroes();
            const response: ListHeroesResponse = { Heroes: heroes };
            return response;
        } catch (error) {
            console.error('Error creating base heroes:', error);
            throw error;
        }
    }

    async getHeroByPublicId(request: GetHeroByPublicIdRequest ): Promise<GetHeroByPublicIdResponse> {
        try {
            const { publicId } = request;
             let response: GetHeroByPublicIdResponse;

            var cachedHero = await this.cacheService.get<CompleteHero>(publicId);

            if (cachedHero === null)
            {
                const completeHero = await this.heroLookup.getHeroByPublicId(publicId);

                if (!completeHero)
                {
                    const baseHero = await this.baseHeroLookup.getHeroByPublicId(publicId);
                    var externalHero = await this.externalApiLookup.getCompleteHeroById(baseHero.PrivateId);
                    externalHero.PublicId = publicId;
                    response = { Hero: externalHero };
                }
                else
                {
                    completeHero.PublicId = publicId;
                    response = { Hero: completeHero };
                    //_completeHeroProducer.SendMessage(cachedHero, _queueSettings.Value.Queues[1]);
                }
            }
            else
            {
                cachedHero.PublicId = publicId;
                response = { Hero: cachedHero };
            }

            return response;
        } catch (error) {
            console.error('Error creating base heroes:', error);
            throw error;
        }
    }
}