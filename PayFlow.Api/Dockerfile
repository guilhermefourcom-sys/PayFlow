# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
# Copia todo o contexto do build
COPY . .
# Restaura e publica explicitando o caminho do projeto para que os ProjectReference sejam resolvidos corretamente
RUN dotnet restore "PayFlow.Api/PayFlow.Api.csproj"
RUN dotnet publish "PayFlow.Api/PayFlow.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "PayFlow.Api.dll"]