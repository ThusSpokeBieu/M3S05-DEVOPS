FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Flight.Application/Flight.Application.csproj", "Flight.Application/"]
RUN dotnet restore "Flight.Application/Flight.Application.csproj"
COPY . .
WORKDIR "/src/Flight.Application"
RUN dotnet build "Flight.Application.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Flight.Application.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Flight.Application.dll"]
