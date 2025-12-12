import { inject, injectable } from "tsyringe";
import type { GetHeroByPublicIdRequest } from "../domain/behavior/service/dto/GetHeroeByPublicIdRequest.js";
import type { GetHeroByPublicIdResponse } from "../domain/behavior/service/dto/GetHeroeByPublicIdResponse.js";
import type { IHeroService } from "../domain/behavior/service/hero-service.interface.js";
import type { IHeroLookup } from "../domain/behavior/repository/hero-lookup.interface.js";
import type { ListHeroesResponse } from "../domain/behavior/service/dto/ListHeroesResponse.js";

@injectable()
export class HeroService implements IHeroService {
    constructor(@inject("IHeroLookup") private heroLookup: IHeroLookup) { }
    
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

            const completeHero = await this.heroLookup.getHeroByPublicId(publicId);

            const response: GetHeroByPublicIdResponse = { Hero: completeHero };
            return response;
        } catch (error) {
            console.error('Error creating base heroes:', error);
            throw error;
        }
    }
}