import type { BaseHero } from "../../entities/base/base-hero.js";

export interface IBaseHeroLookup
{
    getHeroByPublicId(publicId: string ): Promise<BaseHero>;
}