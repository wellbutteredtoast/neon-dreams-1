$RELEASE = "release/"
$BIN = "bin/release/net9.0/win-x64/"
$ASSETS = "assets/"

# Lua 5.4 is required
$ErrorActionPreference = "Stop"

Remove-Item $RELEASE -Force -Recurse -Confirm:$false

dotnet build --ucr -c Release -v diag
if (-not (Test-Path $RELEASE)) {
    New-Item -ItemType Directory -Path $RELEASE | Out-Null
}
Copy-Item -Path $ASSETS -Destination $RELEASE -Recurse
Copy-Item -Path "$BIN*" -Destination $RELEASE -Recurse

# Remove unnecessary files from the release directory
Get-ChildItem -Path $RELEASE -Filter *.pdb -File | Remove-Item -Force
lua54 manifest-tool.lua -maj 1 -min 0 -ptc 1 -stg PRE-ALPHA
Copy-Item -Path "manifest.json" -Destination $RELEASE
Write-Host "NeonDreams build is ready."
