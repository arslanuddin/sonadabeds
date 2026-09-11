# Sonada Beds

A production-oriented ASP.NET Core MVC e-commerce starter for Sonada Beds (`sonadabeds.co.uk`).

## Stack
- .NET 10 / ASP.NET Core MVC
- Entity Framework Core 10
- SQL Server
- ASP.NET Core Identity
- Razor Views
- Bootstrap 5 + custom Sonada Beds styling

## Features
- Product catalogue and categories
- Bed configurator with server-side pricing
- Cart and checkout flow
- Customer accounts and order history
- Wishlist
- Reviews
- Coupons
- Swatch requests and newsletter signup
- Admin dashboard
- CMS pages, FAQs and blog models
- SEO-friendly routes, sitemap and JSON-LD
- UK postcode delivery rules
- Payment and email abstractions
- Docker and GitHub Actions

## Run
1. Install .NET 10 SDK and SQL Server (or use Docker).
2. Set `ConnectionStrings__DefaultConnection` or edit `appsettings.Development.json`.
3. Run `dotnet restore` and `dotnet run --project src/SonadaBeds.Web`.
4. Browse to the URL shown by ASP.NET Core.

Development seed data is created automatically. The development admin is `admin@sonadabeds.co.uk` with password `Admin123!ChangeMe` — change it immediately outside local development.

## Production
Set secrets through environment variables/user secrets. Run EF migrations before deployment. Do not use the development admin password in production.
