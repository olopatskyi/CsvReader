# Stage 1: Build the Angular app
FROM node:14.17.0-alpine AS angular-build
WORKDIR /app

# Copy the package.json and package-lock.json files
COPY ClientApp/package*.json ./

# Install dependencies
RUN npm ci

# Copy the entire Angular app
COPY ClientApp/ ./

# Build the Angular app
RUN npm run build -- --prod

# Stage 2: Build the .NET Core app
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS dotnet-build
WORKDIR /app

# Copy the .csproj and restore dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy the entire solution
COPY . ./

# Build the .NET Core app
RUN dotnet build --configuration Release --no-restore

# Publish the .NET Core app
RUN dotnet publish --configuration Release --no-build --output out

# Stage 3: Create the runtime image
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS runtime
WORKDIR /app

# Copy the published output from the build stage
COPY --from=dotnet-build /app/out ./

# Expose the desired ports
EXPOSE 80
EXPOSE 443

# Set the entry point for the application
ENTRYPOINT ["dotnet", "YourProjectName.dll"]
