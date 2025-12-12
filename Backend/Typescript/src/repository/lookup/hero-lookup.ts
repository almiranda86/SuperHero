import { inject, injectable } from "tsyringe";
import type { IHeroLookup } from "../../domain/behavior/repository/hero-lookup.interface.js";
import type { CompleteHero } from "../../domain/entities/custom/complete-hero.js";
import { BaseHero } from "../../domain/entities/base/base-hero.js";
import type { PrismaClient } from "../../../generated/prisma/internal/class.js";

@injectable()
export class HeroLookup implements IHeroLookup {
    constructor(@inject("PrismaClient") private prisma: PrismaClient) { }
    
    async listAllHeroes(): Promise<BaseHero[]> {
        try {
            const heroes = await this.prisma.baseHero.findMany({
                orderBy: { privateId: 'asc' }
            });
            
            return heroes.map((h: { privateId: number; name: string; publicId: string; }) => {
                const hero = new BaseHero(h.privateId, h.name);
                hero.publicId = h.publicId;
                return hero;
            });
        } catch (error) {
            console.error('[HeroLookup] Error retrieving base heroes:', error);
            throw new Error('Failed to retrieve heroes from database');
        }
    }

    async getHeroByPublicId(publicId: string ): Promise<CompleteHero> {
        // Implementation to retrieve a CompleteHero by publicId
        throw new Error("Method not implemented.");
    }
}