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
        [Alias('k')]
        [string] $nugetApiKey
	)
	
	if ($PrepareNewVersion) {
        Prepare-NewVersion -projects @(
            "CircuitBoard"
        )
	}

	if ($BuildAndTest) {
		Build-And-Test -testProjects @(
		)
	}

    if ($PackAndPublish) {
        Pack-And-Publish -standardProjects @(
            "CircuitBoard"       	         	    			
        ) -unlistedProjects @(
        ) `
        -nugetFeedUri "https://www.nuget.org/api/v2/package" `
        -nugetSymbolFeedUri "https://www.nuget.org/api/v2/package" `
        -nugetApiKey $nugetApiKey `
        -originUrl $originUrl
    }
}