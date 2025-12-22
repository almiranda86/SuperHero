# 🚀 Complete Guide - Development and Debugging

## 📋 **3 Ways to Work**

---

## ✅ **Option 1: Local Development (RECOMMENDED for debugging)**

### **When to use:**
- ✅ Debugging with breakpoints
- ✅ Instant hot-reload
- ✅ Cleaner terminal logs
- ✅ Better performance

### **Setup:**

```bash
# 1. Start only services in Docker
cd D:\Arquivos\Projects\SuperHeroV4\Backend\Backend\Typescript
docker-compose up redis mongo rabbitmq -d

# 2. Run application locally
npm run dev

# 3. To stop services
docker-compose stop
```

### **Debugging in VS Code:**

Create `.vscode/launch.json`:
```json
{
  "version": "0.2.0",
  "configurations": [
    {
      "type": "node",
      "request": "launch",
      "name": "Debug TypeScript App",
      "runtimeExecutable": "${workspaceFolder}/node_modules/.bin/tsx",
      "runtimeArgs": ["watch", "src/index.ts"],
      "console": "integratedTerminal",
      "internalConsoleOptions": "neverOpen",
      "skipFiles": ["<node_internals>/**"],
      "env": {
        "NODE_ENV": "development"
      }
    }
  ]
}
```

**How to use:**
1. Open VS Code
2. Go to "Run and Debug" (Ctrl+Shift+D)
3. Click on "Debug TypeScript App"
4. Place breakpoints in the code
5. Debugging working! 🎯

---

## 🐳 **Option 2: Full Docker (Production-like)**

### **When to use:**
- ✅ Test production-like environment
- ✅ Validate Dockerfile
- ✅ Local CI/CD

### **Setup:**

```bash
# Start everything (API + Services)
docker-compose up -d

# View logs
docker-compose logs -f superhero-api

# Rebuild after changes
docker-compose up -d --build

# Stop everything
docker-compose down
```

### **Debugging with Docker:**
**NOT ideal** but possible:

```bash
# View logs in real-time
docker-compose logs -f superhero-api

# Enter the container
docker-compose exec superhero-api sh

# View environment variables
docker-compose exec superhero-api printenv
```

---

## ⚡ **Option 3: Docker Dev (Hot-Reload in Container)**

### **When to use:**
- ✅ Want Docker + hot-reload
- ✅ Consistent environment with team

### **Setup:**

```bash
# Use docker-compose.dev.yml
docker-compose -f docker-compose.dev.yml up -d

# Code is mounted as volume = hot-reload works!
```

---

## 🔍 **How to Verify Redis**

### **1. Quick Test (Ready script):**

```bash
node test-redis.js
```

**Expected output:**
```
🔍 Testing connection with Redis...

✅ Test 1 - PING: PONG
✅ Test 2 - SET: Hero saved in cache
✅ Test 3 - GET: { name: 'Superman', power: 100 }
✅ Test 4 - TTL: 10 seconds
✅ Test 5 - KEYS: X keys found
✅ Test 6 - MEMORY: 2.50M

✅ All tests passed! Redis is working correctly.
```

### **2. Redis CLI (Direct in container):**

```bash
# Enter Redis
docker exec -it superhero-ts-redis redis-cli

# Useful commands:
PING                    # Test connection
KEYS *                  # List all keys
GET key_name            # Get value
TTL key_name            # View time to live
DBSIZE                  # Database size
INFO memory             # Memory info
FLUSHALL                # Clear EVERYTHING (CAREFUL!)
```

### **3. Verify in Application:**

```bash
# With application running, make request that uses cache:
curl http://localhost:3000/hero/get_hero_by_publicid/00000000-0000-0000-0000-000000000001

# First time: fetches from database/external API
# Second time: gets from Redis (faster!)
```

### **4. Real-time Monitor:**

```bash
# View all Redis commands being executed
docker exec -it superhero-ts-redis redis-cli MONITOR
```

---

## 🔎 **Logs and Debugging**

### **Local Application Logs:**
```bash
# Already appears in the terminal where you ran npm run dev
# Colored and formatted logs
```

### **Docker Logs:**
```bash
# View specific logs
docker-compose logs superhero-api

# Follow logs (tail -f)
docker-compose logs -f superhero-api

# Last 50 lines
docker-compose logs --tail=50 superhero-api

# All services
docker-compose logs -f
```

### **Connection Debug:**

```bash
# Check if services are running
docker-compose ps

# Health status
docker ps --format "table {{.Names}}\t{{.Status}}"

# Test connectivity between containers
docker exec superhero-ts-api ping redis
docker exec superhero-ts-api ping mongo
```

---

## 📊 **Useful Commands**

### **Management:**

```bash
# Status
docker-compose ps

# Restart specific service
docker-compose restart superhero-api

# View resource usage
docker stats

# Clean everything
docker-compose down -v  # CAREFUL: deletes volumes!
```

### **Test Endpoints:**

```bash
# PowerShell
Invoke-WebRequest -Uri http://localhost:3000/hero/list_all_heroes | Select-Object -Expand Content

# Or use Postman/Insomnia
# Or use VS Code REST Client extension
```

---

## 🎯 **Recommended Workflow**

### **For Daily Development:**

1. **Start services:**
   ```bash
   docker-compose up redis mongo rabbitmq -d
   ```

2. **Run app locally:**
   ```bash
   npm run dev
   ```

3. **Debug:**
   - Use VS Code debugger (F5)
   - Place breakpoints
   - View variables in real-time

4. **Test Redis:**
   ```bash
   node test-redis.js
   ```

5. **When finished:**
   ```bash
   # Ctrl+C in the application terminal
   docker-compose stop
   ```

### **For Production Testing:**

1. **Build and run everything:**
   ```bash
   docker-compose up --build -d
   ```

2. **Verify:**
   ```bash
   docker-compose ps
   docker-compose logs -f
   ```

3. **Test:**
   ```bash
   curl http://localhost:3000/hero/list_all_heroes
   ```

---

## 🐛 **Troubleshooting**

### **Port in use:**
```bash
# See what's using the port
netstat -ano | findstr :3000

# Kill process (get PID from command above)
taskkill /PID <PID> /F
```

### **Redis not connecting:**
```bash
# Check if it's running
docker ps | Select-String redis

# Test ping
docker exec superhero-ts-redis redis-cli PING
```

### **Application doesn't start:**
```bash
# Clean and reinstall
rm -rf node_modules
npm install

# Regenerate Prisma
npx prisma generate
```

### **Cache not working:**
```bash
# Check Redis logs
docker-compose logs redis

# Clear cache
docker exec superhero-ts-redis redis-cli FLUSHALL
```

---

## 🎨 **Management Interface**

### **Access UIs:**

| Service | URL | Credentials |
|---------|-----|-------------|
| **API** | http://localhost:3000 | - |
| **Mongo Express** | http://localhost:8081 | admin / admin123 |
| **RabbitMQ Management** | http://localhost:15672 | root / RabMq123 |
| **Redis** | Use Redis CLI | - |

---

## ✅ **Quick Checklist**

**Before starting to work:**
- [ ] Docker is running
- [ ] Docker services are UP (`docker-compose ps`)
- [ ] Redis responds PING
- [ ] Application starts without errors

**Verify Redis working:**
- [ ] `node test-redis.js` passes
- [ ] `KEYS *` shows keys in Redis CLI
- [ ] Repeated requests are faster (cache hit)

---

**Any questions, check the logs! 99% of problems are in the logs. 🔍**
