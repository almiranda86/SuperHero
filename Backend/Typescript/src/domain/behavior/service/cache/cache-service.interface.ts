export interface ICacheService {
    get<T>(key: string): Promise<T | null>;
    set<T>(key: string, value: T, ttl: number): Promise<void>
    delete(key: string): Promise<void>;
    deleteByPattern(pattern: string): Promise<void>;
    exists(key: string): Promise<boolean>;
    getTTL(key: string): Promise<number>
}