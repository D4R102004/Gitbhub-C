Write-Host "Starting build process"
dotnet build
dotnet test .\Dar.Tests\Dar.Tests.csproj
