import type { BaseHero } from "../../entities/base/base-hero.js";

export interface IBaseHeroService {
    createBaseHero(BaseHeroCollection :BaseHero[]): Promise<void>;
}
