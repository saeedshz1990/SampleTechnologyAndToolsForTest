FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY ["UI/SampleTechnologyForTest.RestApi/SampleTechnologyForTest.RestApi.csproj", "UI/SampleTechnologyForTest.RestApi/"]
COPY ["Application/Command.Application/Command.Application.csproj", "Application/Command.Application/"]
COPY ["Application/Query.Application/Query.Application.csproj", "Application/Query.Application/"]
COPY ["Domain/SampleTechnologyForTest.Entities/SampleTechnologyForTest.Entities.csproj", "Domain/SampleTechnologyForTest.Entities/"]
COPY ["Infrastructure/SampleTechnologyForTest.Infrastructure/SampleTechnologyForTest.Infrastructure.csproj", "Infrastructure/SampleTechnologyForTest.Infrastructure/"]
COPY ["Infrastructure/SampleTechnologyForTest.Logging/SampleTechnologyForTest.Logging.csproj", "Infrastructure/SampleTechnologyForTest.Logging/"]
COPY ["Persistence/Command.Persistence/Command.Persistence.csproj", "Persistence/Command.Persistence/"]
COPY ["Persistence/Query.Persistence/Query.Persistence.csproj", "Persistence/Query.Persistence/"]
COPY ["Common/SampleTechnologyForTest.Common/SampleTechnologyForTest.Common.csproj", "Common/SampleTechnologyForTest.Common/"]

RUN dotnet restore "UI/SampleTechnologyForTest.RestApi/SampleTechnologyForTest.RestApi.csproj"

COPY . .

WORKDIR "/src/UI/SampleTechnologyForTest.RestApi"

RUN dotnet publish "SampleTechnologyForTest.RestApi.csproj" \
    -c Release \
    -o /app/publish \
    /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "SampleTechnologyForTest.RestApi.dll"]