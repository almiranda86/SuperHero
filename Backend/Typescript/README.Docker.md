# 🐳 Docker Setup - SuperHero TypeScript API

## 📋 Pré-requisitos

- Docker Desktop instalado e rodando
- Docker Compose v2+
- 4GB RAM disponível (mínimo)

---

## 🚀 Quick Start

### 1. **Desenvolvimento Local (Apenas Serviços)**

Se você já tem Node.js instalado e quer rodar apenas os serviços (Redis, MongoDB, RabbitMQ):

```bash
# Subir apenas os serviços
docker-compose up redis mongo rabbitmq -d

# Rodar a aplicação localmente
npm run dev
```

### 2. **Desenvolvimento Completo (Tudo no Docker)**

Para rodar TUDO no Docker com hot-reload:

```bash
# Subir todos os serviços + API
docker-compose -f docker-compose.dev.yml up

# Ou em background
docker-compose -f docker-compose.dev.yml up -d

# Ver logs
docker-compose -f docker-compose.dev.yml logs -f superhero-api-dev
```

### 3. **Produção**

Para build e execução em modo produção:

```bash
# Build e subir
docker-compose up --build -d

# Ver logs
docker-compose logs -f superhero-api

# Parar tudo
docker-compose down
```

---

## 📦 Serviços Disponíveis

| Serviço | Porta | Descrição | Credenciais |
|---------|-------|-----------|-------------|
| **SuperHero API** | 3000 | API TypeScript | - |
| **Redis** | 6379 | Cache | Sem senha |
| **MongoDB** | 27017 | Database | root / MongoDB00 |
| **Mongo Express** | 8081 | MongoDB UI | admin / admin123 |
| **RabbitMQ** | 5672 | Message Broker | root / RabMq123 |
| **RabbitMQ Management** | 15672 | RabbitMQ UI | root / RabMq123 |

---

## 🔧 Comandos Úteis

### Gerenciamento de Containers

```bash
# Ver containers rodando
docker-compose ps

# Parar todos os serviços
docker-compose stop

# Parar e remover containers
docker-compose down

# Parar, remover containers e volumes (CUIDADO: apaga dados)
docker-compose down -v

# Restart de um serviço específico
docker-compose restart superhero-api

# Ver logs de todos os serviços
docker-compose logs -f

# Ver logs de um serviço específico
docker-compose logs -f superhero-api
```

### Build & Rebuild

```bash
# Rebuild da API
docker-compose build superhero-api

# Rebuild sem cache (força rebuild completo)
docker-compose build --no-cache superhero-api

# Rebuild e restart
docker-compose up --build superhero-api
```

### Acesso aos Containers

```bash
# Entrar no container da API
docker-compose exec superhero-api sh

# Entrar no MongoDB
docker-compose exec mongo mongosh -u root -p MongoDB00

# Entrar no Redis
docker-compose exec redis redis-cli
```

### Limpeza

```bash
# Remover containers parados
docker container prune

# Remover imagens não usadas
docker image prune

# Remover volumes não usados
docker volume prune

# Limpeza completa (CUIDADO!)
docker system prune -a --volumes
```

---

## 🗄️ Persistência de Dados

Os dados são persistidos em volumes Docker:

```bash
# Listar volumes
docker volume ls | grep superhero-ts

# Volumes criados:
# - superhero-ts-redis-data
# - superhero-ts-mongo-data
# - superhero-ts-rabbitmq-data
# - superhero-ts-api-data

# Backup de um volume (exemplo: MongoDB)
docker run --rm -v superhero-ts-mongo-data:/data -v $(pwd):/backup alpine tar czf /backup/mongo-backup.tar.gz -C /data .

# Restore de um backup
docker run --rm -v superhero-ts-mongo-data:/data -v $(pwd):/backup alpine tar xzf /backup/mongo-backup.tar.gz -C /data
```

---

## 🔍 Health Checks

Todos os serviços têm health checks configurados. Para ver status:

```bash
# Ver saúde dos containers
docker-compose ps

# Status detalhado
docker inspect superhero-ts-api | grep -A 10 Health
```

Endpoints de health check:
- API: `http://localhost:3000` (root endpoint)
- Redis: `redis-cli ping`
- MongoDB: `mongosh --eval "db.adminCommand('ping')"`
- RabbitMQ: `rabbitmq-diagnostics ping`

---

## 🌐 Acessar Interfaces Web

Após subir os containers:

- **API**: http://localhost:3000
- **Mongo Express**: http://localhost:8081 (admin / admin123)
- **RabbitMQ Management**: http://localhost:15672 (root / RabMq123)

---

## 🐛 Troubleshooting

### Porta já em uso

```bash
# Ver o que está usando a porta 3000
netstat -ano | findstr :3000

# Matar processo (Windows)
taskkill /PID <PID> /F

# Ou mudar a porta no docker-compose.yml
ports:
  - "3001:3000"  # Mapear 3001 -> 3000
```

### Container não inicia

```bash
# Ver logs detalhados
docker-compose logs superhero-api

# Ver eventos do Docker
docker events

# Verificar recursos
docker stats
```

### Cache de build problemático

```bash
# Rebuild completo sem cache
docker-compose build --no-cache

# Remover imagens antigas
docker image prune -a
```

### Permissões no Linux/Mac

```bash
# Dar permissão aos volumes
sudo chown -R $USER:$USER ./prisma
```

---

## 📊 Performance

### Otimizações Aplicadas

✅ Multi-stage build (reduz imagem de ~1GB para ~150MB)
✅ Alpine Linux (imagem mínima)
✅ Non-root user (segurança)
✅ Health checks (recuperação automática)
✅ Volumes nomeados (persistência)
✅ Networks isoladas (segurança)

### Monitoramento

```bash
# Ver uso de recursos
docker stats

# Ver uso específico da API
docker stats superhero-ts-api

# Top de processos dentro do container
docker top superhero-ts-api
```

---

## 🔐 Segurança

### Recomendações para Produção

1. **Mudar todas as senhas** no docker-compose.yml
2. **Usar secrets** do Docker Swarm ou Kubernetes
3. **Não expor portas desnecessárias** (remover da seção `ports`)
4. **Usar variáveis de ambiente** seguras (`.env` não commitado)
5. **Scan de vulnerabilidades**:

```bash
# Scan da imagem
docker scan superhero-api-ts:latest

# Ou com Trivy
trivy image superhero-api-ts:latest
```

---

## 📝 Variáveis de Ambiente

Crie um arquivo `.env` na raiz do projeto:

```env
# Copiar de .env.docker
HERO_API_TOKEN=seu-token-aqui
HERO_API_URL=https://superheroapi.com/api/
```

O docker-compose lerá automaticamente este arquivo.

---

## 🚢 Deploy

### Docker Swarm

```bash
docker stack deploy -c docker-compose.yml superhero
```

### Kubernetes

Use `kompose` para converter:

```bash
kompose convert -f docker-compose.yml
kubectl apply -f .
```

---

## ❓ FAQ

**Q: Por que usar multi-stage build?**
A: Reduz o tamanho final da imagem e melhora segurança (remove dev dependencies).

**Q: Posso rodar sem Docker?**
A: Sim! Apenas configure Redis, MongoDB e RabbitMQ localmente e ajuste o `.env`.

**Q: Como atualizar a imagem?**
A: `docker-compose pull` seguido de `docker-compose up -d`.

**Q: Onde ficam os logs?**
A: Use `docker-compose logs -f` ou configure volume para `/app/logs`.

---

## 📞 Suporte

Em caso de problemas:

1. Verificar logs: `docker-compose logs -f`
2. Verificar health checks: `docker-compose ps`
3. Testar conectividade: `docker-compose exec superhero-api ping redis`

---

**Desenvolvido com ❤️ usando Docker + TypeScript + Fastify**
