FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["TCPPractice1/TCPPractice1.csproj", "TCPPractice1/"]
RUN dotnet restore "TCPPractice1/TCPPractice1.csproj"
COPY . .
WORKDIR "/src/TCPPractice1"
RUN dotnet build "TCPPractice1.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TCPPractice1.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TCPPractice1.dll"]
