import { inject, injectable } from "tsyringe";
import type { IBaseHeroPersister } from "../../domain/behavior/repository/base-hero-persister.interface.js";
import { BaseHero } from "../../domain/entities/base/base-hero.js";
import type { PrismaClient } from "@prisma/client";
import { baseHeroToPrisma } from "../mappers/mapToPrisma.js";

@injectable()
export class BaseHeroPersister implements IBaseHeroPersister {
    constructor(@inject("PrismaClient") private prisma: PrismaClient) { }
    async createBaseHero(baseHeroCollection: BaseHero[]): Promise<boolean> {
        try {
            for (const hero of baseHeroCollection) {
                await this.prisma.baseHero.upsert({
                    where: { privateId: hero.PrivateId! },
                    update: {},
                    create: baseHeroToPrisma(hero),
                });
            }
            console.log('Persisting base heroes to the database...');
            return true;
        } catch (error) {
            console.error('Error persisting base heroes:', error);
            throw error;
        }
    }
}