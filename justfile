set quiet

DOCKER_APP_SERVICE := "app"

dexec *params:
    docker compose exec {{DOCKER_APP_SERVICE}} bash -c "{{params}}"

init:
    docker compose up -d --remove-orphans --build
    just dexec "sh ./environment/app/init.sh"

start:
    docker compose up -d

dev:
    just dexec "dotnet watch run"

dshell:
    just dexec "bash"
