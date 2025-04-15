FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ../CoordinateLookup.sln ./
COPY ../CoordinateLookup.Api/CoordinateLookup.Api.csproj ./CoordinateLookup.Api/
COPY ../CoordinateLookup.Business/CoordinateLookup.Business.csproj ./CoordinateLookup.Business/
COPY ../CoordinateLookup.Data/CoordinateLookup.Data.csproj ./CoordinateLookup.Data/
COPY ../CoordinateLookup.Dto/CoordinateLookup.Dto.csproj ./CoordinateLookup.Dto/
COPY ../CoordinateLookup.Entities/CoordinateLookup.Entities.csproj ./CoordinateLookup.Entities/
COPY ../CoordinateLookup.Shared/CoordinateLookup.Shared.csproj ./CoordinateLookup.Shared/

RUN dotnet restore "CoordinateLookup.Api/CoordinateLookup.Api.csproj"

COPY ../ ./

WORKDIR /src/CoordinateLookup.Api
RUN dotnet build "CoordinateLookup.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CoordinateLookup.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CoordinateLookup.Api.dll"]