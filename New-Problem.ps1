<#
.SYNOPSIS
    新しいLeetCode問題フォルダを作成し、.csprojを配置してソリューションに登録する。

.EXAMPLE
    ./New-Problem.ps1 -Category Heap -Name 1046_LastStoneWeight
#>
param(
    [Parameter(Mandatory = $true)]
    [string]$Category,

    [Parameter(Mandatory = $true)]
    [string]$Name
)

$ErrorActionPreference = "Stop"

$repoRoot = $PSScriptRoot
$slnPath = Join-Path $repoRoot "arai60.slnx"
$dir = Join-Path $repoRoot "$Category\$Name"

if (Test-Path $dir) {
    throw "既にフォルダが存在します: $dir"
}

New-Item -ItemType Directory -Path $dir | Out-Null

$csprojPath = Join-Path $dir "$Name.csproj"
@'
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Library</OutputType>
    <TargetFramework>net10.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>

</Project>
'@ | Set-Content -Path $csprojPath -Encoding utf8

$mainPath = Join-Path $dir "Main.cs"
@'
public class Solution
{
}
'@ | Set-Content -Path $mainPath -Encoding utf8

dotnet sln $slnPath add $csprojPath | Out-Null

Write-Host "作成しました: $dir"
