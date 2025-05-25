# Usa imagem com .NET 9 SDK (preview)
FROM mcr.microsoft.com/dotnet/sdk:9.0-preview

# Atualiza pacotes e instala o Git
RUN apt-get update && \
    apt-get install -y git && \
    apt-get clean

# Define o diretório de trabalho
WORKDIR /app

# Clona seu projeto do GitHub (ajuste a URL se necessário)
RUN git clone https://github.com/gtheox/DevopsChallenge.git .

# Restaura pacotes e dependências
RUN dotnet restore

# Exponha a porta que seu projeto usa (ajuste se não for 5012)
EXPOSE 5012

# Roda a aplicação
CMD ["dotnet", "run", "--urls", "http://0.0.0.0:5012"]
