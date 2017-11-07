FROM microsoft/aspnetcore:2.0
WORKDIR /app
COPY ./bin/Debug/netcoreapp2.0/publish /app
ENV ASPNETCORE_URLS http://*:3333

CMD ["dotnet", "PDX.PBOT.App.API.dll"]