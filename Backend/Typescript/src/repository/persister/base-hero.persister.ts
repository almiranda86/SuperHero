import { inject, injectable } from "tsyringe";
import type { IBaseHeroPersister } from "../../domain/behavior/repository/base-hero-persister.interface.js";
import { BaseHero } from "../../domain/entities/base/base-hero.js";
import type { PrismaClient } from "@prisma/client";

@injectable()
export class BaseHeroPersister implements IBaseHeroPersister {
    constructor(@inject("PrismaClient") private prisma: PrismaClient) { }
    async createBaseHero(baseHeroCollection: BaseHero[]): Promise<boolean> {
        try {
            await this.prisma.baseHero.createMany({
                data: baseHeroCollection.map(hero => ({
                    publicId: hero.publicId!,
                    privateId: hero.PrivateId!,
                    name: hero.Name!
                }))
            });
            console.log('Persisting base heroes to the database...');
            return true;
        } catch (error) {
            console.error('Error persisting base heroes:', error);
            throw error;
        }
    }

    async findAll(): Promise<BaseHero[]> {
        const heroes = await this.prisma.hero.findMany();
        
        return heroes.map((h: { privateId: number; name: string; publicId: string | undefined; }) => {
            const hero = new BaseHero(h.privateId, h.name);
            hero.publicId = h.publicId;
            return hero;
        });
    }
}