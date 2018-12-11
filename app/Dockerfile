FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.sln .
COPY scheduler/*.csproj ./scheduler/
COPY web/*.csproj ./web/
COPY DAL/*.csproj ./DAL/
RUN dotnet restore

# copy everything else and build app
COPY scheduler/. ./scheduler/
COPY web/. ./web/
COPY DAL/. ./DAL/
RUN dotnet publish -c Release -o out

#FROM microsoft/dotnet:2.2-aspnetcore-runtime AS runtime
ENTRYPOINT ["dotnet", "web/out/web.dll"]