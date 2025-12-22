// src/config/redis.ts
import { Redis, type RedisOptions } from 'ioredis';
import { env } from '../../env.js';


export function createRedisClient(): Redis {
    const options: RedisOptions = {
        host: env.REDIS_HOST,
        port: env.REDIS_PORT,
        password: env.REDIS_PASSWORD,
        db: env.REDIS_DB,
        retryStrategy: (times: number) => {
            const delay = Math.min(times * 50, 2000);
            return delay;
        },
        maxRetriesPerRequest: 3,
        enableReadyCheck: true,
        lazyConnect: false
    };

    const redis = new Redis(options);

    redis.on('connect', () => {
        console.log('Redis connected');
    });

    redis.on('error', (error: Error) => {
        console.error('Redis error:', error);
    });

    redis.on('close', () => {
        console.log('Redis connection closed');
    });

    return redis;
}