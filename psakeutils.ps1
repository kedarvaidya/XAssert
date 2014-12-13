function Generate-Assembly-Info{

param(
    [string]$file = $(throw "file is a required parameter."),
	[string]$title,
	[string]$description,
    [string]$configuration,
    [string]$company, 
	[string]$product, 
	[string]$copyright,
    [string]$trademark,   
    [string]$culture,  
	[string]$internalsVisibleTo = "",
	[string]$version,
	[string]$fileVersion = "",
	[string]$infoVersion = ""
)
    if($fileVersion -eq ""){
		$fileVersion = $version
	}
	if($infoVersion -eq ""){
		$infoVersion = $fileVersion
	}

	$asmInfo = "using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;
using System.Runtime.CompilerServices;

[assembly: AssemblyTitle(""$title"")]
[assembly: AssemblyDescription(""$description"")]
[assembly: AssemblyConfiguration(""$configuration"")]
[assembly: AssemblyCompany(""$company"")]
[assembly: AssemblyProduct(""$product"")]
[assembly: AssemblyCopyright(""$copyright"")]
[assembly: AssemblyTrademark(""$trademark"")]
[assembly: AssemblyCulture(""$culture"")]	
"

	if($internalsVisibleTo -ne ""){
		$asmInfo += "[assembly: InternalsVisibleTo(""$internalsVisibleTo"")]
"	
	}

    $asmInfo += "
[assembly: AssemblyVersion(""$version"")]
[assembly: AssemblyFileVersion(""$fileVersion"")]
[assembly: AssemblyInformationalVersion(""$infoVersion"")]    
"

	$dir = [System.IO.Path]::GetDirectoryName($file)

	if ([System.IO.Directory]::Exists($dir) -eq $false)
	{
		Write-Host "Creating directory $dir"
		[System.IO.Directory]::CreateDirectory($dir)
	}
	Write-Host "Generating assembly info file: $file"
	Write-Output $asmInfo > $file
}