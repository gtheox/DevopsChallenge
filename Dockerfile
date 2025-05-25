# Etapa 1: Build da aplicação
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app
COPY . ./
RUN dotnet restore
RUN dotnet publish -c Release -o out

# Etapa 2: Imagem final para execução
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /app/out .
EXPOSE 80
USER 1000
ENTRYPOINT ["dotnet", "MottuControlApi.dll"]
