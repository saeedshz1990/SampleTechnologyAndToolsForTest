FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["UI/SampleTechnologyForTest.BlazorServer/SampleTechnologyForTest.BlazorServer.csproj", "UI/SampleTechnologyForTest.BlazorServer/"]
RUN dotnet restore "UI/SampleTechnologyForTest.BlazorServer/SampleTechnologyForTest.BlazorServer.csproj"
COPY . .
WORKDIR "/src/UI/SampleTechnologyForTest.BlazorServer"
RUN dotnet build "./SampleTechnologyForTest.BlazorServer.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./SampleTechnologyForTest.BlazorServer.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SampleTechnologyForTest.BlazorServer.dll"]
