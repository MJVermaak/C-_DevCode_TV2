# Job & Timecard Management System

A multi-tier desktop and web API application built with **C# (.NET)**, **Windows Forms**, **ASP.NET Core Web API**, and **FluentNHibernate** with **Microsoft SQL Server** for managing client service jobs and employee timecards.

---

## Architecture Overview

The solution follows a clean 3-tier architecture separating presentation, API routing, and data persistence:

* **`JobTimecardSystem.Data`**: Domain models (`Job`, `Timecard`, `JobType` enum), FluentNHibernate class mappings (`JobMap`, `TimecardMap`), repository classes (`JobRepository`, `TimecardRepository`), and `NHibernateHelper` session factory configuration.
* **`JobTimecardSystem.WebApi`**: ASP.NET Core RESTful Web API exposing CRUD endpoints (`api/jobs` and `api/timecards`) with dependency-injected repositories and JSON enum string serialization.
* **`JobTimecardSystem.Desktop`**: Responsive Windows Forms client built with `FlowLayoutPanel` containers and `HttpClient` (`ApiClient`) for full CRUD operations across Jobs and Timecards.

---

## Prerequisites

* **Visual Studio 2022** (or newer) with the **.NET Desktop Development** and **ASP.NET and web development** workloads installed.
* **.NET SDK** (`.NET 10.0` or matching solution target framework).
* **SQL Server LocalDB** (`(localdb)\MSSQLLocalDB`) or a full **Microsoft SQL Server** instance.

---

## Database Setup

FluentNHibernate is configured with `SchemaUpdate`, meaning **database tables (`Jobs` and `Timecards`) are generated and updated automatically** when the Web API starts. You only need to create the empty database container first:

1. Open **SQL Server Object Explorer** in Visual Studio (`View` -> `SQL Server Object Explorer`) or **SQL Server Management Studio (SSMS)**.
2. Connect to **`(localdb)\MSSQLLocalDB`**.
3. Right-click **Databases** -> **Add New Database** -> name it **`JobTimecardDb`** -> click **OK**.
4. *(Optional)* If using a different SQL Server instance, update `"DefaultConnection"` in **`JobTimecardSystem.WebApi/appsettings.json`**:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=JobTimecardDb;Trusted_Connection=True;TrustServerCertificate=True;"
   }
