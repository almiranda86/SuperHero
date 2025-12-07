import type { FastifyInstance } from 'fastify';
import { heroRoutes } from './heroRoutes.js';

export async function registerRoutes(fastify: FastifyInstance) {
  fastify.register(heroRoutes, { prefix: '/api' });

  fastify.get('/', async (request, reply) => {
    return { hello: 'world' };
  });
}