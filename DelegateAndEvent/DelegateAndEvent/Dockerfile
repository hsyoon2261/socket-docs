FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["DelegateAndEvent/DelegateAndEvent.csproj", "DelegateAndEvent/"]
RUN dotnet restore "DelegateAndEvent/DelegateAndEvent.csproj"
COPY . .
WORKDIR "/src/DelegateAndEvent"
RUN dotnet build "DelegateAndEvent.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DelegateAndEvent.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DelegateAndEvent.dll"]
