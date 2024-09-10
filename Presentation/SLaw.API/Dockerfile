#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Presentation/SLaw.API/SLaw.API.csproj", "Presentation/SLaw.API/"]
COPY ["Infrastructure/SLaw.Infrastructure/SLaw.Infrastructure.csproj", "Infrastructure/SLaw.Infrastructure/"]
COPY ["Core/SLaw.Application/SLaw.Application.csproj", "Core/SLaw.Application/"]
COPY ["Core/SLaw.Domain/SLaw.Domain.csproj", "Core/SLaw.Domain/"]
COPY ["Infrastructure/SLaw.Persistence/SLaw.Persistence.csproj", "Infrastructure/SLaw.Persistence/"]
RUN dotnet restore "./Presentation/SLaw.API/./SLaw.API.csproj"
COPY . .
WORKDIR "/src/Presentation/SLaw.API"
RUN dotnet build "./SLaw.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./SLaw.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SLaw.API.dll"]