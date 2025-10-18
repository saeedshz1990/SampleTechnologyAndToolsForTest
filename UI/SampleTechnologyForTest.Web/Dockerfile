# ایمیج پایه برای اجرای اپلیکیشن
FROM  mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER app
WORKDIR  /app
EXPOSE 5000
EXPOSE 5001
ENV ASPNETCORE_URLS=http://+:5000

# بیلد و کامپایل پروژه
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["SampleTechnologyForTest.sln", "."]
COPY ["SampleTechnologyForTest.Web/SampleTechnologyForTest.Web.csproj", "SampleTechnologyForTest.Web/"]
COPY ["SampleTechnologyForTest.Application/SampleTechnologyForTest.Command.Application.csproj", "SampleTechnologyForTest.Application/"]
COPY ["SampleTechnologyForTest.Application/SampleTechnologyForTest.Query.Application.csproj", "SampleTechnologyForTest.Application/"]
COPY ["SampleTechnologyForTest.Domain/SampleTechnologyForTest.Domain.csproj", "SampleTechnologyForTest.Domain/"]
COPY ["SampleTechnologyForTest.Infrastructure/SampleTechnologyForTest.Infrastructure.csproj", "SampleTechnologyForTest.Infrastructure/"]
RUN dotnet restore "SampleTechnologyForTest.sln"
COPY . .
RUN dotnet build "SampleTechnologyForTest.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build


#مرحله پابلیش برای ایجاد فایل نهایی
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./SampleTechnologyForTest.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# ایمیج نهایی برای اجرای اپلیکیشن
FROM base AS final
WORKDIR  /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SampleTechnologyForTest.Web.dll"]