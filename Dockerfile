# ---------- Build stage ----------
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy solution and restore
COPY *.sln .
COPY Co-ParentingApp.API/*.csproj Co-ParentingApp.API/
COPY Co-ParentingApp.Application/*.csproj Co-ParentingApp.Application/
COPY Co-ParentingApp.Infrastructure/*.csproj Co-ParentingApp.Infrastructure/
COPY Co-ParentingApp.Data/*.csproj Co-ParentingApp.Data/

RUN dotnet restore

# Copy everything and publish
COPY . .
RUN dotnet publish Co-ParentingApp.API -c Release -o /app/publish

# ---------- Runtime stage ----------
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .

# Render uses port 10000
ENV ASPNETCORE_URLS=http://+:10000
EXPOSE 10000

ENTRYPOINT ["dotnet", "Co-ParentingApp.API.dll"]
