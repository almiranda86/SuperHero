import type { BaseHero } from "../../entities/base/base-hero.js";

export interface IBaseHeroPersister
{
    createBaseHero(baseHeroCollection: BaseHero[]): Promise<boolean>;
}