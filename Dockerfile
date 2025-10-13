FROM docker.io/alpine:latest
RUN apk add --no-cache dotnet8-sdk
COPY . ./app
WORKDIR /app
RUN dotnet build
