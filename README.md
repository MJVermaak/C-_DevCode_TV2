# System Architecture

## 1. Project Structure

```text
JobTimecardSystem/
├── JobTimecardSystem.Data/          # Domain Models, FluentNHibernate Mappings & Repositories
│   ├── Models/                      # Job, Timecard, Client, Employee, JobType
│   ├── Mappings/                    # JobMap, TimecardMap, ClientMap, EmployeeMap
│   └── Repositories/                # NHibernateHelper & Entity Repositories
├── JobTimecardSystem.WebApi/        # ASP.NET Core REST API (http://localhost:5295)
│   ├── Controllers/                 # JobsController, TimecardsController, ClientsController, EmployeesController
│   └── Program.cs                   # LocalDB bootstrapper, DI registration, CORS & JSON enum config
├── JobTimecardSystem.Desktop/       # Windows Forms Client
│   ├── Services/                    # ApiClient (typed HttpClient wrapper)
│   └── Form1.cs                     # Tabbed UI, validation guards & centralized event wiring
├── JobTimecardSystem.Web/           # Bonus Responsive Web Client (http://localhost:5100)
│   └── wwwroot/                     # index.html, styles.css, app.js
├── JobTimecardSystem.Tests/         # xUnit Automated Test Suite (16 passing tests)
├── AI_USAGE.md                      # AI Tooling Declaration & Engineering Refinements
├── ARCHITECTURE.md                  # Architectural Overview & Mobile Strategy
└── README.md                        # Setup & Execution Guide
```

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