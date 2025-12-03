import { container } from "tsyringe";
import type { BaseHero } from "../../domain/entities/base/base-hero.js";
import { BaseHeroService } from "../BaseHeroService.js";
import { readResourceTextFile, generateHeroesFromResourceContent } from "../helper/serviceHelper.js";
import type { IInitializeDbService } from "../../domain/behavior/initialize-db-service.interface.js";

export default class SetupDBService implements IInitializeDbService {
    async InitializeDb(): Promise<void> {
        try {
            const baseHeroService = container.resolve(BaseHeroService);
            const resourceTextFilePath: string = '../Typescript/src/domain/resources/heroes.txt';

            const resourceFileContent: string | undefined = await readResourceTextFile(resourceTextFilePath);
            if (!resourceFileContent) {
                throw new Error('Resource file content is empty or undefined');
            }

            const heroes: BaseHero[] = await generateHeroesFromResourceContent(resourceFileContent) ?? [];
            if (!heroes || heroes.length === 0) {
                throw new Error('No heroes were generated from the resource content');
            }
            
            console.log(`Initializing database with ${heroes.length} heroes...`);

            await baseHeroService.createBaseHero(heroes);
        } catch (error) {
            console.error('Error initializing database:', error);
            throw error;
        }
    }
}

