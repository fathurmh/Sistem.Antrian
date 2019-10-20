FROM microsoft/dotnet:2.2-sdk AS build-env
WORKDIR /app 
COPY . ./
RUN dotnet publish -c Release -o out Sistem.Antrian/Sistem.Antrian.csproj

FROM microsoft/dotnet:2.2-aspnetcore-runtime
WORKDIR /app
COPY --from=build-env /app/out . 
CMD ASPNETCORE_URLS=http://*:$PORT dotnet Sistem.Antrian.dll
