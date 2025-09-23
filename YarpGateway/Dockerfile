# Build stage
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["YarpGateway/YarpGateway.csproj", "YarpGateway/"]
RUN dotnet restore "YarpGateway/YarpGateway.csproj"
COPY . .
WORKDIR "/src/YarpGateway"
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 80
ENTRYPOINT ["dotnet", "YarpGateway.dll"]
