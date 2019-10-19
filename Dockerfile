FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /app 
COPY . ./
RUN dotnet publish -c Release -o ../../out Sistem.Antrian/Sistem.Antrian.csproj

FROM mcr.microsoft.com/dotnet/core/runtime:3.0
WORKDIR /app
COPY --from=build /app/out . 
CMD ASPNETCORE_URLS=http://*:$PORT dotnet Sistem.Antrian.dll
