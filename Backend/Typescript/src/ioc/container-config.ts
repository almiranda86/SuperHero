import { container } from "tsyringe";
import { BaseHeroService } from "../services/base-hero.service.js";
import { BaseHeroPersister } from "../repository/persister/base-hero.persister.js";
import SetupDBService from "../services/configuration/setup-database.js";
import { PrismaClient } from "@prisma/client";

export function addServices(): void {
    container.register("IInitializeDbService", { useClass: SetupDBService });
    container.register("IBaseHeroService", { useClass: BaseHeroService });
}

export function addRepository(): void {
    configurePrisma();

    container.register("IBaseHeroPersister", { useClass: BaseHeroPersister });
}

function configurePrisma(){
    const prisma = new PrismaClient({
        log: ['query', 'info', 'warn', 'error'],
    });

    container.register("PrismaClient", {
        useValue: prisma
    });
}

