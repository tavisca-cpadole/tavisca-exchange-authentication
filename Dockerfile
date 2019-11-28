FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-nanoserver-1803
WORKDIR /app
COPY . .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet ./src/AuthenticationPortal.Web/bin/Release/netcoreapp3.0/publish/AuthenticationPortal.Web.dll
