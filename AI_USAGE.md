# AI Usage Declaration

## 1. Tools Used

- **Gemini (AI Coding Assistant)** — Used during development as a pair-programming and architectural sounding board alongside **Visual Studio 2022**.

---

## 2. How AI Was Used

- **Boilerplate & Scaffolding**: Accelerated initial creation of repetitive CRUD boilerplate across the 4 entities (`Job`, `Timecard`, `Client`, `Employee`), including FluentNHibernate `ClassMap<T>` definitions, repository methods, and REST controller templates.
- **Bonus Web Client Prototyping**: Generated the initial HTML5, CSS3, and Fetch API JavaScript structure for `JobTimecardSystem.Web` to mirror the Desktop client's functionality.
- **Unit Test Scaffolding**: Assisted in structuring xUnit `[Fact]` and `[Theory]` test cases for model constraints, FluentNHibernate mappings, and controller bad-request guards.
- **Troubleshooting**: Used to diagnose environment-specific issues, including SQL Server LocalDB cold-start connection timeouts, project dependency direction, and WinForms `FlowLayoutPanel` control parenting behavior.

---

## 3. What Was Changed & Corrected

AI outputs were reviewed against the assessment specification (`CSharp Developer Code Test V2`) and modified in several key areas:

- **Strict Specification Alignment on `Client` and `JobType`**: Removed an AI-introduced `Email` property from the `Client` model, FluentNHibernate mapping, repository search, API controller, Desktop form, Web client, and SQL Server table so `Client` contains strictly the three fields specified in the brief (`CompanyName`, `ContactName`, `TelephoneNumber`). Verified `JobType` remained restricted strictly to `Repair`, `Support`, and `Warranty`.
- **WinForms Layout & Navigation Refinement**: Replaced an AI-proposed anchored `LinkLabel` overlay (which conflicted with WinForms `FlowLayoutPanel` auto-parenting) with a dedicated **Web Dashboard** button integrated cleanly into the existing action bar on all four tabs, opening `http://localhost:5100` on demand rather than auto-launching a browser on startup.
- **Strengthened API Validation**: Expanded `JobsController` validation to enforce all four required fields (`JobNumber`, `CompanyName`, `ContactName`, `TelephoneNumber`) rather than checking only `JobNumber` and `CompanyName`.
- **Unit Test Alignment**: Updated controller unit tests to match the actual `IActionResult` return types and `TimecardsController(TimecardRepository, JobRepository)` constructor signature.

---

## 4. Lessons Learned

- **Verify Domain Models Against Requirements First**: AI tools frequently infer "helpful" extra properties (such as `Email` on a `Client` entity); cross-checking generated models line-by-line against the specification prevents scope drift.
- **Resilient Local Database Bootstrapping**: LocalDB instances suspend when idle; adding explicit `Connect Timeout` settings and a short startup retry loop prevents false connection failures on cold runs.
- **Separation of Concerns Pays Off**: Keeping all persistence and business rules inside `JobTimecardSystem.Data` and `JobTimecardSystem.WebApi` made adding the bonus Web Client straightforward without duplicating database logic.