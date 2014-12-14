properties {
    $base_dir  = resolve-path .
    $src_dir = "$base_dir\src"
    $test_dir = "$base_dir\test"
    $build_dir = "$base_dir\build"
    $release_dir = "$base_dir\release"
    $packages_dir = "$base_dir\packages"
    $tools_dir = "$base_dir\tools\"
    $nuget_path = "$tools_dir\nuget\NuGet.exe"
    $version = "1.0.0.0"
    $nuget_package_version = "1.0.0-pre1"
    $config = 'Release'
    $run_tests = $true

    $id_core = "XAssert.Core"
    $id_should = "XAssert.Should"
    $id_expect = "XAssert.Expect"
    $id_test = "XAssert.Tests"
    $description_core = "XAssert is a test runner agnostic assertion framework for .NET. It is set of portable class libraries compatible with .NET 4+, Silverlight 5+, Windows 8+ and Windows Phone 8+"
    $description_should = "Should flavor for XAssert"
    $description_expect = "Expect flavor for XAssert"
    $description_test = "Tests for XAssert"
    $author = "Kedar Vaidya"
    $start_year = 2014
    $curr_year = (Get-Date).ToUniversalTime().Year
    $copyright_year_suffix = if ($start_year -eq $curr_year) { "" } else { "-$curr_year" }
    $copyright = "Copyright " + [char]0x00A9 + " $author $start_year$copyright_year_suffix"
    $projectUrl = "https://github.com/kedarvaidya/XAssert"
    $licenseUrl = "https://github.com/kedarvaidya/XAssert/blob/master/LICENSE"
}

include .\psakeutils.ps1

task default -depends Compile, Test

task Clean {
  remove-item -force -recurse $build_dir -ErrorAction SilentlyContinue
  remove-item -force -recurse $release_dir -ErrorAction SilentlyContinue
}

task Init -depends Clean {
    Generate-Assembly-Info `
        -file "$src_dir\XAssert.Core\Properties\AssemblyInfo.cs" `
        -title "$id_core $version" `
        -description $description_core `
        -company $author `
        -product "$id_core $version" `
        -version $version `
        -copyright $copyright

    Generate-Assembly-Info `
        -file "$src_dir\XAssert.Should\Properties\AssemblyInfo.cs" `
        -title "$id_should $version" `
        -description $description_should `
        -company $author `
        -product "$id_should $version" `
        -version $version `
        -copyright $copyright

    Generate-Assembly-Info `
        -file "$src_dir\XAssert.Expect\Properties\AssemblyInfo.cs" `
        -title "$id_expect $version" `
        -description $description_expect `
        -company $author `
        -product "$id_expect $version" `
        -version $version `
        -copyright $copyright

    Generate-Assembly-Info `
        -file "$test_dir\XAssert.Tests\Properties\AssemblyInfo.cs" `
        -title "$id_test $version" `
        -description $description_test `
        -company $author `
        -product "$id_test $version" `
        -version $version `
        -copyright $copyright

    new-item $build_dir -itemType directory
    new-item $release_dir -itemType directory
}

task PackageRestore {
    & "$nuget_path" restore
}

task Compile -depends Init, PackageRestore {
    msbuild "$src_dir\XAssert.Core\XAssert.Core.csproj" /target:Rebuild /p:"OutDir=$build_dir\XAssert.Core;Configuration=$config"
    msbuild "$src_dir\XAssert.Should\XAssert.Should.csproj" /target:Rebuild /p:"OutDir=$build_dir\XAssert.Should;Configuration=$config"
    msbuild "$src_dir\XAssert.Expect\XAssert.Expect.csproj" /target:Rebuild /p:"OutDir=$build_dir\XAssert.Expect;Configuration=$config"
    msbuild "$test_dir\XAssert.Tests\XAssert.Tests.csproj" /target:Rebuild /p:"OutDir=$build_dir\XAssert.Tests;Configuration=$config"
}

task Test -depend Compile -precondition { return $run_tests } {
    $xunit_paths = Get-ChildItem -Path $packages_dir -Filter "xunit.console.exe" -Recurse
    if($xunit_paths.Count -eq 0)
    {
        Write-Host "Could not find xunit.console.exe in $packages_dir"
    }
    elseif($xunit_paths.Count -gt 1)
    {
        Write-Host "Found more than 1 xunit.console.exe in $packages_dir"
    }
    else
    {
        $xunit_path = $xunit_paths[0].FullName
        & "$xunit_path" "$build_dir\XAssert.Tests\XAssert.Tests.dll"
        if($lastexitcode -ne 0)
        {
            throw "$lastexitcode tests failed"
        }
    }
}

task Pack -depends Compile, Test {
    & "$nuget_path" pack "$base_dir\src\XAssert.Core\XAssert.Core.nuspec" `
        -o $release_dir `
        -Version $nuget_package_version `
        -BasePath "$build_dir\XAssert.Core\" `
        -Properties "id=$id_core;author=$author;description=$description_core;copyright=$copyright;projectUrl=$projectUrl;licenseUrl=$licenseUrl"

    & "$nuget_path" pack "$base_dir\src\XAssert.Should\XAssert.Should.nuspec" `
        -o $release_dir `
        -Version $nuget_package_version `
        -BasePath "$build_dir\XAssert.Should\" `
        -Properties "id=$id_should;author=$author;description=$description_should;copyright=$copyright;projectUrl=$projectUrl;licenseUrl=$licenseUrl"

    & "$nuget_path" pack "$base_dir\src\XAssert.Expect\XAssert.Expect.nuspec" `
        -o $release_dir `
        -Version $nuget_package_version `
        -BasePath "$build_dir\XAssert.Expect\" `
        -Properties "id=$id_expect;author=$author;description=$description_expect;copyright=$copyright;projectUrl=$projectUrl;licenseUrl=$licenseUrl"
}
