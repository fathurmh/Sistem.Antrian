FROM microsoft/dotnet:2.2-sdk AS build-env
WORKDIR /app 
COPY . ./
RUN dotnet publish -c Release -o ../out Simantri/Simantri.csproj

FROM microsoft/dotnet:2.2-aspnetcore-runtime
WORKDIR /app
COPY --from=build-env /app/out . 
CMD ASPNETCORE_URLS=http://*:$PORT dotnet Simantri.dll
