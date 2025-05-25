# Etapa 1: build com .NET 9 SDK
FROM mcr.microsoft.com/dotnet/sdk:9.0-preview AS build
WORKDIR /app

COPY . ./
RUN dotnet restore
RUN dotnet publish -c Release -o out

# Etapa 2: runtime com .NET 9 ASP.NET
FROM mcr.microsoft.com/dotnet/aspnet:9.0-preview
WORKDIR /app

COPY --from=build /app/out .

# Porta usada pela aplicação
EXPOSE 5012

# Inicialização
ENTRYPOINT ["dotnet", "MottuControlApi.dll"]
