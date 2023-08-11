# MiniStoreBackEnd

## Run project on docker
1. docker -t miniStore:latest build .
2. docker -p 8080:80 -p 4334:433 -n MiniStore miniStore:latest
