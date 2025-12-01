import type { BaseHero } from "../../domain/entities/base/base-hero.js";
import {readResourceTextFile, generateHeroesFromResourceContent } from "../helper/serviceHelper.js";

export default async function initializeDb(){
    try {
        const resourceTextFilePath: string = '../../domain/resources/heroes.txt';

        const resourceFileContent: string|undefined = await readResourceTextFile(resourceTextFilePath);
        
        if(!resourceFileContent){
            throw new Error('Resource file content is empty or undefined');
        }

        var heroes: BaseHero[] = await generateHeroesFromResourceContent(resourceFileContent);

        console.log('Initializing database connection...');
        // Database connection logic here
    } catch (error) {
        console.error('Error initializing database:', error);
        throw error;
    }
}