import Fastify, { type FastifyInstance } from 'fastify';
import { registerRoutes } from './routes/index.js';

export async function createServer(): Promise<FastifyInstance> {
  const fastify = Fastify({ 
    logger: true 
  });

  await registerRoutes(fastify);  
  return fastify;
}

export async function startServer() {
  const fastify = await createServer();
  
  try {
    await fastify.listen({ port: 3000, host: '0.0.0.0' });
    console.log('Server working on http://localhost:3000');
  } catch (err) {
    fastify.log.error(err);
    process.exit(1);
  }
}