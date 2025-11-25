
---

## 2) `Backend/Docs/Clean-vs-Onion.md`

```md
# Clean Architecture vs Onion Architecture — Guidance & Recommendation

## Short summary
- **Clean Architecture** (Robert C. Martin): layers organized to keep business rules independent from frameworks.
- **Onion Architecture** (Jeffrey Palermo): concentric layers with Domain at the center. Dependencies point inwards.

Both approaches share the same goal: decouple domain logic from infrastructure. For practical purposes, they are largely interchangeable.

## Recommendation for SuperHero multi-language backend
Use a hybrid **Clean/Onion** structure:
- Domain (center) → Application (use-cases/commands) → Ports/Adapters → Infrastructure → API/Framework.

This maps well across C#, Java, TypeScript, Go and Python.

## Canonical folder structure
/domain -> Entities, Value Objects, Domain Services, Domain Events
/application -> Use cases / Commands / Handlers / DTOs
/ports -> Interfaces / Repository contracts / Event publishers
/infrastructure -> DB implementations, message publishers, external integrations
/api -> HTTP controllers, route mapping, request/response mappers
/tests -> unit / integration tests



## Language-specific guidance

### C# (.NET)
- Typical projects: `MyApp.Domain`, `MyApp.Application`, `MyApp.Infrastructure`, `MyApp.Api`.
- Use `MediatR` for commands/queries if helpful.
- Keep domain POCOs free of framework attributes; infrastructure contains EF Core entities and mappings.
- Use Microsoft DI for wiring in Program.cs.

### Java (Spring Boot)
- Packages: `com.superhero.domain`, `com.superhero.application`, `com.superhero.ports`, `com.superhero.infrastructure`.
- Keep domain free of Spring annotations. Use Spring in the infrastructure and API layers.
- Use interfaces for repositories and wire implementations via Spring configuration.

### TypeScript (Node.js - NestJS or Express)
- Directories: `src/domain`, `src/application`, `src/ports`, `src/infrastructure`, `src/api`.
- If using NestJS, avoid Nest decorators in the domain layer; keep domain pure.

### Go
- Packages: `domain`, `usecase`, `ports`, `infrastructure`, `http`.
- Favor composition over inheritance. Keep domain package independent.

### Python (FastAPI / Flask)
- Modules: `domain/`, `application/`, `ports/`, `infrastructure/`, `api/`.
- Keep domain classes plain; avoid injecting ORM models into domain objects.

## Practical repo suggestions
1. Add `Backend/Docs/ADR/` and store Architecture Decision Records (ADR) for major choices.
2. Implement one language first (recommendation: C#) and validate the architecture end-to-end.
3. Copy the canonical structure to each language project, maintaining consistent names and commands.
4. Provide a `composition root` for each language to wire interfaces to implementations.

## Why the hybrid works
- It's language-agnostic, demonstrates clear domain separation, and shows architectural thinking across implementations.
