# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.

# For more information, please see https://aka.ms/containercompat

# Pull the base image for the Docker container. In this case, using the Microsoft ASP.NET Core runtime image that's compatible with .NET 7.0.
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
#FROM blazor-automated-email-marketing-system:v1.0 AS base

# Set the working directory inside the Docker container to /app.
WORKDIR /app

# Expose ports 80 and 443 in the Docker container as standard ports for HTTP and HTTPS traffic respectively.
EXPOSE 80
EXPOSE 443

# Pull the .NET SDK image which includes everything needed to compile a .NET application. This is used as the build environment.
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

# Set the working directory in the build environment to /src.
WORKDIR /src

# Copy the project file into the Docker container.
COPY ["Blazor-Automated-Email-Marketing-System/Blazor-Automated-Email-Marketing-System.csproj", "Blazor-Automated-Email-Marketing-System/"]

# Restore the NuGet packages required by the project.
RUN dotnet restore "Blazor-Automated-Email-Marketing-System/Blazor-Automated-Email-Marketing-System.csproj"

# Copy the remaining the source code into the Docker container.
COPY . .

# Set the working directory to the project's main directory.
WORKDIR "/src/Blazor-Automated-Email-Marketing-System"

# Builds the project in release configuration and output the built artefact to the /app/build directory.
RUN dotnet build "Blazor-Automated-Email-Marketing-System.csproj" -c Release -o /app/build

# Create a new stage named "publish" based on the "build" stage.
FROM build AS publish

# Publish the application, which includes compiling the application, copying the output files and dependencies to the publish directory, and creating a .runtimeconfig.json configuration file.
RUN dotnet publish "Blazor-Automated-Email-Marketing-System.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Create a new stage named "final" based on the "base" stage.
FROM base AS final

# Set the working directory in the "final" stage to /app.
WORKDIR /app

# Copy the published application from the "publish" stage to the "final" stage.
COPY --from=publish /app/publish .

# Set the command that will be run when the Docker container is started using the dotnet command.
ENTRYPOINT ["dotnet", "Blazor-Automated-Email-Marketing-System.dll"]
