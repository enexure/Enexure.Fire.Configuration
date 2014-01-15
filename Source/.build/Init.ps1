param([String]$Name) 

$ErrorActionPreference = "Stop"
$ProjectName = $Name

function Get-CurrentDirectoryName
{
	return Split-Path $pwd -Leaf
}

function ResolveMsBuildPath()
{
	$root = "C:\Windows\Microsoft.NET\"

	if (Test-Path "$root\Framework64") {
		$root = "$root\Framework64"
	} else {
		$root = "$root\Framework"
	}

	$item = Get-ChildItem "$root\v*" | Sort -Descending | Select -First 1
	
	return Resolve-Path $item.FullName
}

function ResolveNuGetPath()
{
	return Resolve-Path ".nuget\"
}

function Build-Solution
{
	msbuild "$ProjectName.sln"
}

function Build-Package()
{
	$BasePath = "$SolutionDir\$ProjectName"
	$ArtifactsPath = "$SolutionDir\.artifacts"

	if (!(Test-Path $ArtifactsPath)) {
		New-Item $ArtifactsPath -Type Directory
	}

	msbuild "$ProjectName.sln" /property:Configuration=Release

	#-BasePath $BasePath
	$ProjectFile = "$BasePath\$ProjectName.csproj"

	Write-Host "Packing: $ProjectFile"
	$Output = nuget pack $ProjectFile -OutputDirectory $ArtifactsPath -Prop "Configuration=Release"
	$LastLine = $Output[-1]

	$EndIndex = $LastLine.LastIndexOf("\") + 1;

	$FileName = $LastLine.SubString($EndIndex, $LastLine.Length - $EndIndex - 2);

	Write-Host "Package $FileName created"
}

function Upload-Package()
{
	$ArtifactsPath = "$SolutionDir\.artifacts"
	
	$package = Get-ChildItem $ArtifactsPath | Sort -Descending | Select -First 1
	
	$KeyPath = "$SolutionDir\.build\api-key.txt"
	
	$PackagePath = $package.FullName
	
	Write-Host "Uploading $PackagePath"
	
	if (Test-Path $KeyPath) {

		$ApiKey = Get-Content $KeyPath

		#Write-Host  (Test-Path $PackagePath)
		
		nuget push -ApiKey $ApiKey $PackagePath
		
	} else {
		Write-Warning "You need an API Key to upload"
	}
	
}

#Init

Write-Host "PWD is $(Get-CurrentDirectoryName)"
if ((Get-CurrentDirectoryName) -ne "Source")
{
	Write-Error "Scripts must be executed from the root of the Solution"
	return
}

$SolutionDir = Resolve-Path .

$NuGetPath = ResolveNuGetPath
$MsBuildPath = ResolveMsBuildPath

Write-Host "NuGet: $NuGetPath"
Write-Host "MsBuild: $MsBuildPath"

$env:Path += ";$MsBuildPath"
$env:Path += ";$NuGetPath"