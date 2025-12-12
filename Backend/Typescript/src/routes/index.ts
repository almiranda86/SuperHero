import type { FastifyInstance } from 'fastify';
import { heroRoutes } from './heroRoutes.js';

export async function registerRoutes(fastify: FastifyInstance) {
  fastify.register(heroRoutes, { prefix: '/api' });

  // Health check
  fastify.get('/health', async (request, reply) => {
    return { status: 'ok', timestamp: new Date().toISOString() };
  });

  fastify.get('/', async (request, reply) => {
    return { hello: 'world' };
  });
}