import { injectable } from "tsyringe";
import type { IBaseHeroPersister } from "../../domain/behavior/repository/baase-hero-persister.interface.js";
import type { BaseHero } from "../../domain/entities/base/base-hero.js";

@injectable()
export class BaseHeroPersister implements IBaseHeroPersister {
    async createBaseHero(baseHeroCollection: BaseHero[]): Promise<boolean> {
        // Implementação da persistência dos BaseHeroes
        return true;
    }
}