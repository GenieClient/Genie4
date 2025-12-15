# Quick Build Script for Genie4
# Builds and copies to Run folder (no prompts)

$BuildConfig = "Release"
$TargetFramework = "net10.0-windows"
$SourceDir = "bin\$BuildConfig\$TargetFramework"
$RunDir = "bin\Run"

Write-Host "Building Genie4..." -ForegroundColor Cyan
dotnet build Genie4.sln --configuration $BuildConfig

if ($LASTEXITCODE -ne 0) {
    Write-Host "Build failed!" -ForegroundColor Red
    exit 1
}

if (!(Test-Path $RunDir)) {
    New-Item -ItemType Directory -Path $RunDir | Out-Null
}

Copy-Item -Path "$SourceDir\*" -Destination $RunDir -Recurse -Force
Write-Host "Build complete! Run with: .\bin\Run\Genie.exe" -ForegroundColor Green

