import type { BaseHero } from "../../entities/base/base-hero.js";
import type { CompleteHero } from "../../entities/custom/complete-hero.js";

export interface IHeroLookup
{
    getHeroByPublicId(publicId: string ): Promise<CompleteHero>;
    listAllHeroes(): Promise<BaseHero[]>;
}