import type { FastifyInstance } from 'fastify';
import { HeroController } from '../controllers/heroController.js';

export async function heroRoutes(fastify: FastifyInstance) {
  const controller = new HeroController();
  
  // fastify.get('/users', controller.getAll.bind(controller));
  // fastify.get('/users/:id', controller.getById.bind(controller));
}