FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["src/Callcenter.Backend.Api/Callcenter.Backend.Api.csproj", "Callcenter.Backend.Api/"]
COPY ["src/Callcenter.Backend.Application/Callcenter.Backend.Application.csproj", "Callcenter.Backend.Application/"]
COPY ["src/Callcenter.Backend.Domain/Callcenter.Backend.Domain.csproj", "Callcenter.Backend.Domain/"]
COPY ["src/Callcenter.Backend.Contracts/Callcenter.Backend.Contracts.csproj", "Callcenter.Backend.Contracts/"]
COPY ["src/Callcenter.Backend.Infrastructure/Callcenter.Backend.Infrastructure.csproj", "Callcenter.Backend.Infrastructure/"]
COPY ["Directory.Packages.props", "./"]
COPY ["Directory.Build.props", "./"]
RUN dotnet restore "Callcenter.Backend.Api/Callcenter.Backend.Api.csproj"
COPY . ../
WORKDIR /src/Callcenter.Backend.Api
RUN dotnet build "Callcenter.Backend.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish --no-restore -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0
ENV ASPNETCORE_HTTP_PORTS=5001
EXPOSE 5001
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Callcenter.Backend.Api.dll"]