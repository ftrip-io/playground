FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine as build
WORKDIR /build

ARG CONFIGURATION=Release

# Restore dependencies
COPY ["ftrip.io.framework-playground.contracts/*.csproj", "ftrip.io.framework-playground.contracts/package*.json", "./ftrip.io.framework-playground.contracts/"]
RUN dotnet restore /p:Configuration=$CONFIGURATION ftrip.io.framework-playground.contracts/ftrip.io.framework-playground.contracts.csproj

COPY ["ftrip.io.framework-playground/*.csproj", "ftrip.io.framework-playground/package*.json", "./ftrip.io.framework-playground/"]
RUN dotnet restore /p:Configuration=$CONFIGURATION ftrip.io.framework-playground/ftrip.io.framework-playground.csproj

# Publish
COPY . . 

RUN dotnet publish -c $CONFIGURATION -o out ftrip.io.framework-playground/ftrip.io.framework-playground.csproj
 
# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-alpine 
WORKDIR /app

COPY --from=build /build/out .

EXPOSE 80

ENTRYPOINT ["dotnet", "ftrip.io.framework-playground.dll"]