# BookStore MVC + EF Core

This sample implements the ABP Book Store tutorial with an MVC/Razor Pages UI and Entity Framework Core. It is a layered ABP application with the usual `Domain`, `Application`, `EntityFrameworkCore`, `HttpApi`, `Web`, and `DbMigrator` projects.

Tutorial: https://abp.io/docs/latest/tutorials/book-store?UI=MVC&DB=EF

## Prerequisites

- .NET 10.0 SDK
- ABP CLI 10.4.x
- Node.js 22 or later
- SQL Server

## Initial Tasks

This project includes ABP Studio metadata and initial tasks under `etc/`.

- `Initialize Solution` runs `abp install-libs`, runs `Acme.BookStore.DbMigrator`, and creates the local OpenIddict development certificate.
- `Migrate Database` runs `Acme.BookStore.DbMigrator` to apply migrations and seed data.

In ABP Studio, open `Acme.BookStore.abpsln`, select the `Default` run profile, and run `Initialize Solution` before the first launch.

## Run the Application

After the initial task completes, start `Acme.BookStore.Web` from ABP Studio or run it manually:

```powershell
cd src/Acme.BookStore.Web
dotnet run
```

The MVC application runs at `https://localhost:44339`.

## Manual Setup

If you are not using ABP Studio, run these commands from the project root:

```powershell
abp install-libs
cd src/Acme.BookStore.DbMigrator
dotnet run
cd ../Acme.BookStore.Web
dotnet dev-certs https -v -ep openiddict.pfx -p 69d2731d-0125-4f47-9dbe-ce30ae744c46
dotnet run
```
