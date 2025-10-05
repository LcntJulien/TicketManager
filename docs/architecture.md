# Architecture

## High level
- Mobile apps (iOS, Android) ↔ API (ASP.NET Core) ↔ Database (PostgreSQL on Azure / local)

## Components
- **API (ASP.NET Core)**  
  - Controllers (expose endpoints, REST)  
  - Services (business logic)  
  - Data (EF Core context, migrations)  

- **Database**  
  - Production: PostgreSQL (Azure Flexible Server)  
  - Local Dev: PostgreSQL (Docker container or local installation)  

- **Mobile**  
  - iOS: SwiftUI app  
  - Android: Kotlin/Jetpack Compose app  

## Local development stack
- Docker Compose with:
  - `api` (ASP.NET Core, hot reload enabled)
  - `postgres` (local DB with dev data)
  - `pgadmin` (optional UI for DB inspection)
- EF Core migrations applied locally
- Tests executed via `dotnet test`

## Deployment
- GitHub Actions for CI/CD:
  - Build → Test → Deploy
- Azure App Service for API
- Azure PostgreSQL Flexible Server for DB
- Secrets managed via GitHub Actions Secrets or Azure Key Vault

## Schema

```
                ┌─────────────┐
                │   GitHub    │
                │ (Repo + CI) │
                └──────┬──────┘
                       │
             Build/Test/Deploy
                       │
         ┌─────────────┴─────────────┐
         │                           │
 ┌───────▼───────┐           ┌───────▼────────┐
 │  .NET API     │           │ PostgreSQL DB  │
 │ (Azure AppSvc)│           │ (Azure DB Host)│
 └───────┬───────┘           └────────────────┘
         │
         │ (REST/HTTPS)
 ┌───────▼────────┐
 │  iOS App       │
 │ (Swift/Native) │
 └────────────────┘
 ┌───────▼────────┐
 │ Android App    │
 │ (Kotlin/Native)│
 └────────────────┘
```

## Local Schema

```
                 ┌────────────────┐
                 │   Developer    │
                 │ (Local Env)    │
                 └───────┬────────┘
                         │
          ┌──────────────┴──────────────┐
          │                             │
  ┌───────▼─────────┐           ┌────────▼───────┐
  │  API (Docker)   │           │ PostgreSQL DB  │
  │ .NET + HotReload│           │ (Docker/local) │
  └───────┬─────────┘           └────────────────┘
          │
  ┌───────▼────────┐
  │  pgAdmin       │ (optional)
  └────────────────┘
```