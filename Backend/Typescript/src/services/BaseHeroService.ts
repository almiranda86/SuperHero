import { inject, injectable } from "tsyringe";
import type { IBaseHeroService } from "../domain/behavior/service/base-hero-service.interface.js";
import type { BaseHero } from "../domain/entities/base/base-hero.js";
import type { IBaseHeroPersister } from "../domain/behavior/repository/baase-hero-persister.interface.js";

@injectable()
export class BaseHeroService implements IBaseHeroService {
    constructor(@inject("IBaseHeroPersister") private baseHeroPersister: IBaseHeroPersister) { }

    async createBaseHero(baseHeroCollection: BaseHero[]): Promise<void> {
        try {
            await this.baseHeroPersister.createBaseHero(baseHeroCollection);
        } catch (error) {
            console.error('Error creating base heroes:', error);
            throw error;
        }
    }
}