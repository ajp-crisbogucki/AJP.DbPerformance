FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["DbPerformance/DbPerformance.csproj", "DbPerformance/"]
RUN dotnet restore "DbPerformance/DbPerformance.csproj"
COPY . .
WORKDIR "/src/DbPerformance"
RUN dotnet build "DbPerformance.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DbPerformance.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DbPerformance.dll"]
