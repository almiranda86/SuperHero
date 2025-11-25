# SOLID Principles — Practical Implementation for SuperHero (all languages)

## Overview
SOLID principles are widely applicable guidelines for maintainable and extensible code. Below are concrete ways to apply each principle and tips per language.

---

## Single Responsibility Principle (SRP)
**Rule:** a class/module should have one reason to change.

**Apply by:**
- Keep domain entities focused on business rules.
- Use application layer for orchestration (e.g., `CreateHeroHandler`).
- Keep repositories focused on persistence.

**Language tips:**
- C#: separate domain POCOs and repository classes.
- TypeScript: `hero.entity.ts` vs `hero.repository.ts`.
- Go: `domain/hero.go` (domain behavior) vs `infrastructure/hero_repo.go`.

---

## Open/Closed Principle (OCP)
**Rule:** modules should be open for extension, closed for modification.

**Apply by:**
- Code against interfaces/abstractions (ports).
- Add new behaviors via new classes implementing interfaces, not by changing existing ones.

**Language tips:**
- Java: use interfaces and Spring DI.
- Python: use abstract base classes (abc).

---

## Liskov Substitution Principle (LSP)
**Rule:** derived types should be substitutable for their base types.

**Apply by:**
- Prefer composition over inheritance.
- If you use inheritance, ensure derived classes honor expected contracts.

---

## Interface Segregation Principle (ISP)
**Rule:** many small client-specific interfaces are better than one large interface.

**Apply by:**
- Split repository contracts into read/write or domain-specific interfaces (`IHeroReadRepository`, `IHeroWriteRepository`).

---

## Dependency Inversion Principle (DIP)
**Rule:** depend on abstractions, not concretions.

**Apply by:**
- Define ports (interfaces) in application/domain layer, implement them in infrastructure, compose at runtime.

**Language tips:**
- C#: use constructor injection; register dependencies in DI container.
- Go: pass interfaces into constructors; use concrete implementations only in `main`.
- TS/Python: use simple factories/composition for wiring.

---

## Tests & Examples
- Write pure domain tests (no DB) validating business invariants and rules.
- Write integration tests for infrastructure adapters.

---

## Practical checklist to enforce SOLID in the repo
- [ ] Domain objects contain behavior, not persistence code.
- [ ] Repositories expose interfaces in `ports/`.
- [ ] Use-cases live in `application/` and orchestrate domain + ports.
- [ ] Add tests that assert invariants (place under `tests/domain/`).
- [ ] Document examples of SRP/OCP/DIP in each language subfolder README.
