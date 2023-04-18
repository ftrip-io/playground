FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /build

# Copy everything
COPY . .
# Restore as distinct layers

# Build and publish a release
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS final
WORKDIR /app
COPY --from=build /build/out .
ENTRYPOINT ["dotnet", "ftrip.io.framework-playground.dll"]
