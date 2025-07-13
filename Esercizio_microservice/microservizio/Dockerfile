#creiamo l'ambiente di build

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS Build
WORKDIR /src

#copiamo i sorgenti
COPY . .

#ripristiniamo e pubblichiamo in modalità Release
RUN dotnet publish -c Release -o /app/publish

#creiamo ambiente di Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

#copiamo l'app pubblicata dall'ambiente precedente 
COPY --from=build /app/publish .

EXPOSE 8080
ENTRYPOINT ["dotnet", "microservizio.dll"]
