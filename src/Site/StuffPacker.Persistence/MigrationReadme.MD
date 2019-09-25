

## Upgrade
### öppna cmd/powershell gå till 
cd src\Site\StuffPacker.Persistence;
### skriv in men byt ut "Initial" mot eget namn
dotnet ef migrations add Inital -s ..\StuffPacker.Persistence.Tests\StuffPacker.Persistence.Tests.csproj

## Remove
cd src\Site\StuffPacker.Persistence;
 dotnet ef migrations remove -s ..\StuffPacker.Persistence.Tests\StuffPacker.Persistence.Tests.csproj

## DownGrade
cd src\Site\StuffPacker.Persistence;
dotnet ef database update 0 -s ..\StuffPacker.Persistence.Tests\StuffPacker.Persistence.Tests.csproj
