# Guest Registration Service

## Architecture
* DAL - Layer 2 (knows how to query the database)
  * Contracts.DAL.App - Interfaces for repositories
  * Contracts.DAL.Base - Base interfaces inherited by all `Contracts.DAL.App` interfaces.  This provides some basic functionality to all repositories assuming entities all have inherited ID property.
  * DAL.App.DTO - DTO objects returned to controllers
  * DAL.App.EF - IMPORTANT! Knows how to generate the database schema using `AppDbContext` class. Contains EF (Entity Framework ORM) database migration based on changes to `Domain` objects. Also contains concrete Repository implementations based on `Contracts.DAL.App` interfaces.
  * DAL.Base.EF - Implements `Contracts.DAL.Base`
* Domain - Layer 1 (innermost layer - database models)
  * Contracts.Domain - metadata interfaces for data objects
  * Domain.App - IMPORTANT! Contains the actual models database schema is based on. These objects can be inserted to the database.
  * Domain.Base - Implementations of `Contracts.Domain`
  * Domain.Logic - Extra data validation logic
* WebApp - IMPORTANT! The actual visible app. Blazor frontend logic controllers.

## Data logic
Basically database (`DbContext`) interacts with `Domain` objects.
Domain objects interact with `Repositories`.
Repositories give data to controllers.
Repositories map `Domain` objects into `DAL.DTO` objects.
Controllers map data to `FrontendDTO` that uses data annotations for UI validation logic.
Validation logic should match `Domain` layer validation logic, but it is free to do semantic naming (ex. errorMessages, nameof).

Traditionally you might also have BLL layer, but it is overkill for this project.

Database delete behaviour is cascade delete. 
Be careful with deleting parent properties.

## Commands

Database related (run in solution folder)
~~~
dotnet ef migrations add InitialDbCreation --project DAL.App.EF --startup-project WebApp
dotnet ef database update --project DAL.App.EF --startup-project WebApp
dotnet ef database drop --project DAL.App.EF --startup-project WebApp
~~~

Good to have generator for initial CRUD admin pages:
~~~
dotnet tool install --global dotnet-aspnet-codegenerator
dotnet tool update --global dotnet-aspnet-codegenerator
~~~

Run in WebApp folder
```
dotnet aspnet-codegenerator controller -name EventRealLifeController        -actions -m FrontendDTO.EventRealLife -dc AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -name ParticipantBusinessController  -actions -m ParticipantBusiness -dc AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -name ParticipantCivilianController  -actions -m ParticipantCivilian -dc AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -name UISelectOptionController       -actions -m UISelectOption -dc AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
```

## Packages
* Microsoft.EntityFrameworkCore.Design - Needed for database schema generation with `dotnet ef migrations add ...` command otherwise error (Your startup project 'WebApp' doesn't reference Microsoft.EntityFrameworkCore.Design. This package is required for the Entity Framework Core Tools to work. 
Ensure your startup project is correct, install the package, and try again.)
* Pomelo.EntityFrameworkCore.MySql - EntityFramework Driver for MySql database, used in WebApp configuration
```
builder.Services.AddDbContext<AppDbContext>(options =>
{
  var connetionString = builder.Configuration.GetConnectionString("DefaultConnection");
  options.UseMySql(connetionString, ServerVersion.AutoDetect(connetionString));
});
```
* Microsoft.EntityFrameworkCore.Relational - EntityFrameworkCore extension package for relational databases. Needed for migrations (Microsoft.EntityFrameworkCore.Migrations (comes with the core package) relies on it).
* Microsoft.VisualStudio.Web.CodeGeneration.Design - CRUD generator
* Microsoft.EntityFrameworkCore.SqlServer - dependency for CodeGenerator