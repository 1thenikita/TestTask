FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["TestTask.WebAPI/TestTask.WebAPI.csproj", "TestTask.WebAPI/"]
RUN dotnet restore "TestTask.WebAPI/TestTask.WebAPI.csproj"
COPY . .
WORKDIR "/src/TestTask.WebAPI"
RUN dotnet build "TestTask.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TestTask.WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TestTask.WebAPI.dll"]
