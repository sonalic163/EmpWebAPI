FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy only the csproj
COPY YarpGateway/YarpGateway.csproj YarpGateway/

# Restore
RUN dotnet restore "YarpGateway/YarpGateway.csproj"

# Copy everything else
COPY . .

# Build
WORKDIR /src/YarpGateway
RUN dotnet build "YarpGateway.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "YarpGateway.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "YarpGateway.dll"]
