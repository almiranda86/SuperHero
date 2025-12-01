import { readFile } from 'fs/promises';
import { BaseHero } from '../../domain/entities/base/base-hero.js';

export async function readResourceTextFile(resourceFilePath:string): Promise<string|undefined> {
    try {
        const fileContent = await readFile(resourceFilePath, 'utf-8');
        return fileContent;
    
    } catch (error) {
        console.error('Some problem occurred while reading the file:', error);
    }
} 

export async function generateHeroesFromResourceContent(resourceFileContent:string): Promise<BaseHero[]|undefined> {
    try {
        const heroes: BaseHero[] = resourceFileContent
        .split('\n')
        .map(line => line.trim())
        .filter(line => line.length > 0)
        .map(line => {
            const [id, name] = line.split('\t');
            return new BaseHero(parseInt(id!), name!);
        });
        return heroes;
    } catch (error) {
        console.error('Error generating heroes from resource content:', error);
    }
}


