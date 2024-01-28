.PHONY: all setup migrations run

all: setup migrations run

setup:
    docker-compose up -d

migrations:
    dotnet ef migrations add Migrations
    dotnet ef database update

run:
    dotnet run