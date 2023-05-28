# Stage 1: Build stage using the SDK image
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Copy the .csproj file to the current working directory
COPY Blazor-Automated-Email-Marketing-System/*.csproj ./

# Restore the NuGet packages
RUN dotnet restore

# Copy the rest of the source code to the current working directory
COPY Blazor-Automated-Email-Marketing-System/ ./

# Build the application and output the binaries to /app/build
RUN dotnet build -c Release -o /app/build

# Stage 2: Publish stage
FROM build AS publish

# Publish the application to /app/publish
RUN dotnet publish -c Release -o /app/publish

# Stage 3: Final stage using the ASP.NET runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS final
WORKDIR /app

# Expose ports 80 and 443
EXPOSE 80
EXPOSE 443

# Copy the published application from the previous stage
COPY --from=publish /app/publish .

# Set the entry point to run the application
ENTRYPOINT ["dotnet", "Blazor-Automated-Email-Marketing-System.dll"]
