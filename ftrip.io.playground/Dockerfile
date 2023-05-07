FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine AS build
WORKDIR /build

# Copy dependencies

COPY ftrip.io.framework-playground/*.csproj ./ftrip.io.framework-playground
COPY ftrip.io.framework-playground.contracts/*.csproj ./ftrip.io.framework-playground.contracts
COPY ftrip.io.framework-playground/package*.json ./ftrip.io.framework-playground
COPY ftrip.io.framework-playground.contracts/package*.json ./ftrip.io.framework-playground.contracts

# Restore dependencies
RUN dotnet restore build/ftrip.io.framework-playground/ftrip.io.framework-playground.csproj

# Copy everything else
COPY . .

# Build and publish a release
RUN dotnet publish --no-restore -c Release -o out
 
# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-alpine AS final
WORKDIR /app
COPY --from=build /build/out .

ENTRYPOINT ["dotnet", "ftrip.io.framework-playground.dll"]