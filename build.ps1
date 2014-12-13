param(
    [Parameter(Position=0,Mandatory=0)]
    [string[]]$taskList = @(),
    [Parameter(Position=1,Mandatory=0)]
    [string]$framework,
    [Parameter(Position=2,Mandatory=0)]
    [switch]$docs = $false,
    [Parameter(Position=3,Mandatory=0)]
    [System.Collections.Hashtable]$parameters = @{},
    [Parameter(Position=4, Mandatory=0)]
    [System.Collections.Hashtable]$properties = @{},
    [Parameter(Position=5, Mandatory=0)]
    [alias("init")]
    [scriptblock]$initialization = {},
    [Parameter(Position=6, Mandatory=0)]
    [switch]$nologo = $false,
    [Parameter(Position=7, Mandatory=0)]
    [switch]$help = $false,
    [Parameter(Position=8, Mandatory=0)]
    [string]$scriptPath,
    [Parameter(Position=9,Mandatory=0)]
    [switch]$detailedDocs = $false
)

$base_dir  = resolve-path .
$tools_dir = "$base_dir\tools"
$psake_dir = "$tools_dir\psake"
$psake_build_file = "$base_dir\psakefile.ps1"

# '[p]sake' is the same as 'psake' but $Error is not polluted
#remove-module [p]sake
#import-module (join-path $scriptPath "$psake_dir\psake.psm1")

#Invoke-Expression "invoke-psake $psake_build_file $argumentList"
& "$psake_dir\psake.ps1" $psake_build_file $taskList $framework $docs $parameters $properties $initialization $nologo $detailedDocs