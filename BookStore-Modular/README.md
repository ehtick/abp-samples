# BookStore Modular

This sample demonstrates the BookStore application split into a main application and a reusable `BookManagement` module. It keeps the original IdentityServer-based authentication setup and includes separate host projects for the module.

Related docs:

- Book Store samples: https://abp.io/docs/latest/samples
- ABP modularity: https://abp.io/docs/latest/framework/architecture/modularity/basics

## Prerequisites

- .NET 10.0 SDK
- ABP CLI 10.4.x
- Node.js 22 or later
- SQL Server
- Redis

## Initial Tasks

This project includes root ABP Studio metadata and initial tasks under `etc/`.

- `Initialize Solution` runs `abp install-libs` in both `application/` and `modules/book-management/`, runs the main application `Acme.BookStore.DbMigrator`, and applies the book-management IdentityServer and HTTP API host migrations.
- `Migrate Database` runs the same database migration steps without reinstalling client libraries.

In ABP Studio, open `BookStore-Modular.abpsln`, select the `Default` run profile, and run `Initialize Solution` before the first launch.

## Run the Application

After the initial task completes, start these applications from ABP Studio:

- `Acme.BookStore.BookManagement.IdentityServer` at `https://localhost:44380`
- `Acme.BookStore.BookManagement.HttpApi.Host` at `https://localhost:44364`
- `Acme.BookStore.BookManagement.Web.Host` at `https://localhost:44387`
- `Acme.BookStore.Web` at `https://localhost:44367`

Manual run commands:

```powershell
cd modules/book-management/host/Acme.BookStore.BookManagement.IdentityServer
dotnet run
```

Then start the remaining hosts in separate terminals:

```powershell
cd modules/book-management/host/Acme.BookStore.BookManagement.HttpApi.Host
dotnet run
```

```powershell
cd modules/book-management/host/Acme.BookStore.BookManagement.Web.Host
dotnet run
```

```powershell
cd application/src/Acme.BookStore.Web
dotnet run
```

## Manual Setup

If you are not using ABP Studio, run these commands from the repository root:

```powershell
cd application
abp install-libs
cd ../modules/book-management
abp install-libs
cd ../../application/src/Acme.BookStore.DbMigrator
dotnet run
cd ../../../modules/book-management
dotnet ef database update --project host/Acme.BookStore.BookManagement.IdentityServer/Acme.BookStore.BookManagement.IdentityServer.csproj --startup-project host/Acme.BookStore.BookManagement.IdentityServer/Acme.BookStore.BookManagement.IdentityServer.csproj --context IdentityServerHostMigrationsDbContext
dotnet ef database update --project host/Acme.BookStore.BookManagement.HttpApi.Host/Acme.BookStore.BookManagement.HttpApi.Host.csproj --startup-project host/Acme.BookStore.BookManagement.HttpApi.Host/Acme.BookStore.BookManagement.HttpApi.Host.csproj --context MyProjectHttpApiHostMigrationsDbContext
```
