FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj from subfolder
COPY WebApplication1/WebApplication1.csproj WebApplication1/

# Restore dependencies
RUN dotnet restore "WebApplication1/WebApplication1.csproj"

# Copy everything
COPY . .

# Build
WORKDIR /src/WebApplication1
RUN dotnet build "WebApplication1.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebApplication1.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebApplication1.dll"]
