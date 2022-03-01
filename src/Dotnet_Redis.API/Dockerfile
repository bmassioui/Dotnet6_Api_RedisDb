FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Dotnet_Redis.API/Dotnet_Redis.API.csproj", "src/Dotnet_Redis.API/"]
RUN dotnet restore "src/Dotnet_Redis.API/Dotnet_Redis.API.csproj"
COPY . .
WORKDIR "/src/src/Dotnet_Redis.API"
RUN dotnet build "Dotnet_Redis.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Dotnet_Redis.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Dotnet_Redis.API.dll"]
