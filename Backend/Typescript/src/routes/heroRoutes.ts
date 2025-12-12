import type { FastifyInstance, FastifyReply, FastifyRequest } from 'fastify';
import { HeroController } from '../controllers/heroController.js';
import { container } from 'tsyringe';
import type { GetHeroByPublicIdRequest } from '../domain/behavior/service/dto/GetHeroeByPublicIdRequest.js';

export async function heroRoutes(fastify: FastifyInstance) {
  const controller = container.resolve(HeroController);

  /**
   * @route GET /api/heroes/:publicId
   * @desc Get one specific hero by its public identifier
   */
  fastify.get(
    '/hero/get_hero_by_publicid/:publicId',
    {
      handler: async (
        request: FastifyRequest<{ Params: GetHeroByPublicIdRequest }>,
        reply: FastifyReply
      ) => controller.getHeroByPublicId(request, reply)
    }
  );

  /**
   * @route GET /api/heroes
   * @desc Get all heroes
   */
  fastify.get(
    '/hero/list_all_heroes',
    {
      handler: async (request, reply) =>
        controller.listAllHeroes(request, reply)
    }
  );
}