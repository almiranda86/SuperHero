import type { GetHeroByPublicIdRequest } from "./dto/GetHeroeByPublicIdRequest.js";
import type { GetHeroByPublicIdResponse } from "./dto/GetHeroeByPublicIdResponse.js";
import type { ListHeroesResponse } from "./dto/ListHeroesResponse.js";

export interface IHeroService {
    getHeroByPublicId(request: GetHeroByPublicIdRequest ): Promise<GetHeroByPublicIdResponse>;
    listAllHeroes(): Promise<ListHeroesResponse>;
}
