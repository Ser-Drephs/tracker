[CmdletBinding()]
param (
    [Parameter(Mandatory)]
    [string]
    $Migration
)
Push-Location "Tracker.Core"
dotnet ef migrations add $Migration
dotnet ef database update
Pop-Location