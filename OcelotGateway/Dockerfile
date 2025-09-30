# Use .NET 8.0 SDK for building
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy only the csproj (for restore step)
COPY OcelotGateway.csproj ./

# Restore dependencies
RUN dotnet restore "OcelotGateway.csproj"

# Copy the rest of the project files
COPY . .

# Build the project
RUN dotnet build "OcelotGateway.csproj" -c Release -o /app/build

# Publish the project
FROM build AS publish
RUN dotnet publish "OcelotGateway.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish ./
ENTRYPOINT ["dotnet", "OcelotGateway.dll"]
