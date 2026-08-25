# EventOrganizer

This sample demonstrates creating an event organizer application with the ABP Framework and Blazor UI. It uses MongoDB for persistence and keeps the original IdentityServer-based authentication setup.

Article: https://abp.io/community/articles/creating-an-event-organizer-application-with-the-blazor-ui-wbe0sf2z#gsc.tab=0

## Prerequisites

- .NET 10.0 SDK
- ABP CLI 3.0.10
- Node.js 22 or later
- MongoDB

## Initial Tasks

This project includes ABP Studio metadata and initial tasks under `etc/`.

- `Initialize Solution` runs `abp install-libs` and runs `EventOrganizer.DbMigrator` to seed MongoDB and IdentityServer data.
- `Migrate Database` runs `EventOrganizer.DbMigrator` to seed/update MongoDB data.

In ABP Studio, open `EventOrganizer.abpsln`, select the `Default` run profile, and run `Initialize Solution` before the first launch.

## Run the Application

After the initial task completes, start these applications from ABP Studio:

- `EventOrganizer.HttpApi.Host` at `https://localhost:44354`
- `EventOrganizer.Blazor` at `https://localhost:44307`

Manual run commands:

```powershell
cd src/EventOrganizer.HttpApi.Host
dotnet run
```

In a second terminal:

```powershell
cd src/EventOrganizer.Blazor
dotnet run
```

## Manual Setup

If you are not using ABP Studio, run these commands from the project root:

```powershell
abp install-libs
cd src/EventOrganizer.DbMigrator
dotnet run
```
