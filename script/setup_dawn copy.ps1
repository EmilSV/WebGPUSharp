param (
    [uint32]$chromiumVersion = 6544,
    [switch]$build = $false
)

$installDir = (get-item $PSScriptRoot).FullName

$versionText = @"
MAJOR=1
MINOR=0
BUILD=0
PATCH=0
"@

Write-Host "Setting up Dawn in $installDir"

# make it more windows friendly
$env:DEPOT_TOOLS_WIN_TOOLCHAIN = 0

Set-Location $installDir

$lastProgressPreference = $ProgressPreference
$ProgressPreference = 'SilentlyContinue'

# Download depot_tools
if (!(Test-Path "depot_tools")) {
    Write-Host "depot_tools not found, downloading..."
    
    Invoke-WebRequest -Uri "https://storage.googleapis.com/chrome-infra/depot_tools.zip" -OutFile "depot_tools.zip"
    
    Clear-Host

    Write-Host "depot_tools downloaded, extracting..."

    Expand-Archive -Path "depot_tools.zip" -DestinationPath "depot_tools"
    Remove-Item "depot_tools.zip"

    Clear-Host

    Write-Host "depot_tools extracted, setting up..."

    $env:Path = (Join-Path $installDir "depot_tools") + ";" + $env:Path
    gclient
    python -m pip install pywin32
}
else {
    $env:Path = (Join-Path $installDir "depot_tools") + ";" + $env:Path
}

# download dawn
if (!(Test-Path "dawn")) {
    Write-Host "dawn not found, downloading..."
    git clone -b "chromium/$chromiumVersion" https://dawn.googlesource.com/dawn 

    Clear-Host

    Write-Host "dawn downloaded, setting up..."

    New-Item -Path (Join-Path $installDir "dawn/chrome/VERSION") -ItemType File -Force
    Set-Content -Path (Join-Path $installDir "dawn/chrome/VERSION") -Value $versionText

    Set-Location (Join-Path $installDir "dawn")
    Copy-Item scripts\standalone.gclient .gclient
    gclient sync
}
else {
    Set-Location (Join-Path $installDir "dawn")
}

Clear-Host
Write-Host "Dawn READY!"
$ProgressPreference = $lastProgressPreference


if (!$build) {
    exit
}


# build dawn
$lastProgressPreference = $ProgressPreference
$ProgressPreference = 'SilentlyContinue'

Write-Host "Building Dawn..."


$gnGenArgs = -join (
    "`"",
    "is_clang = true ",  
    "is_debug = false ", 
    "strip_debug_info=true ", 
    "symbol_level=0 ", 
    "dawn_use_angle=false ", 
    "dawn_use_swiftshader=false ", 
    "use_custom_libcxx = false ", 
    "dawn_use_built_dxc = false ", 
    "dawn_complete_static_libs = true ", 
    "chrome_pgo_phase = 0 ", 
    "treat_warnings_as_errors = false ", 
    "is_official_build = true ",
    "`""
);


gn gen out/Release --args=$gnGenArgs
ninja -C out\Release webgpu_dawn_shared


