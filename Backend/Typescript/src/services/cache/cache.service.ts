import { inject, injectable } from "tsyringe";
import type { ICacheService } from "../../domain/behavior/service/cache/cache-service.interface.js";
import type { Redis as RedisClient } from 'ioredis';

@injectable()
export class CacheService implements ICacheService {
    constructor(
        @inject('RedisClient') private readonly redis: RedisClient
    ) {}

    async get<T>(key: string): Promise<T | null> {
        const value = await this.redis.get(key);    
        console.log(`CacheService.get: key=${key}, value=${value}`);
        if (!value) {
            return null;
        }

        try {
            return JSON.parse(value) as T;
        } catch {
            return value as T;
        }
    }
    
    async set<T>(key: string, value: T, ttl: number): Promise<void> {
        const serialized = typeof value === 'string' 
            ? value 
            : JSON.stringify(value);
        console.log(`CacheService.set: key=${key}, value=${serialized}, ttl=${ttl}`);
        await this.redis.set(key, serialized, 'EX', ttl);
    }

    async delete(key: string): Promise<void> {
        await this.redis.del(key);
    }

    async deleteByPattern(pattern: string): Promise<void> {
                const keys = await this.redis.keys(pattern);
        
        if (keys.length > 0) {
            await this.redis.del(...keys);
        }
    }

    async exists(key: string): Promise<boolean> {
               const result = await this.redis.exists(key);
        return result === 1;
    }

    async getTTL(key: string): Promise<number> {
         return await this.redis.ttl(key);
    }
}