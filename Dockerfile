#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 83
ENV ASPNETCORE_URLS=http://+:83

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Test_Process_API/Test_Process_API.csproj", "Test_Process_API/"]
COPY ["Test_Process_Services/Test_Process_Services.csproj", "Test_Process_Services/"]
RUN dotnet restore "Test_Process_API/Test_Process_API.csproj"
COPY . .
WORKDIR "/src/Test_Process_API"
RUN dotnet build "Test_Process_API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Test_Process_API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Test_Process_API.dll"]