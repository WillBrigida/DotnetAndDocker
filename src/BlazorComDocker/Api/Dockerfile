
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base

Label version="1.0"

COPY dist /app

WORKDIR /app

EXPOSE 80/tcp

ENTRYPOINT ["dotnet", "Api.dll"]
