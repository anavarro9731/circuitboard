Invoke-RestMethod -Uri "https://anavarro9731.visualstudio.com/defaultcollection/powershell/_apis/git/repositories/powershell/items?api-version=1.0&scopepath=load-modules.psm1" -ContentType "text/plain; charset=UTF-8" -OutFile ".\load-modules.psm1"
Import-Module ".\load-modules.psm1" -Verbose -Global -Force
Remove-Item ".\load-modules.psm1" -Verbose -Recurse
Load-Modules

#expose this function like a CmdLet
function global:Run {

	Param(
		[switch]$PrepareNewVersion,
		[switch]$BuildAndTest,
		[switch]$PackAndPublish,
        [switch]$CreateRelease,
        [Alias('nuget-key')]
        [string] $nugetApiKey,
        [Alias('ado-pat')]
        [string] $azureDevopsPat,
        [string] $forceVersion
	)
	
	if ($PrepareNewVersion) {
        Prepare-NewVersion -projects @(
            "CircuitBoard"
        ) `
        -githubUserName "anavarro9731" `
        -repository "circuitboard" `
        -forceVersion $forceVersion
    	}

	if ($BuildAndTest) {
		Build-And-Test -testProjects @(
		)
	}

    if ($PackAndPublish) {
        Pack-And-Publish -allProjects @(
            "CircuitBoard"       	         	    			
        ) `
        -unlistedProjects @(
        ) `
        -nugetApiKey $nugetApiKey `
        -nugetFeedUri "https://api.nuget.org/v3/index.json"
    }

    if ($CreateRelease) {
        Create-Release -projects @(
        "CircuitBoard"
        ) `
        -githubUserName "anavarro9731" `
        -repository "soap"
    }
}
