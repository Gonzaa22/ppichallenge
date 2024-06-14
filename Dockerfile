#Build Stage

FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /source
COPY . .
RUN dotnet restore "./PPIChallengeAPI/PPIChallengeAPI.csproj" --disable-parallel
RUN dotnet publish "./PPIChallengeAPI/PPIChallengeAPI.csproj" -c release -o /app --no-retore



#Serve Stage
FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal
WORKDIR /app
COPY --from=build /app ./

EXPOSE 5000

ENTRYPOINT ["dotnet", "PPIChallengeAPI.dll"]