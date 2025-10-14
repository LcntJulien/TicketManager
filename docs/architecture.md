# Architecture

## High-Level Overview
- Mobile apps (iOS, Android) ↔ API (ASP.NET Core) ↔ Database (PostgreSQL on Azure / local)

## Components
- **API (ASP.NET Core)**  
  - Controllers (expose REST endpoints)  
  - Services (business logic)  
  - Data layer (EF Core context, migrations)  

- **Database**  
  - Production: Azure PostgreSQL Flexible Server  
  - Local Dev: PostgreSQL (Docker container or local installation)  

- **Mobile**  
  - iOS: SwiftUI app (developed first)  
  - Android: Kotlin/Jetpack Compose app  

## Local Development Stack
- Docker Compose with:
  - `api` (ASP.NET Core, hot reload enabled)
  - `postgres` (local DB with seed data)
  - `pgadmin` (optional UI for DB inspection)
- EF Core migrations applied locally
- Tests executed via `dotnet test`

## Deployment
- GitHub Actions for CI/CD:
  - Build → Test → Deploy
- Azure App Service for API hosting
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