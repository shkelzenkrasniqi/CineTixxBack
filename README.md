CineTixxBack is a backend system designed for managing a cinema's operations. It handles the creation and management of cinema rooms, movies, screenings, and ticket sales for both movies and events.

*Table of Contents
-Features
-Technologies
-Setup
-Usage

*Features
-Manage cinema rooms
-Manage movies and events
-Schedule screenings
-Handle ticket sales
-User authentication and authorization

*Technologies
-ASP.NET Core
-Entity Framework Core
-FluentValidation
-SQL Server
-MongoDB

*Setup
Clone the repository:

git clone https://github.com/shkelzenkrasniqi/CineTixxBack.git
Navigate to the project directory:
cd CineTixxBack

Restore the NuGet packages:
dotnet restore

Update the database connection string in appsettings.json:

"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=CineTixxDb;Trusted_Connection=True;MultipleActiveResultSets=true"
}
Apply the migrations to create the database:
dotnet ef database update

Run the application:
dotnet run

*Usage
User Roles
Admin: Can manage cinema rooms,seats, movies, events, and screenings.
User: Can browse movies and events, and purchase tickets.
