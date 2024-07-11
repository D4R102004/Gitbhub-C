Write-Host "Starting build process"
dotnet build
dotnet test .\Dar.Tests\Dar.Tests.csproj

dotnet run --project .\Compiled\Compiled.csproj
