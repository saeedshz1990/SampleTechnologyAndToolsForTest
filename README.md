# SampleTechnologyForTest

A technology playground and architecture sample built with .NET to explore, review, and demonstrate backend architecture, CQRS, multiple databases, caching, logging, background processing, and different presentation technologies.

## Purpose

This repository is not intended to be a single production application.

It is designed as a learning and experimentation environment for:

- Reviewing technologies previously used
- Practicing technologies and patterns that are new or less familiar
- Demonstrating architectural patterns in a practical way
- Comparing multiple UI and infrastructure approaches in one solution

The primary backend scenario is implemented through the Product feature.

---

## Main Architecture

The core architecture follows a CQRS-style separation between command and query responsibilities.

### Command Side

```text
Client
  ↓
REST API
  ↓
MediatR
  ↓
Command Handler
  ↓
Domain
  ↓
EF Core
  ↓
SQL Server
```

The command database is responsible for write operations.

### Query Side

```text
Client
  ↓
REST API
  ↓
MediatR
  ↓
Query Handler
  ↓
Query Repository
  ↓
EF Core
  ↓
PostgreSQL
```

The query database contains read models optimized for query operations.

---

## CQRS + Outbox Flow

The Product feature demonstrates an end-to-end CQRS flow.

```text
Create Product
      ↓
CreateProductCommand
      ↓
MediatR
      ↓
Command Handler
      ↓
SQL Server
   ├── Product
   └── OutboxMessage
           ↓
   OutboxProcessorService
           ↓
      PostgreSQL
           ↓
        ProductQr
           ↓
      Query Handler
           ↓
GET /api/products
GET /api/products/{id}
```

The Product entity and its OutboxMessage are stored in the same transaction.

A background service processes pending Outbox messages and synchronizes the Product read model with PostgreSQL.

---

## Technologies

### Backend

- .NET 9
- ASP.NET Core
- C#
- MediatR
- FluentValidation
- Entity Framework Core
- CQRS
- Repository Pattern
- Unit of Work
- Outbox Pattern
- Background Services

### Databases & Infrastructure

- SQL Server — Command database
- PostgreSQL — Query database
- MongoDB — Audit logging
- Redis — Distributed caching
- Docker
- Docker Compose

### Testing

- xUnit
- Moq
- ASP.NET Core Integration Testing

### Presentation Technologies

The solution also contains multiple presentation projects for learning and review purposes:

- ASP.NET Core MVC
- REST API
- Blazor
- WPF
- WinForms
- Console

Some presentation projects are intentionally lightweight and are used as technology playgrounds rather than complete applications.

---

## Solution Structure

```text
Application/
├── Command.Application
└── Query.Application

Domain/
└── SampleTechnologyForTest.Entities

Persistence/
├── Command.Persistence
└── Query.Persistence

Infrastructure/
├── SampleTechnologyForTest.Infrastructure
└── SampleTechnologyForTest.Logging

UI/
├── SampleTechnologyForTest.RestApi
├── SampleTechnologyForTest.Web
├── SampleTechnologyForTest.BlazorServer
├── SampleTechnologyForTest.BlazorWASM
├── SampleTechnologyForTest.WPFForm
└── SampleTechnologyForTest.Consol

SampleTechnologyForTest.WinForm/

tests/
├── SampleTechnologyForTest.UnitTests
└── SampleTechnologyForTest.IntegrationTests
```

---

## Database Responsibilities

### SQL Server

Used as the Command database.

Contains the transactional domain data and Outbox messages.

### PostgreSQL

Used as the Query database.

Contains read models optimized for query operations, including the Product read model used by the main CQRS sample.

### MongoDB

Used for audit logging.

### Redis

Configured as distributed cache infrastructure.

---

## Product Query API

### Get all products

```http
GET /api/products
```

### Get product by ID

```http
GET /api/products/{id}
```

---

## Running with Docker

The required infrastructure can be started using Docker Compose.

```bash
docker compose up -d --build
```

The Compose environment includes:

- SQL Server
- PostgreSQL
- Redis
- MongoDB
- REST API

Check container status:

```bash
docker compose ps
```

The REST API is exposed on:

```text
http://localhost:8080
```

OpenAPI document:

```text
http://localhost:8080/openapi/v1.json
```

---

## Connection Strings

Do not commit real credentials.

Use environment variables, user secrets, or a local `.env` file.

Example configuration:

```json
{
  "ConnectionStrings": {
    "CommandDBConnection": "Server=localhost;Database=YOUR_DB;User Id=YOUR_USER;Password=YOUR_PASSWORD;TrustServerCertificate=True;",
    "QueryDBConnection": "Host=localhost;Port=5432;Database=YOUR_DB;Username=YOUR_USER;Password=YOUR_PASSWORD;",
    "RedisConnection": "localhost:6379"
  },
  "MongoDbSettings": {
    "ConnectionString": "mongodb://localhost:27017",
    "DatabaseName": "YOUR_DATABASE"
  }
}
```

---

## Database Migrations

### Command Database

```bash
dotnet ef database update \
  --project Persistence/Command.Persistence/Command.Persistence.csproj \
  --startup-project UI/SampleTechnologyForTest.RestApi/SampleTechnologyForTest.RestApi.csproj \
  --context SampleCommandContext
```

### Query Database

```bash
dotnet ef database update \
  --project Persistence/Query.Persistence/Query.Persistence.csproj \
  --startup-project UI/SampleTechnologyForTest.RestApi/SampleTechnologyForTest.RestApi.csproj \
  --context SampleQueryContext
```

---

## Tests

Run all tests:

```bash
dotnet test SampleTechnologyForTest.sln
```

The repository contains both unit and integration tests.

Current examples include:

- Product domain creation
- Product command validation
- `CreateProductCommandHandler` behavior
- Outbox creation
- REST API smoke/integration testing

---

## Build

Build the complete solution:

```bash
dotnet build SampleTechnologyForTest.sln
```

---

## Current Focus

The Product feature is used as the primary end-to-end architecture sample.

It demonstrates:

```text
Command
  ↓
SQL Server
  ↓
Outbox
  ↓
Background Worker
  ↓
PostgreSQL
  ↓
Query
  ↓
REST API
```

Other modules and UI projects are intentionally kept as learning and experimentation areas.

---

## Future Experiments

Potential future additions may include:

- Dapper-based query examples
- More advanced caching strategies
- Domain Events
- Message broker integration
- Additional background processing
- More advanced WPF MVVM examples
- Blazor client integrations

---

## License

This repository is primarily intended for learning, experimentation, and portfolio demonstration.