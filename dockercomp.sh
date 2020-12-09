#!/bin/bash
mv Dockerfile-rest Dockerfile
docker build -t rest:0.1 .
mv Dockerfile Dockerfile-rest
mv Dockerfile-logs Dockerfile
docker build -t logs:0.1 .
mv Dockerfile Dockerfile-logs
docker run --name rest rest:0.1
docker run --name logs logs:0.1
echo "Done"
