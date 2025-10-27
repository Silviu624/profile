FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY Profile.Core.sln ./
COPY Profile.Application/ ./Profile.Application/
COPY Profile.Core/        ./Profile.Core/
COPY Profile.Domain/      ./Profile.Domain/
COPY Profile.Infrastructure/ ./Profile.Infrastructure/

WORKDIR /src/Profile.Core
RUN dotnet restore Profile.Core.csproj
RUN dotnet publish Profile.Core.csproj -c Release -o /app/publish


FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app


ENV ASPNETCORE_URLS=http://+:8080
ENV ASPNETCORE_ENVIRONMENT=Production
EXPOSE 8080

COPY --from=build /app/publish ./
ENTRYPOINT ["dotnet", "Profile.Core.dll"]
