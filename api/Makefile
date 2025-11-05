# --- Makefile
.PHONY: build build-api up up-db up-api stop down logs clean run run-dev db-ready shell-db migrate update-db remove-migration

# Load .env variables except DB_CONNECTION for local dev
include .env
export $(shell sed '/DB_CONNECTION/d; s/=.*//' .env)

# --- Docker
build:
	docker-compose build

build-api:
	docker compose build api

up:
	docker compose up -d

up-db:
	docker compose up -d db

up-api:
	docker compose up -d --build --no-deps api

start:
	docker compose start

stop:
	docker compose stop

down:
	docker compose down

logs:
	docker compose logs -f

clean:
	docker system prune -f

# --- Local dev
run:
	cd TicketManager.API && dotnet run

run-dev:
	dotnet watch --project ./TicketManager.API run

db-ready:
	docker compose exec db bash -c "until pg_isready -U ${POSTGRES_USER}; do sleep 1; done"

shell-db:
	docker compose exec db psql -U ${POSTGRES_USER} -d ${POSTGRES_DB}

# --- EF Core
migrate:
	dotnet ef migrations add $(name) --project ./TicketManager.Infrastructure --startup-project ./TicketManager.API

update-db:
	dotnet ef database update --project ./TicketManager.Infrastructure --startup-project ./TicketManager.API

remove-migration:
	dotnet ef migrations remove --project ./TicketManager.Infrastructure --startup-project ./TicketManager.API