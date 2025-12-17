import { injectable } from "tsyringe";
import type { IExternalApiLookup } from "../domain/behavior/repository/external-api-lookup.interface.js";
import type { CompleteHero } from "../domain/entities/custom/complete-hero.js";
import { env } from "../env.js";
import { th } from "zod/locales";

@injectable()
export class ExternalApiLookup implements IExternalApiLookup {
    private readonly apiUrl: string;
    private readonly apiToken: string;
    private url: string;

    constructor() {
        this.apiUrl = env.HERO_API_URL || '';
        this.apiToken = env.HERO_API_TOKEN || '';
        this.url = `${this.apiUrl}${this.apiToken}`;
    }
    
    async getCompleteHeroById(id: number): Promise<CompleteHero> {
         const urlForInternalId = `${this.url}/${id}`;

         const response = await fetch(urlForInternalId);

         if (!response.ok) {
            throw new Error(`Hero API error: ${response.statusText}`);
        }

         return await response.json() as CompleteHero;
    }
}