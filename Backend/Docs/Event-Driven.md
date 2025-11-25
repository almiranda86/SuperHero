# Event-Driven Design — SuperHero

## When to apply event-driven architecture
- For decoupling bounded contexts (analytics, notifications, stats).
- For long-running or eventually-consistent workflows.
- When you need to scale integration without coupling services synchronously.

## Key patterns
- **Domain Events**: events raised by aggregates (HeroCreated, HeroUpdated).
- **Outbox Pattern**: write event to an outbox table in the same DB transaction as the domain change; publish later.
- **Consumer/Subscriber**: async services that react to events.
- **Sagas/Orchestrators**: coordinate long-running multi-step transactions (if necessary).

## Delivery & Guarantees
- Most systems use **at-least-once** delivery; consumers must be idempotent.
- Use correlation IDs and idempotency keys.
- Use dead-letter queues (DLQ) for poison messages.

## Implementation recommendations per language

### C#
- Use `MassTransit` (abstraction) or `RabbitMQ.Client` (raw).  
- Use EF Core + Outbox table and a background dispatcher to publish events reliably.

### Java
- Use `spring-amqp` or `spring-kafka`.  
- Implement transactional outbox (DB row + publisher).

### TypeScript (Node)
- Use `amqplib` for RabbitMQ or `kafkajs` for Kafka.  
- Outbox can be implemented with Postgres + a background worker.

### Go
- Use `streadway/amqp` for RabbitMQ or `segmentio/kafka-go`.  
- Build idempotent consumers and an outbox worker.

### Python
- Use `pika` (RabbitMQ) or `confluent-kafka`.  
- Use a simple background worker (Celery or a small process) to publish outbox rows.

## Sample hero-creation flow (end-to-end)
1. `POST /heroes` -> `CreateHero` use-case
2. Create Hero aggregate; persist Hero and append an `outbox` row in the same transaction.
3. Outbox worker reads unpublished rows and publishes `HeroCreatedEvent` to RabbitMQ/Kafka.
4. Consumer(s) (e.g., Stats service) receive events and update their state asynchronously.

## Where to add in the repo
- `infrastructure/messaging/` in each language project with publisher & consumer skeletons.
- Add an `outbox` schema example under `Backend/Docs/sql/`.
- Provide tests for idempotency and retry behaviors.

## Practical considerations
- Start with a plain RabbitMQ + Postgres setup in docker-compose for local dev.
- Implement idempotency in consumers using deduplication (store event id) or idempotency keys.
- Add monitoring: message lag, DLQ size, consumer failures.
