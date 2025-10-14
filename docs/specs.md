# Ticket Manager - Specifications

## Goal
Provide a mobile application for managing support tickets, powered by a secure and scalable API.

## Functional Requirements
- User registration & login (JWT authentication)
- Ticket creation, editing, and closing
- Ticket assignment to users or teams
- Filtering & searching tickets
- Push notifications (future)

## Non-Functional Requirements
- API built in C# using ASP.NET Core and EF Core
- PostgreSQL database
- Secure and scalable (JWT, Azure deployment)
- Mobile apps: iOS (SwiftUI first), Android (Kotlin later)
- Code tested via GitHub Actions

## Constraints
- Must be deployable on Azure (App Service + PostgreSQL Flexible Server)
- CI/CD with GitHub Actions
- Local environment via Docker Compose (API + PostgreSQL + optional pgAdmin)
- All documentation written in English
