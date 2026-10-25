# AutoRentManager

## About the Project

AutoRentManager is an ASP.NET Core MVC web application for managing car rentals.
Visitors can browse available cars, view car details, and submit rental reservations.
Administrators can manage the car catalog and review reservation requests.

The project was developed as part of the ASP.NET Fundamentals course at SoftUni.

## Features

### Public Users
- Browse the car catalog and view car details.
- Submit rental reservation requests.
- Enter customer information and select rental dates.
- Receive validation feedback when submitting invalid data.

### Administrator
- Add, edit, view, and delete cars.
- View submitted rental reservations.
- Confirm or cancel pending reservations.
- Prevent overlapping reservations for the same car when a reservation is confirmed.

### Validation and Security
- Server-side model validation using Data Annotations and ModelState.
- Client-side validation in forms.
- Authentication and role-based authorization for administrative functionality.
- Entity Framework Core for database operations.

## Technologies Used

- C#
- ASP.NET Core MVC (.NET 10)
- Entity Framework Core
- Microsoft SQL Server
- ASP.NET Core Identity
- Razor Views
- Bootstrap
- HTML, CSS and JavaScript

## Prerequisites

- .NET 10 SDK
- Microsoft SQL Server
- Visual Studio or another .NET-compatible development environment

## Setup Instructions

1. Clone or download this repository.
2. Open the solution in Visual Studio.
3. Configure the SQL Server connection string using the local configuration required by the application. Do not commit passwords or other secrets to source control.
4. Restore the NuGet packages.
5. Open a terminal in the project directory and apply the database migrations:

   ```bash
   dotnet restore
   dotnet ef database update
   ```

6. Run the application:

   ```bash
   dotnet run
   ```

   Alternatively, run the project directly from Visual Studio.

Make sure SQL Server is running and the configured database connection is valid before applying migrations.

## Administrator Account

The administrator account is intended for managing cars and reservations.

- **Administrator email:** `admin@autorentmanager.com`
- **Password:** `Admin123!`

If the application uses User Secrets to initialize the administrator account, configure the required `AdminSettings` values locally before running the application. The administrator setup must match the configuration and initialization logic implemented in the project.

## Project Structure

- `Models` — entity models and validation rules.
- `Data` — Entity Framework Core database context.
- `Controllers` — application controllers and request handling.
- `Views` — Razor views and application pages.
- `wwwroot` — static assets, stylesheets, JavaScript, and car images.
- `Enums` — enumeration types used by the application.
- `Common` — shared validation constants.

## Database

The application uses Entity Framework Core with Microsoft SQL Server. Database schema changes are managed through EF Core migrations.

## License

This project was created for educational purposes.
