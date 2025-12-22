# 🔐 Security Notice - Environment Variables

This project uses environment variables for sensitive configuration data.

## Files Overview

| File | Purpose | Git Tracked | Contains Secrets |
|------|---------|-------------|------------------|
| `.env.example` | Template for local development | ✅ Yes | ❌ No |
| `.env` | Local development config | ❌ No | ⚠️ Yes |
| `.env.docker` | Template for Docker | ✅ Yes | ❌ No |
| `.env.docker.local` | Docker config with real values | ❌ No | ⚠️ Yes |

## Setup Instructions

### For Local Development

1. Copy the example file:
   ```bash
   cp .env.example .env
   ```

2. Edit `.env` and add your real credentials:
   ```bash
   HERO_API_TOKEN=your_actual_token_here
   MONGO_INITDB_ROOT_PASSWORD=your_secure_password
   # ... etc
   ```

### For Docker

1. Copy the Docker template:
   ```bash
   cp .env.docker .env.docker.local
   ```

2. Edit `.env.docker.local` with your real credentials

3. Load the file when running Docker:
   ```bash
   docker-compose --env-file .env.docker.local up
   ```

## Required Credentials

### Hero API Token
Get your token at: https://superheroapi.com

### MongoDB
- Root user: Admin access to MongoDB
- App user: Application-specific database access

### RabbitMQ
- Default credentials for message broker

### Mongo Express
- UI credentials for database management interface

## Security Best Practices

✅ **DO:**
- Keep `.env` and `.env.docker.local` files private
- Use strong, unique passwords for each service
- Rotate credentials regularly
- Use different credentials for dev/staging/production
- Add `.env` to `.gitignore` (already configured)

❌ **DON'T:**
- Commit files containing real credentials to Git
- Share your `.env` files in chat, email, or documentation
- Use default passwords in production
- Reuse credentials across different projects

## Removing .env from Git History

If you accidentally committed `.env` with secrets:

```bash
# Remove from Git but keep on disk
git rm --cached .env .env.docker.local

# Commit the removal
git commit -m "Remove sensitive environment files from tracking"

# Push changes
git push
```

The file will remain on your local disk but won't be tracked by Git anymore.

## Environment Variables Reference

See `.env.example` and `.env.docker` for complete list of required variables.
