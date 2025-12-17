import type { CompleteHero } from "../../entities/custom/complete-hero.js";

export interface IExternalApiLookup{
  getCompleteHeroById(id: number): Promise<CompleteHero>;
}