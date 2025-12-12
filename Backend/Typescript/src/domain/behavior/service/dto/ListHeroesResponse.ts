import type { BaseHero } from "@prisma/client";

export interface ListHeroesResponse 
{
        Heroes: BaseHero[];
}