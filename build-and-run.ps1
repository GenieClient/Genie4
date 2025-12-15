# Build and Run Script for Genie5
# This script builds the project and copies output to a separate Run folder
# so you can keep Genie running while developing

$ErrorActionPreference = "Stop"

$BuildConfig = "Release"
$TargetFramework = "net10.0-windows"
$SourceDir = "src\Genie.Windows\bin\$BuildConfig\$TargetFramework"
$RunDir = "bin\Run"

Write-Host "Building Genie5..." -ForegroundColor Cyan
dotnet build Genie5.sln --configuration $BuildConfig

if ($LASTEXITCODE -ne 0) {
    Write-Host "Build failed!" -ForegroundColor Red
    exit 1
}

Write-Host "Build successful!" -ForegroundColor Green

# Create Run directory if it doesn't exist
if (!(Test-Path $RunDir)) {
    New-Item -ItemType Directory -Path $RunDir | Out-Null
    Write-Host "Created $RunDir directory" -ForegroundColor Yellow
}

# Copy all files to Run folder
Write-Host "Copying files to $RunDir..." -ForegroundColor Cyan
Copy-Item -Path "$SourceDir\*" -Destination $RunDir -Recurse -Force

Write-Host "Files copied to $RunDir" -ForegroundColor Green
Write-Host ""
Write-Host "To run Genie, use:" -ForegroundColor White
Write-Host "  .\bin\Run\Genie.exe" -ForegroundColor Yellow
Write-Host ""

# Ask if user wants to run
$run = Read-Host "Run Genie now? (y/n)"
if ($run -eq "y" -or $run -eq "Y") {
    Write-Host "Starting Genie..." -ForegroundColor Cyan
    Start-Process "$RunDir\Genie.exe"
}

