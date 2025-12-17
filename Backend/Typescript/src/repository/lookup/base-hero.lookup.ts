import { inject, injectable } from "tsyringe";
import type { IBaseHeroLookup } from "../../domain/behavior/repository/base-hero-lookup.interface.js";
import type { PrismaClient } from "@prisma/client";
import { BaseHero } from "../../domain/entities/base/base-hero.js";

@injectable()
export class BaseHeroLookup implements IBaseHeroLookup {
    constructor(@inject("PrismaClient") private prisma: PrismaClient) { }

    async getHeroByPublicId(publicId: string): Promise<BaseHero> {
        try {
            const hero = await this.prisma.baseHero.findUnique({
                where: { publicId }
            });
            if (!hero) {
                throw new Error('Hero not found');
            }
            const baseHero = new BaseHero(hero.privateId, hero.name);
            baseHero.publicId = hero.publicId;
            return baseHero;
        } catch (error) {
            console.error('[BaseHeroLookup] Error retrieving base hero by publicId:', error);
            throw new Error('Failed to retrieve hero from database');
        }
    }
}