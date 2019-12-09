#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["MyBudget.WebUI/MyBudget.WebUI.csproj", "MyBudget.WebUI/"]
COPY ["MyBudget.Domain/MyBudget.Domain.csproj", "MyBudget.Domain/"]
COPY ["MyBudget.DAL/MyBudget.DAL.csproj", "MyBudget.DAL/"]
RUN dotnet restore "MyBudget.WebUI/MyBudget.WebUI.csproj"
COPY . .
WORKDIR "/src/MyBudget.WebUI"
RUN dotnet build "MyBudget.WebUI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MyBudget.WebUI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyBudget.WebUI.dll"]