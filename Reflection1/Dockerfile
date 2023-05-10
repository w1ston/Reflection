FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Reflection1/Reflection1.csproj", "Reflection1/"]
RUN dotnet restore "Reflection1/Reflection1.csproj"
COPY . .
WORKDIR "/src/Reflection1"
RUN dotnet build "Reflection1.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Reflection1.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Reflection1.dll"]
