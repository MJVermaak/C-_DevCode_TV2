# Job & Timecard Management System

A multi-tier C# application built with **.NET 8**, **SQL Server LocalDB**, **FluentNHibernate**, **ASP.NET Core Web API**, **Windows Forms**, and a responsive **Web Client** for managing service jobs, employee timecards, clients, and staff.

---

## Solution Structure

```text
C-_DevCode_TV2/
├── README.md                        # Setup, installation, and execution guide
├── ARCHITECTURE.md                  # System architecture, trade-offs, and mobile design strategy
├── AI_USAGE.md                      # AI usage declaration and engineering adjustments
└── JobTimecardSystem/               # Visual Studio Solution Folder
    ├── JobTimecardSystem.sln        # Visual Studio Solution File
    ├── JobTimecardSystem.Data/      # Domain models, FluentNHibernate mappings & repositories
    ├── JobTimecardSystem.WebApi/    # ASP.NET Core REST API (http://localhost:5295)
    ├── JobTimecardSystem.Desktop/   # Windows Forms desktop client
    ├── JobTimecardSystem.Web/       # Bonus responsive web client (http://localhost:5100)
    └── JobTimecardSystem.Tests/     # xUnit automated test suite (16 passing tests)
```

---

## Prerequisites

- **Visual Studio 2022** (v17.8 or later) with the following workloads installed via the **Visual Studio Installer**:
  - **.NET Desktop Development**
  - **ASP.NET and Web Development**
  - **Data storage and processing** (includes SQL Server Express LocalDB)
- **.NET 8.0 SDK**
- **Git** (or Visual Studio's built-in Git integration)

---

## Step 1: Clone & Open the Project in Visual Studio

### Option A: Clone Directly Inside Visual Studio 2022
1. Open **Visual Studio 2022**.
2. On the start window, click **Clone a repository**.
3. Enter the repository URL:
   ```text
   [https://github.com/MJVermaak/C-_DevCode_TV2.git](https://github.com/MJVermaak/C-_DevCode_TV2.git)
   ```
4. Choose a local folder path and click **Clone**.
5. Once cloned, open **Solution Explorer**, navigate into the solution folder, and double-click **`JobTimecardSystem.sln`**.

### Option B: Open from a Local Folder
1. Clone or download the repository ZIP from GitHub and extract it to your machine.
2. Open the extracted folder, go into the solution subfolder, and double-click **`JobTimecardSystem.sln`** to open it in **Visual Studio 2022**.
3. Right-click **`Solution 'JobTimecardSystem'`** in **Solution Explorer** and select **Restore NuGet Packages** (if Visual Studio does not restore them automatically), then build the solution via **Build -> Build Solution** (`Ctrl + Shift + B`).

---

## Step 2: Database Setup (Inside Visual Studio)

No external database management tools are required—everything is handled inside **Visual Studio 2022**:

1. **Automatic Database & Table Creation (Default)**:
   - When you start the solution, `JobTimecardSystem.WebApi` automatically connects to `(localdb)\MSSQLLocalDB`, creates the **`JobTimecardDb`** database if it does not already exist, and generates all tables (`Jobs`, `Timecards`, `Clients`, `Employees`) via FluentNHibernate `SchemaUpdate`.
2. **Viewing or Pre-Creating the Database Inside Visual Studio**:
   - In Visual Studio's top menu bar, open **View -> SQL Server Object Explorer**.
   - Expand **SQL Server -> `(localdb)\MSSQLLocalDB` -> Databases**.
   - IF THE DATABASE (`JobTimecardDb`) DOES NOT EXIST: right-click **Databases** -> **Add New Database**, name it **`JobTimecardDb`**, and click **OK**.
   - Once the application runs, expand **`JobTimecardDb` -> Tables** inside **SQL Server Object Explorer** to inspect the schema and table data directly inside Visual Studio.

---

## Step 3: Configure Startup Projects & Run

1. In **Solution Explorer**, right-click the top **`Solution 'JobTimecardSystem'`** node and click **Configure Startup Projects...**.
2. Select **Multiple startup projects** and set **Action** to **Start** for all three executable projects:
   - **`JobTimecardSystem.WebApi`** *(runs the REST API on `http://localhost:5295`)*
   - **`JobTimecardSystem.Desktop`** *(launches the Windows Forms desktop UI)*
   - **`JobTimecardSystem.Web`** *(hosts the web client in the background on `http://localhost:5100`)*
3. Click **OK** and press **`F5`** (or click the green **Start** button) to run the solution:
   - The **Windows Forms Desktop Client** opens automatically.
   - To open the **Web Client**, click the **Web Dashboard** button on any tab in the Desktop app (or navigate to `http://localhost:5100` in your browser).

---

## Step 4: Run Automated Unit Tests

1. In Visual Studio's top menu bar, click **Test -> Run All Tests** (or press **`Ctrl + R, A`**).
2. **Test Explorer** will open and execute all **16 xUnit tests** in `JobTimecardSystem.Tests`, verifying domain rules, FluentNHibernate mappings, and Web API validation.

---

## Implemented Features

- **Jobs Management**: Full CRUD and live search for jobs (`JobNumber`, `JobType` restricted to `Repair`, `Support`, `Warranty`, `JobDate`, `CompanyName`, `ContactName`, `TelephoneNumber`).
- **Timecards Management**: Log employee hours (`0.1` to `24` hours per entry) linked to jobs, supporting multiple jobs per employee on the same date.
- **Clients & Employees Management**: Full CRUD and live search for client records (`CompanyName`, `ContactName`, `TelephoneNumber`) and employee records.
- **Synchronized Desktop & Web Clients**: Both frontends communicate exclusively through `JobTimecardSystem.WebApi` against the shared SQL Server LocalDB database.

---

## 2. Layering Strategy

The solution follows a strict **3-tier N-Layer architecture** with unidirectional dependencies (`Desktop` / `Web` -> `WebApi` -> `Data`):

1. **Data Access Layer (`JobTimecardSystem.Data`)**: Encapsulates all persistence logic, domain entities, FluentNHibernate mappings, and repository queries against SQL Server LocalDB. No UI or HTTP dependencies exist in this assembly.
2. **Service / API Layer (`JobTimecardSystem.WebApi`)**: Exposes stateless RESTful JSON endpoints (`GET`, `POST`, `PUT`, `DELETE`) with query-string search filtering (`?search=`) and server-side input validation.
3. **Presentation Layer (`JobTimecardSystem.Desktop` & `JobTimecardSystem.Web`)**: Both clients are completely decoupled from SQL Server and NHibernate. They communicate solely over HTTP with `JobTimecardSystem.WebApi`, ensuring business rules and persistence remain centralized in one place.

---

## 3. Key Design Decisions

- **Automatic Zero-Config Database Setup**: On startup, `JobTimecardSystem.WebApi` connects to `(localdb)\MSSQLLocalDB` (`master`) with a 5-attempt cold-start retry loop (handling LocalDB sleep wake-up latency), creates `JobTimecardDb` if absent, and runs NHibernate `SchemaUpdate` so reviewers can open the solution in Visual Studio and run immediately without manual SQL scripts.
- **Eager Relationship Loading (`Not.LazyLoad()`)**: Configured on FluentNHibernate class mappings alongside `.Fetch(t => t.Job)` on timecard queries so serialized JSON responses include linked job details (`JobNumber`, `CompanyName`) without throwing `LazyInitializationException` after the NHibernate session closes.
- **Human-Readable Enum Serialization**: Registered `JsonStringEnumConverter` in `Program.cs` so `JobType` values (`Repair`, `Support`, `Warranty`) serialize cleanly as strings across API payloads, Desktop grids, and Web dropdowns.
- **Defense-in-Depth Validation**: Input rules (phone digit/character checks, name character rules, positive hours bounded to `<= 24`, required fields) are enforced on the Desktop UI, the Web frontend, and again inside the Web API controllers.

---

## 4. Trade-Offs Made

| Decision | Benefit | Trade-Off |
| :--- | :--- | :--- |
| **Direct Domain Entity Serialization** | Eliminated repetitive DTO mapping boilerplate across 4 entities while keeping JSON payloads clean via `Not.LazyLoad()`. | Exposes database entity shapes directly over the API; larger production systems would introduce dedicated Request/Response DTOs. |
| **NHibernate `SchemaUpdate`** | Enables automatic table creation inside Visual Studio on first run with zero manual setup steps. | Destructive schema changes (such as dropping legacy columns) require manual DDL or versioned migration scripts. |
| **Vanilla HTML5/CSS3/JS Web Client** | Zero external frontend build pipeline required—runs directly inside Visual Studio alongside the API and Desktop client. | Lacks component-level state management needed for very large multi-page enterprise SPAs. |

---

## 5. Mobile Client Architectural Approach

Because all data access and validation are already isolated behind `JobTimecardSystem.WebApi`, adding a **Mobile Client** (e.g., **.NET MAUI** to share C# models directly from `JobTimecardSystem.Data`, or **React Native / Flutter**) requires **zero changes to the database or core repository layer**:

1. **Shared API Contract**: The mobile app consumes the existing `/api/jobs`, `/api/timecards`, `/api/clients`, and `/api/employees` REST endpoints over HTTPS.
2. **Offline-First Field Synchronization**: Field technicians frequently work in basements or sites without cellular coverage. The mobile app would store pending timecards in a local **SQLite** database with a `SyncStatus` flag (`Pending` / `Synced`) and flush queued entries to `POST /api/timecards` automatically once connectivity is restored.
3. **Authentication & Security**: Expose the Web API behind HTTPS with **JWT Bearer authentication** (plus refresh tokens stored in OS Secure Storage / Keychain) so technicians only log timecards under their authenticated employee identity.
4. **Payload Optimization**: Add pagination (`?page=&pageSize=`) and lightweight summary endpoints for mobile job lists to minimize cellular data usage.

---

## 6. Future Improvements

- **Authentication & Role-Based Access Control (RBAC)**: Add ASP.NET Core Identity / JWT authentication to separate administrative actions (deleting jobs/employees) from technician timecard logging.
- **Versioned Database Migrations**: Replace `SchemaUpdate` with **FluentMigrator** for auditable, repeatable production schema upgrades.
- **Reporting & Exports**: Add weekly employee utilization summaries and CSV/PDF timesheet exports.
