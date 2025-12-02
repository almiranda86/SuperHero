import { container } from "tsyringe";
import { BaseHeroService } from "../services/BaseHeroService.js";
import { BaseHeroPersister } from "../repository/persister/BaseHeroPersister.js";
import SetupDBService from "../services/configuration/setup-database.js";



export function addServices(): void {
    container.register("IInitializeDbService", { useClass: SetupDBService });
    container.register("IBaseHeroService", { useClass: BaseHeroService });
}

export function addRepository(): void {
    container.register("IBaseHeroPersister", { useClass: BaseHeroPersister });
}




