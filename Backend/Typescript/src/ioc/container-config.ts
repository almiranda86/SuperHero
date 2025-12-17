import { container } from "tsyringe";
import { BaseHeroService } from "../services/base-hero.service.js";
import { BaseHeroPersister } from "../repository/persister/base-hero.persister.js";
import SetupDBService from "../services/configuration/setup-database.js";
import { PrismaClient } from "@prisma/client";
import { HeroLookup } from "../repository/lookup/hero-lookup.js";
import { HeroService } from "../services/hero.service.js";
import { BaseHeroLookup } from "../repository/lookup/base-hero.lookup.js";
import { ExternalApiLookup } from "../external-service/external-api-lookup.js";
import { env } from "../env.js";

export function addEnvironmentsVariables(): void {
    container.register('HeroApiToken', {
        useValue: env.HERO_API_TOKEN
    });

    container.register('HeroApiUrl', {
        useValue: env.HERO_API_URL
    });
}

export function addServices(): void {
    container.register("IInitializeDbService", { useClass: SetupDBService });
    container.register("IBaseHeroService", { useClass: BaseHeroService });
    container.register("IHeroService", { useClass: HeroService });
}

export function addRepository(): void {
    configurePrisma();

    container.register("IBaseHeroPersister", { useClass: BaseHeroPersister });
    container.register("IBaseHeroLookup", { useClass: BaseHeroLookup });
    container.register("IExternalApiLookup", { useClass: ExternalApiLookup });
    container.register("IHeroLookup", { useClass: HeroLookup });
}

function configurePrisma() {
    const prisma = new PrismaClient({
        log: ['query', 'info', 'warn', 'error'],
    });

    container.register("PrismaClient", {
        useValue: prisma
    });
}

