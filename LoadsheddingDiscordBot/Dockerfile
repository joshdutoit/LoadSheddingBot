FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["LoadsheddingDiscordBot/LoadsheddingDiscordBot.csproj", "LoadsheddingDiscordBot/"]
RUN dotnet restore "LoadsheddingDiscordBot/LoadsheddingDiscordBot.csproj"
COPY . .
WORKDIR "/src/LoadsheddingDiscordBot"
RUN dotnet build "LoadsheddingDiscordBot.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LoadsheddingDiscordBot.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LoadsheddingDiscordBot.dll"]
