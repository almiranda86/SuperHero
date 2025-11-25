# Domain Identification & Abstraction — SuperHero (Canonical)

## Purpose
This document defines the canonical domain for the SuperHero demo so every backend implementation (C#, Java, TypeScript, Go, Python) shares the same domain model, ubiquitous language and bounded contexts.

## Bounded Contexts
1. **Hero Management**
   - Responsibilities: CRUD for Hero, attributes, classification, basic business rules.
   - Primary aggregates: `Hero` (root), `Power` (value object), `HeroStats` (entity/sub-aggregate).

2. **Identity & Auth** (optional for demo)
   - Responsibilities: authentication, user accounts, roles, ownership of heroes.

3. **Events & Integration**
   - Responsibilities: domain events, publishing hero-created/hero-updated events for other services (analytics, notifications).

## Core Domain Concepts (Ubiquitous Language)
- **Hero**: aggregate root with id, name, alias, list of powers, creation date, status.
- **Power**: value object (name, magnitude, type).
- **HeroStats**: separate entity for runtime metrics (level, wins, losses).
- **HeroCreatedEvent / HeroUpdatedEvent**: domain events emitted by aggregate operations.

## Aggregate Boundaries & Invariants
- `Hero` ensures unique alias within the tenant scope.
- Updating `Power` must not violate the `Hero` invariants (e.g., sum of power magnitude <= 1000).
- `HeroStats` may be eventually consistent and updated asynchronously.

## DTOs vs Domain Objects
- DTOs are mapping artifacts used for transport and API representation.
- Domain objects live inside the domain layer and encapsulate business rules.

## Shared Domain Contracts (to copy into each language)
```json
{
  "Hero": {
    "id": "guid|string",
    "alias": "string",
    "name": "string",
    "powers": [{"name":"string","magnitude":"int","type":"string"}],
    "createdAt":"ISO8601",
    "status":"ACTIVE|INACTIVE"
  },
  "Events": {
    "HeroCreated": {"heroId":"guid","alias":"string","occurredAt":"ISO8601"},
    "HeroUpdated": {"heroId":"guid","changes": "..."}
  }
}
