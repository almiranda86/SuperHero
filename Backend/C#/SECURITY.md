# 🔐 Security Guide - SuperHero C# API

## Overview

This project uses multiple configuration files to manage sensitive information securely. This guide explains how to set up and manage these configurations safely.

## Configuration Files

| File | Purpose | Git Tracked | Contains Secrets |
|------|---------|-------------|------------------|
| `appsettings.example.json` | Template for production configuration | ✅ Yes | ❌ No |
| `appsettings.Development.example.json` | Template for development configuration | ✅ Yes | ❌ No |
| `appsettings.json` | Production configuration with real values | ❌ No | ⚠️ Yes |
| `appsettings.Development.json` | Development configuration with real values | ❌ No | ⚠️ Yes |
| `.env.example` | Template for Docker Compose environment | ✅ Yes | ❌ No |
| `.env` | Docker Compose actual configuration | ❌ No | ⚠️ Yes |

## Setup Instructions

### 1. Local Development (Without Docker)

Copy the example configuration files:

```bash
cd Backend/C#/SuperHero.API

# Copy templates
cp appsettings.example.json appsettings.json
cp appsettings.Development.example.json appsettings.Development.json
```

Edit the files and replace placeholders with your actual credentials:

```json
{
  "MongoDB": {
    "ConnectionURI": "mongodb://root:YourActualPassword@localhost:27017",
    "DatabaseName": "HeroesDB",
    "CollectionName": "Heroes"
  },
  "HeroAPI": {
    "ApiToken": "10226731715421264",
    "ApiURL": "https://superheroapi.com/api/"
  },
  "Security": {
    "TokenConfigurations": {
      "SecretJwtKey": "VGVzdGVzIGNvbSAuTkVUIDYsIEFTUC5ORVQgQ29yZSBlIEpXVA=="
    },
    "RootAuthUsers": {
      "AuthUsers": [
        {
          "UserName": "root",
          "password": "YourSecurePassword123!"
        }
      ]
    }
  }
}
```

### 2. Docker Deployment

Copy the environment template:

```bash
cd Backend/C#

# Copy template
cp .env.example .env
```

Edit `.env` with your actual credentials:

```bash
RABBITMQ_DEFAULT_USER=root
RABBITMQ_DEFAULT_PASS=YourSecureRabbitMQPassword

MONGO_INITDB_ROOT_USERNAME=root
MONGO_INITDB_ROOT_PASSWORD=YourSecureMongoDBPassword
MONGO_INITDB_DATABASE=HeroesDB

MONGO_EXPRESS_PASSWORD=YourSecureMongoExpressPassword
```

Start services:

```bash
docker-compose up -d
```

## Required Credentials

### MongoDB
- **Root Username**: Admin user for MongoDB
- **Root Password**: Secure password for root user
- **Database Name**: HeroesDB (default)
- **Collection Name**: Heroes (default)

### RabbitMQ
- **User**: Username for RabbitMQ broker
- **Password**: Secure password for RabbitMQ
- **Port**: 5672 (AMQP), 15672 (Management UI)

### Redis
- **Host**: Hostname/IP of Redis server
- **Port**: 6379 (default)
- **Password**: Optional, leave empty if not using authentication

### Hero API
- **API Token**: Get your free token at https://superheroapi.com
- **API URL**: https://superheroapi.com/api/ (default)

### JWT Authentication
- **Secret Key**: Base64-encoded secret for signing JWT tokens
  - Generate with: `echo -n "YourSecretText" | base64`
- **Audience**: Target audience for the token
- **Issuer**: Token issuer identifier
- **Expiration**: Token lifetime in seconds

### Root User
- **Username**: Administrative user for the API
- **Password**: Strong password meeting security requirements

## Security Best Practices

✅ **DO:**
- Use strong, unique passwords for each service
- Generate JWT secrets with at least 32 characters
- Rotate credentials regularly
- Use different credentials for dev/staging/production
- Keep `.gitignore` up to date
- Use User Secrets for local development in Visual Studio

❌ **DON'T:**
- Commit `appsettings.json` or `appsettings.Development.json` with real credentials
- Share configuration files containing secrets
- Use default or weak passwords in production
- Reuse passwords across different services
- Store credentials in source control

## User Secrets (Recommended for Development)

Visual Studio supports User Secrets for secure local development:

```bash
# Right-click on SuperHero.API project → Manage User Secrets

# This opens secrets.json where you can store:
{
  "MongoDB:ConnectionURI": "mongodb://root:YourPassword@localhost:27017",
  "HeroAPI:ApiToken": "your_token_here",
  "Security:TokenConfigurations:SecretJwtKey": "your_secret_here"
}
```

User Secrets are stored outside the project directory and never committed to Git.

## Environment Variables

The application supports environment variable configuration. Variables take precedence over `appsettings.json`:

```bash
# Example for PowerShell
$env:MongoDB__ConnectionURI = "mongodb://root:password@localhost:27017"
$env:HeroAPI__ApiToken = "your_token"
$env:Security__TokenConfigurations__SecretJwtKey = "your_secret"

# Run application
dotnet run
```

## Docker Compose Override

For local Docker development with custom settings:

```bash
# Create docker-compose.override.yml (already in .gitignore)
version: '3.4'

services:
  superhero.api:
    environment:
      - ConnectionStrings__MongoDB=mongodb://root:LocalPassword@mongo:27017
      - HeroAPI__ApiToken=your_token
```

## Removing Secrets from Git

If you accidentally committed secrets:

```bash
# Remove from tracking (keeps local file)
git rm --cached SuperHero.API/appsettings.json
git rm --cached SuperHero.API/appsettings.Development.json
git rm --cached .env

# Commit removal
git commit -m "security: Remove configuration files with secrets"

# Push
git push
```

To remove from history (if already pushed):

```bash
# WARNING: Rewrites history
git filter-branch --force --index-filter \
  "git rm --cached --ignore-unmatch SuperHero.API/appsettings.json SuperHero.API/appsettings.Development.json .env" \
  --prune-empty --tag-name-filter cat -- --all

# Force push
git push origin --force --all
```

**Important**: Immediately rotate any exposed credentials!

## Credential Rotation Checklist

If credentials were leaked:

- [ ] Generate new MongoDB password
- [ ] Generate new RabbitMQ password
- [ ] Generate new JWT secret key
- [ ] Get new Hero API token (if needed)
- [ ] Update all configuration files
- [ ] Restart all services
- [ ] Remove secrets from Git history
- [ ] Review access logs for unauthorized access

## Generating Secure Credentials

### Strong Password
```bash
# PowerShell
Add-Type -AssemblyName System.Web
[System.Web.Security.Membership]::GeneratePassword(16,4)
```

### JWT Secret (Base64)
```bash
# PowerShell
$secret = [System.Guid]::NewGuid().ToString() + [System.Guid]::NewGuid().ToString()
[Convert]::ToBase64String([System.Text.Encoding]::UTF8.GetBytes($secret))
```

### Random Token
```bash
# PowerShell
-join ((48..57) + (65..90) + (97..122) | Get-Random -Count 32 | ForEach-Object {[char]$_})
```

## Support

For questions or issues:
1. Check this guide first
2. Review the example files
3. Consult team documentation
4. Contact the development team

## Additional Resources

- [ASP.NET Core Configuration](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/)
- [Safe Storage of App Secrets](https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets)
- [Docker Secrets](https://docs.docker.com/engine/swarm/secrets/)
- [.NET User Secrets](https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets)
