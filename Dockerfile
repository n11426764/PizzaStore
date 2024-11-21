# Use the official .NET 9 SDK image for building the application
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Copy the project file(s) and restore dependencies
COPY PizzaStore.csproj ./
RUN dotnet restore

# Copy the rest of the application source code
COPY . ./
RUN dotnet publish -c Release -o /app/out

# Use the official .NET 9 runtime image for running the application
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app

# Copy the built output from the previous stage
COPY --from=build /app/out .

# Expose the port the app runs on
EXPOSE 8080

# Set the entry point for the container
ENTRYPOINT ["dotnet", "PizzaStore.dll"]
