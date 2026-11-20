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
2. Select **Multiple startup projects** and confirm that all **Actions** are set to **Start** for the following:
   - **`JobTimecardSystem.WebApi`** *(runs the REST API on `http://localhost:5295`)*
   - **`JobTimecardSystem.Desktop`** *(launches the Windows Forms desktop UI)*
   - **`JobTimecardSystem.Web`** *(hosts the web client in the background on `http://localhost:5100`)*
3. Click **OK** and press **`F5`** (or click the green **Start** button) to run the solution:
   - The **Windows Forms Desktop Client** opens automatically.
   - To open the **Web Client**, click the **Web Dashboard** button on any tab in the Desktop app (or navigate to `http://localhost:5100` in your browser).

## Step 4: Running Unit Tests

1. In Visual Studio's top menu bar, click **Test -> Run All Tests** (or press **`Ctrl + R, A`**).
2. **Test Explorer** will open and execute all **16 xUnit tests** in `JobTimecardSystem.Tests`.

---

## Implemented Features

- **Jobs Management**: Full CRUD and live search for jobs (`JobNumber`, `JobType` restricted to `Repair`, `Support`, `Warranty`, `JobDate`, `CompanyName`, `ContactName`, `TelephoneNumber`).
- **Timecards Management**: Log employee hours (`0.1` to `24` hours per entry) linked to jobs, supporting multiple jobs per employee on the same date.
- **Clients & Employees Management**: Full CRUD and live search for client records (`CompanyName`, `ContactName`, `TelephoneNumber`) and employee records.
- **Synchronized Desktop & Web Clients**: Both frontends communicate exclusively through `JobTimecardSystem.WebApi` against the shared SQL Server LocalDB database.

---

