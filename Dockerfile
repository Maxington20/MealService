# Use the official .NET 6 SDK image as the build environment
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# Set the working directory
WORKDIR /src

# Copy the project file and restore the dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy the remaining source code files
COPY . ./

# Build and publish the application
RUN dotnet publish -c Release -o /app

# Use the official .NET 6 runtime image as the execution environment
FROM mcr.microsoft.com/dotnet/aspnet:6.0

# Set the working directory
WORKDIR /app

# Copy the published files from the build environment
COPY --from=build /app ./

# Expose the ports used by the application
EXPOSE 80
EXPOSE 443

# Start the application
ENTRYPOINT ["dotnet", "MealService.dll"]