Import-Module "$PSScriptRoot\modules\msbuild\Invoke-MsBuild.psm1"

$nuget = "$PSScriptRoot\nuget\nuget.exe"

properties {
	$solutionDir = Resolve-Path "$PSScriptRoot\.."
}

task default -depends Package

task Package -depends Compile, Clean { 
	#& $nuget pack 
}

task Compile -depends Version, Clean { 
	Write-Host "Version: $Version"
<<<<<<< HEAD
	$solutionPath = "$solutionDir\Enexure.Sql.Dynamic.sln"
=======
	$solutionPath = "$solutionDir\Enexure.Fire.Configuration.sln"
>>>>>>> Project restructure with appveyor support
	Invoke-MsBuild $solutionPath -MSBuildProperties @{ Configuration = "Release" }
}

task Version -depends Clean {

<<<<<<< HEAD
	$versionSourceFile = "$solutionDir\src\Enexure.Sql.Dynamic\Version.json"
=======
	$versionSourceFile = "$solutionDir\src\Enexure.Fire.Configuration\Version.json"
>>>>>>> Project restructure with appveyor support
	$versionSourceFileContents = [string](Get-Content $versionSourceFile)
	$versionDetail = ConvertFrom-Json $versionSourceFileContents
	$version = "$($versionDetail.Major).$($versionDetail.Minor).$($versionDetail.Patch).$build"

	Write-Host "Version: $version"
	
<<<<<<< HEAD
	$projectDir = "$solutionDir\src\Enexure.Sql.Dynamic\Properties"
=======
	$projectDir = "$solutionDir\src\Enexure.Fire.Configuration\Properties"
>>>>>>> Project restructure with appveyor support
	$versionFile = "$projectDir\AssemblyVersion.cs"

	# Version information for an assembly consists of the following four values:
	# 
	#      Major Version
	#      Minor Version 
	#      Build Number
	#      Revision
	# 
	# You can specify all the values or you can default the Build and Revision Numbers 
	# by using the '*' as shown below:
	# [assembly: AssemblyVersion("1.0.*")]
	
	$versionFileContents = 
	"using System.Reflection;" + "`n" +
	"[assembly: AssemblyVersion(`"$version`")]" + "`n" +
	"[assembly: AssemblyFileVersion(`"$version`")]"

	Set-Content $versionFile $versionFileContents
}

task Clean { 
	
}

task ? -Description "Helper to display task info" {
	Write-Documentation
}