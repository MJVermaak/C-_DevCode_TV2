# Job & Timecard Management System

A multi-tier C# application built with **.NET 8**, **SQL Server LocalDB**, **FluentNHibernate**, **ASP.NET Core Web API**, **Windows Forms**, and a responsive **Web Client** for managing service jobs, employee timecards, clients, and staff.

---

## Solution Structure

- **`JobTimecardSystem.Data`** — Domain models (`Job`, `Timecard`, `Client`, `Employee`), `JobType` enum (`Repair`, `Support`, `Warranty`), FluentNHibernate class mappings, `NHibernateHelper`, and data repositories.
- **`JobTimecardSystem.WebApi`** — RESTful ASP.NET Core Web API exposing CRUD and search endpoints on `http://localhost:5295`.
- **`JobTimecardSystem.Desktop`** — Windows Forms desktop application providing tabbed CRUD interfaces, live search, input validation, and a **Web Dashboard** quick-launch button.
- **`JobTimecardSystem.Web`** — Bonus responsive HTML5/CSS3/JavaScript web frontend hosted on `http://localhost:5100` consuming the Web API.
- **`JobTimecardSystem.Tests`** — xUnit test suite (16 passing tests) verifying domain rules, ORM mappings, and API input validation.

---

## Prerequisites

- **Visual Studio 2022** (v17.8 or later) with the following workloads installed via the **Visual Studio Installer**:
  - **.NET Desktop Development**
  - **ASP.NET and Web Development**
  - **Data storage and processing** (includes SQL Server Express LocalDB)
- **.NET 8.0 SDK**

---

## Database Setup (Inside Visual Studio)

No external database management tools are required—everything is handled inside **Visual Studio 2022**:

1. **Automatic Database & Schema Creation (Recommended)**:
   - When you run the solution in Visual Studio, `JobTimecardSystem.WebApi` automatically connects to `(localdb)\MSSQLLocalDB`, creates the **`JobTimecardDb`** database if it does not already exist, and generates all tables (`Jobs`, `Timecards`, `Clients`, `Employees`) using FluentNHibernate `SchemaUpdate`.
2. **Inspecting or Pre-Creating the Database in Visual Studio**:
   - Open **View -> SQL Server Object Explorer** in Visual Studio.
   - Expand **SQL Server -> `(localdb)\MSSQLLocalDB` -> Databases**.
   - If you want to create the database manually beforehand, right-click **Databases** -> **Add New Database**, enter **`JobTimecardDb`**, and click **OK**.
   - Once the application runs, expand **`JobTimecardDb` -> Tables** inside **SQL Server Object Explorer** to view or query the generated tables directly inside Visual Studio.

---

## How to Run the Application

1. Open **`JobTimecardSystem.sln`** in **Visual Studio 2022**.
2. In **Solution Explorer**, right-click the top **`Solution 'JobTimecardSystem'`** node and select **Configure Startup Projects...**.
3. Select **Multiple startup projects** and set **Action** to **Start** for:
   - **`JobTimecardSystem.WebApi`**
   - **`JobTimecardSystem.Desktop`**
   - **`JobTimecardSystem.Web`**
4. Click **OK** and press **`F5`** (or click the green **Start** button) to run the solution:
   - The **Windows Forms Desktop Client** opens automatically.
   - To launch the **Web Client**, click the **Web Dashboard** button on any tab in the Desktop app (or open `http://localhost:5100` in your browser).

---

## Running Unit Tests

1. In Visual Studio's top menu bar, click **Test -> Run All Tests** (or press **`Ctrl + R, A`**).
2. **Test Explorer** will open and execute all **16 xUnit tests** in `JobTimecardSystem.Tests`.

---

## Implemented Features

- **Jobs Management**: Full CRUD and live search for jobs (`JobNumber`, `JobType` restricted to `Repair`, `Support`, `Warranty`, `JobDate`, `CompanyName`, `ContactName`, `TelephoneNumber`).
- **Timecards Management**: Log employee hours (`0.1` to `24` hours per entry) linked to jobs, supporting multiple jobs per employee on the same date.
- **Clients & Employees Management**: Full CRUD and live search for client records (`CompanyName`, `ContactName`, `TelephoneNumber`) and employee records.
- **Synchronized Desktop & Web Clients**: Both frontends communicate exclusively through `JobTimecardSystem.WebApi` against the shared SQL Server LocalDB database.