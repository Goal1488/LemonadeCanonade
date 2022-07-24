FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Lemonade.Api/Lemonade.Api.csproj", "Lemonade.Api/"]
RUN dotnet restore "Lemonade.Api/Lemonade.Api.csproj"
COPY . .
WORKDIR "/src/Lemonade.Api"
RUN dotnet build "Lemonade.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Lemonade.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Lemonade.Api.dll"]
