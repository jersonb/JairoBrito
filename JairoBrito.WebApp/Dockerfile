#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["JairoBrito.WebApp/JairoBrito.WebApp.csproj", "JairoBrito.WebApp/"]
RUN dotnet restore "JairoBrito.WebApp/JairoBrito.WebApp.csproj"
COPY . .
WORKDIR "/src/JairoBrito.WebApp"
RUN dotnet build "JairoBrito.WebApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "JairoBrito.WebApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "JairoBrito.WebApp.dll"]