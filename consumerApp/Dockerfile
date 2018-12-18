FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /consumerApp

# copy csproj and restore as distinct layers
COPY *.sln .
COPY Scheduler/*.csproj ./Scheduler/
COPY DAL/*.csproj ./DAL/
COPY Consumer/*.csproj ./Consumer/
RUN dotnet restore

# copy everything else and build app
COPY Scheduler/. ./Scheduler/
COPY DAL/. ./DAL/
COPY Consumer/. ./Consumer/
RUN dotnet publish -c Release -o out
RUN ls
#FROM microsoft/dotnet:2.2-aspnetcore-runtime AS runtime
ENTRYPOINT ["dotnet", "Consumer/out/Consumer.dll"]