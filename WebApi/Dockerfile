#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["WebApi/WebApi.csproj", "WebApi/"]
COPY ["Persistence/Persistence.csproj", "Persistence/"]
COPY ["Application/Application.csproj", "Application/"]
COPY ["Domain/Domain.csproj", "Domain/"]
COPY ["RentACar-Core.Packages/Core.Application/Core.Application.csproj", "RentACar-Core.Packages/Core.Application/"]
COPY ["RentACar-Core.Packages/Core.CrossCuttingConcerns/Core.CrossCuttingConcerns.csproj", "RentACar-Core.Packages/Core.CrossCuttingConcerns/"]
COPY ["RentACar-Core.Packages/Core.Persistence/Core.Persistence.csproj", "RentACar-Core.Packages/Core.Persistence/"]
RUN dotnet restore "WebApi/WebApi.csproj"
COPY . .
WORKDIR "/src/WebApi"
RUN dotnet build "WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebApi.csproj" -c Release -o /app/publish 

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebApi.dll"]