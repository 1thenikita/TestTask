FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["TestTask.ConsoleApp/TestTask.ConsoleApp.csproj", "TestTask.ConsoleApp/"]
RUN dotnet restore "TestTask.ConsoleApp/TestTask.ConsoleApp.csproj"
COPY . .
WORKDIR "/src/TestTask.ConsoleApp"
RUN dotnet build "TestTask.ConsoleApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TestTask.ConsoleApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TestTask.ConsoleApp.dll"]
