FROM mcr.microsoft.com/dotnet/sdk:7.0 as build
WORKDIR /app
COPY . .
RUN dotnet restore
RUN dotnet publish -o /app/published-app

FROM mcr.microsoft.com/dotnet/aspnet:7.0 as runtime
WORKDIR /app
EXPOSE 5100
COPY --from=build /app/published-app /app
ENV ASPNETCORE_URLS=http://+:5100
ENV CONECTION_STRING = ${CONECTION_STRING}
ENTRYPOINT ["dotnet", "CCPSA_WS.dll"]
