import { injectable } from "tsyringe";
import type { IBaseHeroService } from "../domain/behavior/service/base-hero-service.interface.js";
import type { BaseHero } from "../domain/entities/base/base-hero.js";

@injectable()
export class BaseHeroService implements IBaseHeroService {
    createBaseHero(BaseHeroCollection: BaseHero[]): Promise<void> {
        throw new Error("Method not implemented.");
    }
}