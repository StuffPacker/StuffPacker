## Install
### Open cmd/powershell 
dotnet tool install --global dotnet-ef

## Upgrade
### Open cmd/powershell go to
cd src\Site\StuffPacker.Persistence;
### Copy row below and replace  "Initial" to a new name
dotnet ef migrations add Inital -s ..\StuffPacker.Persistence.Tests\StuffPacker.Persistence.Tests.csproj

## Remove
cd src\Site\StuffPacker.Persistence;
 dotnet ef migrations remove -s ..\StuffPacker.Persistence.Tests\StuffPacker.Persistence.Tests.csproj

## DownGrade
cd src\Site\StuffPacker.Persistence;
dotnet ef database update 0 -s ..\StuffPacker.Persistence.Tests\StuffPacker.Persistence.Tests.csproj
