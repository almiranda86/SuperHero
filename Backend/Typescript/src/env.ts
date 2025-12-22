import { config } from 'dotenv';
import { z } from 'zod';

// Load .env file variables
config();

// Schema definition through Zod
const envSchema = z.object({
    // Hero API
    HERO_API_TOKEN: z.string().min(1, 'HERO_API_TOKEN is required'),
    HERO_API_URL: z.string().url('HERO_API_URL must be a valid URL'),

    // Database
    DATABASE_URL: z.string().min(1, 'DATABASE_URL is required'),

    // Server
    PORT: z.string().default('3000').transform(Number),
    NODE_ENV: z.enum(['development', 'production', 'test']).default('development'),
    LOG_LEVEL: z.enum(['debug', 'info', 'warn', 'error']).default('info'),

    //Redis
    REDIS_HOST: z.string().default('localhost'),
    REDIS_PORT: z.string().default('6379').transform(Number),
    REDIS_PASSWORD: z.string().optional(),
    REDIS_DB: z.string().default('0').transform(Number),

    // MongoDB (optional, for MongoDB connection)
    MONGODB_URI: z.string().optional(),

    // RabbitMQ (optional, for future implementation)
    RABBITMQ_HOST: z.string().optional(),
    RABBITMQ_PORT: z.string().optional().transform(val => val ? Number(val) : undefined),
    RABBITMQ_USER: z.string().optional(),
    RABBITMQ_PASS: z.string().optional(),

    // Mongo Express (optional, for development UI)
    MONGO_EXPRESS_USER: z.string().optional(),
    MONGO_EXPRESS_PASS: z.string().optional(),
});

// Validate and export
const parsedEnv = envSchema.safeParse(process.env);

if (!parsedEnv.success) {
    console.error('Invalid environment variables:');
    console.error(parsedEnv.error.format());
    process.exit(1);
}

export const env = parsedEnv.data;

// Type-safe access
export type Env = z.infer<typeof envSchema>;