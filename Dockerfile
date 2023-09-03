#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Fiap.Noticias.API/Fiap.Noticias.API.csproj", "Fiap.Noticias.API/"]
COPY ["Fiap.Noticias.CrossCutting.IoC/Fiap.Noticias.CrossCutting.IoC.csproj", "Fiap.Noticias.CrossCutting.IoC/"]
COPY ["Fiap.Noticias.CrossCutting/Fiap.Noticias.CrossCutting.csproj", "Fiap.Noticias.CrossCutting/"]
COPY ["Fiap.Noticias.Domain/Fiap.Noticias.Domain.csproj", "Fiap.Noticias.Domain/"]
COPY ["Fiap.Noticias.Infra.Data/Fiap.Noticias.Infra.Data.csproj", "Fiap.Noticias.Infra.Data/"]
COPY ["Fiap.Noticias.Service/Fiap.Noticias.Service.csproj", "Fiap.Noticias.Service/"]
RUN dotnet restore "Fiap.Noticias.API/Fiap.Noticias.API.csproj"
COPY . .
WORKDIR "/src/Fiap.Noticias.API"
RUN dotnet build "Fiap.Noticias.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Fiap.Noticias.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Fiap.Noticias.API.dll"]