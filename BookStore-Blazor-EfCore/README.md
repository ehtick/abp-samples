# BookStore Blazor + EF Core

This sample implements the ABP Book Store tutorial with a Blazor WebAssembly UI and Entity Framework Core. It is a layered ABP application with a separate API host, Blazor client, and database migrator.

Tutorial: https://abp.io/docs/latest/tutorials/book-store?UI=Blazor&DB=EF

## Prerequisites

- .NET 10.0 SDK
- ABP CLI 3.0.10
- Node.js 22 or later
- PostgreSQL

## Initial Tasks

This project includes ABP Studio metadata and initial tasks under `etc/`.

- `Initialize Solution` runs `abp install-libs`, runs `Acme.BookStore.DbMigrator`, and creates the local OpenIddict development certificate.
- `Migrate Database` runs `Acme.BookStore.DbMigrator` to apply migrations and seed data.

In ABP Studio, open `Acme.BookStore.abpsln`, select the `Default` run profile, and run `Initialize Solution` before the first launch.

## Run the Application

After the initial task completes, start these applications from ABP Studio:

- `Acme.BookStore.HttpApi.Host` at `https://localhost:44323`
- `Acme.BookStore.Blazor` at `https://localhost:44308`

Manual run commands:

```powershell
cd src/Acme.BookStore.HttpApi.Host
dotnet run
```

In a second terminal:

```powershell
cd src/Acme.BookStore.Blazor
dotnet run
```

## Manual Setup

If you are not using ABP Studio, run these commands from the project root:

```powershell
abp install-libs
cd src/Acme.BookStore.DbMigrator
dotnet run
cd ../Acme.BookStore.HttpApi.Host
dotnet dev-certs https -v -ep openiddict.pfx -p 0bc9a38b-d740-4abc-81e8-2c78dc44e970
```

For production OpenIddict certificate guidance, see https://abp.io/docs/latest/deployment/configuring-openiddict.
