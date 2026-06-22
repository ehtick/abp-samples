$scriptRoot = Split-Path -Parent $MyInvocation.MyCommand.Path

$jobs = @()

$jobs += Start-Job -Name "ApplicationDbMigrator" -ScriptBlock {
    $ErrorActionPreference = "Stop"
    Set-Location (Join-Path $using:scriptRoot "../../application/src/Acme.BookStore.DbMigrator")
    dotnet run

    if ($LASTEXITCODE -ne 0) {
        throw "dotnet run (Application DbMigrator) exited with code $LASTEXITCODE"
    }
}

$jobs += Start-Job -Name "BookManagementIdentityServerDatabase" -ScriptBlock {
    $ErrorActionPreference = "Stop"
    Set-Location (Join-Path $using:scriptRoot "../../modules/book-management")
    dotnet ef database update --project "host/Acme.BookStore.BookManagement.IdentityServer/Acme.BookStore.BookManagement.IdentityServer.csproj" --startup-project "host/Acme.BookStore.BookManagement.IdentityServer/Acme.BookStore.BookManagement.IdentityServer.csproj" --context IdentityServerHostMigrationsDbContext

    if ($LASTEXITCODE -ne 0) {
        throw "dotnet ef database update (BookManagement IdentityServer) exited with code $LASTEXITCODE"
    }
}

$jobs += Start-Job -Name "BookManagementHttpApiDatabase" -ScriptBlock {
    $ErrorActionPreference = "Stop"
    Set-Location (Join-Path $using:scriptRoot "../../modules/book-management")
    dotnet ef database update --project "host/Acme.BookStore.BookManagement.HttpApi.Host/Acme.BookStore.BookManagement.HttpApi.Host.csproj" --startup-project "host/Acme.BookStore.BookManagement.HttpApi.Host/Acme.BookStore.BookManagement.HttpApi.Host.csproj" --context MyProjectHttpApiHostMigrationsDbContext

    if ($LASTEXITCODE -ne 0) {
        throw "dotnet ef database update (BookManagement HttpApi) exited with code $LASTEXITCODE"
    }
}

Wait-Job $jobs | Out-Null
$jobs | Receive-Job

$failed = $jobs | Where-Object { $_.State -eq 'Failed' }
$hasError = $failed.Count -gt 0

if ($hasError) {
    foreach ($job in $failed) {
        [Console]::Error.WriteLine("Job '$($job.Name)' FAILED")
    }

    Remove-Job $jobs | Out-Null
    exit -1
}

Remove-Job $jobs | Out-Null
exit 0
