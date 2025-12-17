import { inject, injectable } from "tsyringe";
import type { IHeroService } from "../domain/behavior/service/hero-service.interface.js";
import type { FastifyReply, FastifyRequest } from "fastify";
import type { GetHeroByPublicIdRequest } from "../domain/behavior/service/dto/GetHeroeByPublicIdRequest.js";
import type { GetHeroByPublicIdResponse } from "../domain/behavior/service/dto/GetHeroeByPublicIdResponse.js";
import type { ListHeroesResponse } from "../domain/behavior/service/dto/ListHeroesResponse.js";

@injectable()
export class HeroController {
    constructor(
        @inject('IHeroService')
        private readonly heroService: IHeroService
    ) {}

    async getHeroByPublicId(
        request: FastifyRequest<{ Params: GetHeroByPublicIdRequest }>,
        reply: FastifyReply
    ): Promise<GetHeroByPublicIdResponse> {
        console.log('Received request to get hero by publicId:', request.params.publicId);
        const response = await this.heroService.getHeroByPublicId(request.params);

         if (!response) {
            return reply.status(404).send({
                success: false,
                error: 'Hero not found',
                message: `Hero with publicId ${request.params.publicId} not found`
            });
        }

        return reply.status(200).send({
            success: true,
            data: {
                hero: response.Hero
            }
        });
    }

    async listAllHeroes(
        request: FastifyRequest,
        reply: FastifyReply
    ): Promise<ListHeroesResponse> {
        const response = await this.heroService.listAllHeroes();

         if (!response) {
            return reply.status(404).send({
                success: false,
                error: 'No Heroes found',
                message: `No Heroes found`
            });
        }

        return reply.status(200).send({
            success: true,
            data: {
                hero: response.Heroes
            }
        });
    }
}