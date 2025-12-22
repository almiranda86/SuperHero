// Script para testar Redis diretamente
import Redis from 'ioredis';

const redis = new Redis({
  host: 'localhost',
  port: 6379,
  password: '',
  db: 0
});

async function testRedis() {
  console.log('🔍 Testando conexão com Redis...\n');

  try {
    // Teste 1: PING
    const pong = await redis.ping();
    console.log('✅ Teste 1 - PING:', pong);

    // Teste 2: SET
    await redis.set('test:hero', JSON.stringify({ name: 'Superman', power: 100 }));
    console.log('✅ Teste 2 - SET: Herói salvo no cache');

    // Teste 3: GET
    const cached = await redis.get('test:hero');
    console.log('✅ Teste 3 - GET:', JSON.parse(cached));

    // Teste 4: TTL
    await redis.set('test:ttl', 'valor temporário', 'EX', 10);
    const ttl = await redis.ttl('test:ttl');
    console.log('✅ Teste 4 - TTL:', ttl, 'segundos');

    // Teste 5: Listar todas as chaves
    const keys = await redis.keys('*');
    console.log('✅ Teste 5 - KEYS:', keys.length, 'chaves encontradas');
    console.log('   Chaves:', keys);

    // Teste 6: INFO
    const info = await redis.info('memory');
    const usedMemory = info.match(/used_memory_human:(.+)/)?.[1];
    console.log('✅ Teste 6 - MEMORY:', usedMemory?.trim());

    // Cleanup
    await redis.del('test:hero', 'test:ttl');
    console.log('\n🧹 Cleanup: Chaves de teste removidas');

    redis.disconnect();
    console.log('\n✅ Todos os testes passaram! Redis está funcionando corretamente.');
  } catch (error) {
    console.error('❌ Erro ao testar Redis:', error.message);
    redis.disconnect();
    process.exit(1);
  }
}

testRedis();
