import { inject, injectable } from "tsyringe";
import type { GetHeroByPublicIdRequest } from "../domain/behavior/service/dto/GetHeroeByPublicIdRequest.js";
import type { GetHeroByPublicIdResponse } from "../domain/behavior/service/dto/GetHeroeByPublicIdResponse.js";
import type { IHeroService } from "../domain/behavior/service/hero-service.interface.js";
import type { IHeroLookup } from "../domain/behavior/repository/hero-lookup.interface.js";
import type { ListHeroesResponse } from "../domain/behavior/service/dto/ListHeroesResponse.js";
import type { ExternalApiLookup } from "../external-service/external-api-lookup.js";
import type { IBaseHeroLookup } from "../domain/behavior/repository/base-hero-lookup.interface.js";

@injectable()
export class HeroService implements IHeroService {
    constructor(@inject("IHeroLookup") private heroLookup: IHeroLookup,
                @inject("IBaseHeroLookup") private baseHeroLookup: IBaseHeroLookup,
                @inject("IExternalApiLookup") private externalApiLookup: ExternalApiLookup) { }
    
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
                }

            return response;
        } catch (error) {
            console.error('Error creating base heroes:', error);
            throw error;
        }
    }
}