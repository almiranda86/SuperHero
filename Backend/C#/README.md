**SuperHero Project - C# Version**<br />

#  SuperHero API

## 📄 License

This project is open source and available under the [MIT License](LICENSE).

---

## 👨‍💻 Author

**André Luis Miranda**  
Senior Fullstack Software Engineer

---

A robust REST API built with **.NET 7** following **Clean Architecture** principles, designed to manage superhero data with multi-layer caching, event-driven architecture, and external API integration.

---

## 📋 Table of Contents

- [Overview](#-overview)
- [Architecture](#-architecture)
- [Technologies](#-technologies)
- [Key Features](#-key-features)
- [Project Structure](#-project-structure)
- [Getting Started](#-getting-started)
- [API Endpoints](#-api-endpoints)
- [Architecture Highlights](#-architecture-highlights)

---

## 🎯 Overview

SuperHero API is a demonstration project that showcases modern software engineering practices and patterns. The application provides endpoints to query superhero information, leveraging a multi-tier caching strategy and event-driven architecture to ensure optimal performance and scalability.

### Core Functionality

- **Hero Listing**: Paginated retrieval of all superheroes
- **Hero Details**: Detailed information lookup with intelligent caching
- **Authentication**: JWT-based security with role-based access control
- **Event Processing**: Asynchronous data synchronization via message queues

### Data Flow

```
┌─────────────┐      ┌─────────────┐      ┌─────────────┐       ┌───────────────┐
│   Client    │────▶│   Redis     │─────▶│   MongoDB   │─────▶│ External API  │
│   Request   │      │   (Cache)   │      │(Persistence)│       │(superheroapi) │
└─────────────┘      └─────────────┘      └─────────────┘       └───────────────┘
                           │                   │                   │
                           └───────────────────┴───────────────────┘
                                          │
                                    ┌─────▼─────┐
                                    │  RabbitMQ │
                                    │ (Events)  │
                                    └───────────┘
```

---

## 🏗 Architecture

This project follows **Clean Architecture** principles, ensuring separation of concerns, testability, and maintainability.

### Layer Overview

```
┌────────────────────────────────────────────────────────────┐
│                    PRESENTATION LAYER                      │
│  ┌─────────────────────────────────────────────────────┐   │
│  │                  SuperHero.API                      │   │
│  │         Controllers • Filters • Middleware          │   │
│  └─────────────────────────────────────────────────────┘   │
├────────────────────────────────────────────────────────────┤
│                    APPLICATION LAYER                       │
│  ┌─────────────────────┐  ┌─────────────────────────────┐  │
│  │  SuperHero.Service  │  │      SuperHero.Core         │  │
│  │  Handlers • DTOs    │  │ Pagination • ServiceResponse│  │
│  └─────────────────────┘  └─────────────────────────────┘  │
├────────────────────────────────────────────────────────────┤
│                      DOMAIN LAYER                          │
│  ┌─────────────────────────────────────────────────────┐   │
│  │                 SuperHero.Domain                    │   │
│  │        Entities • Interfaces • Behaviors            │   │
│  └─────────────────────────────────────────────────────┘   │
├────────────────────────────────────────────────────────────┤
│                  INFRASTRUCTURE LAYER                      │
│  ┌──────────────┐ ┌──────────────┐ ┌──────────────────┐    │
│  │  Repository  │ │   MongoDB    │ │      Redis       │    │
│  │  (EF Core)   │ │ (Documents)  │ │  (Distributed    │    │
│  │              │ │              │ │     Cache)       │    │
│  └──────────────┘ └──────────────┘ └──────────────────┘    │
│  ┌──────────────┐ ┌──────────────┐ ┌──────────────────┐    │
│  │   RabbitMQ   │ │   External   │ │     Security     │    │
│  │  Producer/   │ │   Service    │ │   (JWT/Identity) │    │
│  │  Consumer    │ │   (REST)     │ │                  │    │
│  └──────────────┘ └──────────────┘ └──────────────────┘    │
│  ┌─────────────────────────────────────────────────────┐   │
│  │                   SuperHero.IoC                     │   │
│  │            Dependency Injection Configuration       │   │
│  └─────────────────────────────────────────────────────┘   │
└────────────────────────────────────────────────────────────┘
```

### Project Dependencies

| Project | Description | Dependencies |
|---------|-------------|--------------|
| `SuperHero.API` | Web API entry point | IoC |
| `SuperHero.Service` | Application services & handlers | Domain, Core, Infrastructure, Redis, Security |
| `SuperHero.Domain` | Business entities & interfaces | - |
| `SuperHero.Core` | Shared abstractions | MediatR |
| `SuperHero.Repository` | EF Core data access | Domain, Infrastructure |
| `SuperHero.MongoDB` | MongoDB data access | Domain, Infrastructure |
| `SuperHero.Redis` | Distributed caching | - |
| `SuperHero.RabbitMq.Producer` | Message publishing | Domain, Infrastructure |
| `SuperHero.RabbitMq.Consumer` | Message consumption | Domain, Infrastructure, Redis |
| `SuperHero.ExternalService` | External API integration | Domain |
| `SuperHero.Security` | Authentication & Authorization | - |
| `SuperHero.Infrastructure` | Cross-cutting concerns | Core |
| `SuperHero.IoC` | DI container configuration | All projects |

---

## 🛠 Technologies

### Backend Framework
| Technology | Version | Purpose |
|------------|---------|---------|
| .NET | 7.0 | Runtime framework |
| ASP.NET Core | 7.0 | Web API framework |
| Entity Framework Core | 7.0.3 | ORM (InMemory provider) |

### Data Storage
| Technology | Purpose |
|------------|---------|
| EF Core InMemory | Primary hero list storage |
| MongoDB | Complete hero data persistence |
| Redis | Distributed caching layer |

### Messaging & Integration
| Technology | Purpose |
|------------|---------|
| RabbitMQ | Asynchronous event processing |
| RestSharp | External API consumption |

### Security
| Technology | Purpose |
|------------|---------|
| ASP.NET Identity | User management |
| JWT Bearer | Token-based authentication |

### Architecture & Patterns
| Pattern | Implementation |
|---------|----------------|
| Clean Architecture | Layer separation |
| CQRS | MediatR handlers |
| Repository Pattern | Data access abstraction |
| Strategy Pattern | Consumer resolution |
| Dependency Injection | Microsoft.Extensions.DI |

### Testing
| Technology | Purpose |
|------------|---------|
| xUnit | Test framework |
| Moq | Mocking framework |
| Moq.AutoMock | Automatic mock injection |
| FluentAssertions | Assertion library |

### DevOps & Infrastructure
| Technology | Purpose |
|------------|---------|
| Docker | Containerization |
| Docker Compose | Multi-container orchestration |
| Swagger/OpenAPI | API documentation |

---

## ✨ Key Features

### 1. Multi-Layer Caching Strategy

The API implements an intelligent caching strategy that minimizes external API calls:

```
Request → Redis Cache (2 min TTL)
              ↓ (cache miss)
         MongoDB (persistent)
              ↓ (not found)
         External API (superheroapi.com)
              ↓
         Publish to RabbitMQ → Persist to MongoDB + Redis
```

### 2. Event-Driven Architecture

- **Producer**: Publishes hero data to multiple queues after external API fetch
- **Consumer**: Background service processes messages asynchronously
- **Strategy Pattern**: `ConsumerResolver` dynamically selects the appropriate persister (MongoDB or Redis)

### 3. Clean Separation of Concerns

- **Domain Layer**: Pure business logic, no external dependencies
- **Application Layer**: Use cases orchestration via MediatR handlers
- **Infrastructure Layer**: Technical implementations (databases, messaging, external services)

### 4. Modular IoC Configuration

Each feature has its own configuration class:
- `ConfigureDbContext` - Database contexts
- `ConfigureRedis` - Distributed cache
- `ConfigureMongoDB` - Document database
- `ConfigureRabbitMq` - Message broker
- `ConfigureSecurity` - JWT authentication
- `ConfigureHandlers` - MediatR handlers

### 5. JWT Authentication with Role-Based Access

- Secure endpoints with Bearer token authentication
- Role-based authorization (`ROOT_API_ACCESS`)
- Automatic user and role seeding on startup

### 6. Background Processing

`ConsumerBackgroundService` runs continuously, processing messages from RabbitMQ queues with configurable delay intervals.

### 7. Docker-Ready Infrastructure

Complete `docker-compose.yml` with all dependencies:
- RabbitMQ (with management UI)
- Redis
- MongoDB (with Mongo Express UI)
- API container

---

## 📁 Project Structure

```
Backend/C#/
├── SuperHero.API/                    # Web API
│   ├── Controllers/
│   │   ├── HeroController.cs         # Hero endpoints
│   │   └── LoginController.cs        # Authentication
│   ├── Configuration/
│   ├── Extensions/
│   ├── Filter/
│   ├── Program.cs
│   └── appsettings.json
│
├── SuperHero.Service/                # Application Layer
│   ├── Handlers/
│   │   ├── ListAllHeroesPaginatedRequestHandler.cs
│   │   ├── GetHeroeByPublicIdRequestHandler.cs
│   │   └── LoginUserRequestHandler.cs
│   ├── DTO/
│   └── Setup.cs
│
├── SuperHero.Domain/                 # Domain Layer
│   ├── Model/
│   │   ├── BaseHero.cs
│   │   ├── CompleteHero.cs
│   │   ├── Powerstats.cs
│   │   └── ...
│   ├── Behavior/
│   │   ├── Repository/
│   │   ├── Service/
│   │   └── Event/
│   └── Resources/
│       └── heroes.txt                # 731 heroes seed data
│
├── SuperHero.Repository/             # EF Core Repository
├── SuperHero.MongoDB/                # MongoDB Repository
├── SuperHero.Redis/                  # Redis Cache Extensions
├── SuperHero.RabbitMq.Producer/      # Message Producer
├── SuperHero.RabbitMq.Consumer/      # Message Consumer
├── SuperHero.ExternalService/        # External API Client
├── SuperHero.Security/               # Auth & Identity
├── SuperHero.Infrastructure/         # Cross-cutting
├── SuperHero.Core/                   # Shared Abstractions
├── SuperHero.IoC/                    # DI Configuration
├── SuperHero.Test/                   # Unit Tests
│
├── docker-compose.yml                # Infrastructure
└── SuperHero.API.sln                 # Solution file
```

---

## 🚀 Getting Started

### Prerequisites

- [.NET 7 SDK](https://dotnet.microsoft.com/download/dotnet/7.0)
- [Docker Desktop](https://www.docker.com/products/docker-desktop)

### Running with Docker Compose

1. **Clone the repository**
   ```bash
   git clone https://github.com/almiranda86/SuperHero.git
   cd SuperHero/Backend/C#
   ```

2. **Start the infrastructure**
   ```bash
   docker-compose up -d
   ```

3. **Access the services**
   - API: http://localhost:3500/swagger
   - RabbitMQ Management: http://localhost:15672 (root/RabMq123)
   - Mongo Express: http://localhost:8081

### Running Locally

1. **Start dependencies** (Redis, MongoDB, RabbitMQ)
   ```bash
   docker-compose up -d redis mongo rabbitmq
   ```

2. **Run the API**
   ```bash
   cd SuperHero.API
   dotnet run
   ```

3. **Access Swagger UI**
   - https://localhost:7163/swagger

---

## 🔌 API Endpoints

### Authentication

| Method | Endpoint | Description |
|--------|----------|-------------|
| POST | `/Login` | Authenticate and receive JWT token |

**Request Body:**
```json
{
  "user": {
    "userID": "root",
    "password": "Root@123"
  }
}
```

### Heroes

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/hero/list_all_heroes_paginated` | List heroes with pagination |
| GET | `/hero/get_hero_by_publicid/{publicid}` | Get complete hero details |

**Query Parameters (Pagination):**
- `pageNumber` (default: 1)
- `pageSize` (default: 10, max: 10)

---

## 🏆 Architecture Highlights

### Why Clean Architecture?

> *"The Domain is responsible for guarding all the System's ways to be. If I want to rewrite this in another tech stack, this Domain definition must be respected and implemented accordingly."*

This project demonstrates:

1. **Independence from Frameworks**: The domain layer has no knowledge of ASP.NET Core
2. **Testability**: Business logic can be tested without UI, database, or external services
3. **Independence from UI**: The API could be swapped for a CLI or message-based interface
4. **Independence from Database**: MongoDB could be replaced with PostgreSQL without affecting business logic
5. **Independence from External Services**: The external API integration is abstracted behind interfaces

### Design Decisions

| Decision | Rationale |
|----------|-----------|
| InMemory DB for base heroes | Fast startup, demonstration purposes |
| MongoDB for complete heroes | Document model fits hero schema |
| Redis for caching | Distributed, fast, TTL support |
| RabbitMQ for events | Decoupled persistence, scalability |
| MediatR for CQRS | Clean handler separation, pipeline behaviors |
| Strategy Pattern for consumers | Extensible, queue-specific processing |

---

[![LinkedIn](https://img.shields.io/badge/LinkedIn-mirandaandre-blue?style=flat&logo=linkedin)](https://linkedin.com/in/mirandaandre)
[![GitHub](https://img.shields.io/badge/GitHub-almiranda86-black?style=flat&logo=github)](https://github.com/almiranda86)
