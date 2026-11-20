const API_BASE = "http://localhost:5295/api";

const isValidCode = (v) => /^[A-Za-z0-9_-]{2,}$/.test(v.trim());
const isValidPersonName = (v) => /^[A-Za-z\s'-]{2,}$/.test(v.trim());
const isValidPhone = (v) => {
    const trimmed = v.trim();
    const digits = (trimmed.match(/\d/g) || []).length;
    return digits >= 7 && digits <= 15 && /^[0-9+\-()\s]+$/.test(trimmed);
};
const isValidEmail = (v) => !v.trim() || /^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(v.trim());

function showAlert(message, type = "error") {
    const box = document.getElementById("alertBox");
    box.textContent = message;
    box.className = `alert ${type}`;
    setTimeout(() => box.classList.add("hidden"), 5000);
}

function escapeHtml(str) {
    return String(str ?? "")
        .replaceAll("&", "&amp;")
        .replaceAll("<", "&lt;")
        .replaceAll(">", "&gt;")
        .replaceAll('"', "&quot;");
}

function toInputDate(dateStr) {
    if (!dateStr) return new Date().toISOString().split("T")[0];
    return String(dateStr).split("T")[0];
}

document.querySelectorAll(".tab-btn").forEach((btn) => {
    btn.addEventListener("click", () => {
        document.querySelectorAll(".tab-btn").forEach((b) => b.classList.remove("active"));
        document.querySelectorAll(".tab-panel").forEach((p) => p.classList.remove("active"));
        btn.classList.add("active");
        document.getElementById(btn.dataset.tab).classList.add("active");
    });
});

async function apiRequest(endpoint, options = {}) {
    const response = await fetch(`${API_BASE}/${endpoint}`, {
        headers: { "Content-Type": "application/json" },
        ...options
    });
    if (!response.ok) {
        const errorText = await response.text();
        throw new Error(errorText || `Request failed (${response.status})`);
    }
    if (response.status === 204) return null;
    return response.json();
}

async function refreshAll() {
    const statusBadge = document.getElementById("apiStatus");
    try {
        const [allJobs, filteredJobs, timecards, clients, employees] = await Promise.all([
            apiRequest("jobs"),
            apiRequest(`jobs?search=${encodeURIComponent(document.getElementById("searchJobs").value)}`),
            apiRequest(`timecards?search=${encodeURIComponent(document.getElementById("searchTimecards").value)}`),
            apiRequest(`clients?search=${encodeURIComponent(document.getElementById("searchClients").value)}`),
            apiRequest(`employees?search=${encodeURIComponent(document.getElementById("searchEmployees").value)}`)
        ]);

        statusBadge.textContent = "API Online (localhost:5295)";
        statusBadge.className = "status-badge status-online";

        renderJobs(filteredJobs);
        populateJobDropdown(allJobs);
        renderTimecards(timecards);
        renderClients(clients);
        renderEmployees(employees);

        const totalHours = timecards.reduce((sum, t) => sum + Number(t.hoursWorked || 0), 0);
        document.getElementById("kpiJobs").textContent = allJobs.length;
        document.getElementById("kpiTimecards").textContent = timecards.length;
        document.getElementById("kpiHours").textContent = totalHours.toFixed(2);
        document.getElementById("kpiPeople").textContent = `${clients.length} / ${employees.length}`;
    } catch (err) {
        statusBadge.textContent = "API Offline - Start WebApi";
        statusBadge.className = "status-badge status-offline";
        showAlert(`Could not reach Web API: ${err.message}`);
    }
}

// ================= JOBS =================
function renderJobs(jobs) {
    const tbody = document.getElementById("jobsTableBody");
    tbody.innerHTML = jobs.map((j) => `
        <tr>
            <td>${j.id}</td>
            <td><strong>${escapeHtml(j.jobNumber)}</strong></td>
            <td>${escapeHtml(j.jobType)}</td>
            <td>${toInputDate(j.jobDate)}</td>
            <td>${escapeHtml(j.companyName)}</td>
            <td>${escapeHtml(j.contactName)}</td>
            <td>${escapeHtml(j.telephoneNumber)}</td>
            <td class="action-cell">
                <button class="btn btn-secondary btn-sm" onclick='editJob(${JSON.stringify(j)})'>Edit</button>
                <button class="btn btn-danger btn-sm" onclick="deleteJob(${j.id})">Delete</button>
            </td>
        </tr>
    `).join("");
}

function populateJobDropdown(jobs) {
    const select = document.getElementById("tcJobId");
    const current = select.value;
    select.innerHTML = jobs.map((j) =>
        `<option value="${j.id}">${escapeHtml(j.jobNumber)} - ${escapeHtml(j.companyName)} (${escapeHtml(j.jobType)})</option>`
    ).join("");
    if (current) select.value = current;
}

window.editJob = (job) => {
    document.getElementById("jobId").value = job.id;
    document.getElementById("jobNumber").value = job.jobNumber;
    document.getElementById("jobType").value = job.jobType;
    document.getElementById("jobDate").value = toInputDate(job.jobDate);
    document.getElementById("jobCompany").value = job.companyName;
    document.getElementById("jobContact").value = job.contactName;
    document.getElementById("jobPhone").value = job.telephoneNumber;
    document.getElementById("btnSaveJob").textContent = "Update Job";
};

function clearJobForm() {
    document.getElementById("jobForm").reset();
    document.getElementById("jobId").value = "";
    document.getElementById("jobDate").value = toInputDate();
    document.getElementById("btnSaveJob").textContent = "Add Job";
}

document.getElementById("btnClearJob").addEventListener("click", clearJobForm);

document.getElementById("jobForm").addEventListener("submit", async (e) => {
    e.preventDefault();
    const id = document.getElementById("jobId").value;
    const payload = {
        id: id ? Number(id) : 0,
        jobNumber: document.getElementById("jobNumber").value.trim(),
        jobType: document.getElementById("jobType").value,
        jobDate: document.getElementById("jobDate").value,
        companyName: document.getElementById("jobCompany").value.trim(),
        contactName: document.getElementById("jobContact").value.trim(),
        telephoneNumber: document.getElementById("jobPhone").value.trim()
    };

    if (!isValidCode(payload.jobNumber)) return showAlert("Job Number may only contain letters, numbers, hyphens, or underscores.");
    if (payload.companyName.length < 2) return showAlert("Company Name is required.");
    if (!isValidPersonName(payload.contactName)) return showAlert("Contact Name must contain letters only (no numbers).");
    if (!isValidPhone(payload.telephoneNumber)) return showAlert("Telephone Number must contain 7 to 15 digits and no letters.");

    try {
        if (id) {
            await apiRequest(`jobs/${id}`, { method: "PUT", body: JSON.stringify(payload) });
            showAlert("Job updated.", "success");
        } else {
            await apiRequest("jobs", { method: "POST", body: JSON.stringify(payload) });
            showAlert("Job added.", "success");
        }
        clearJobForm();
        await refreshAll();
    } catch (err) {
        showAlert(err.message);
    }
});

window.deleteJob = async (id) => {
    if (!confirm("Delete this job and its linked timecards?")) return;
    try {
        await apiRequest(`jobs/${id}`, { method: "DELETE" });
        showAlert("Job deleted.", "success");
        await refreshAll();
    } catch (err) {
        showAlert(err.message);
    }
};

// ================= TIMECARDS =================
function renderTimecards(timecards) {
    const tbody = document.getElementById("timecardsTableBody");
    tbody.innerHTML = timecards.map((t) => `
        <tr>
            <td>${t.id}</td>
            <td><strong>${escapeHtml(t.job?.jobNumber ?? `Job #${t.jobId}`)}</strong></td>
            <td>${escapeHtml(t.job?.companyName ?? "")}</td>
            <td>${escapeHtml(t.employee)}</td>
            <td>${toInputDate(t.dateWorked)}</td>
            <td>${Number(t.hoursWorked).toFixed(2)}</td>
            <td class="action-cell">
                <button class="btn btn-secondary btn-sm" onclick='editTimecard(${JSON.stringify(t)})'>Edit</button>
                <button class="btn btn-danger btn-sm" onclick="deleteTimecard(${t.id})">Delete</button>
            </td>
        </tr>
    `).join("");
}

window.editTimecard = (tc) => {
    document.getElementById("timecardId").value = tc.id;
    document.getElementById("tcJobId").value = tc.jobId;
    document.getElementById("tcEmployee").value = tc.employee;
    document.getElementById("tcDate").value = toInputDate(tc.dateWorked);
    document.getElementById("tcHours").value = tc.hoursWorked;
    document.getElementById("btnSaveTimecard").textContent = "Update Timecard";
};

function clearTimecardForm() {
    document.getElementById("timecardForm").reset();
    document.getElementById("timecardId").value = "";
    document.getElementById("tcDate").value = toInputDate();
    document.getElementById("btnSaveTimecard").textContent = "Add Timecard";
}

document.getElementById("btnClearTimecard").addEventListener("click", clearTimecardForm);

document.getElementById("timecardForm").addEventListener("submit", async (e) => {
    e.preventDefault();
    const id = document.getElementById("timecardId").value;
    const jobId = Number(document.getElementById("tcJobId").value);
    const hours = Number(document.getElementById("tcHours").value);
    const payload = {
        id: id ? Number(id) : 0,
        jobId,
        employee: document.getElementById("tcEmployee").value.trim(),
        dateWorked: document.getElementById("tcDate").value,
        hoursWorked: hours
    };

    if (!jobId) return showAlert("Please create and select a Job first.");
    if (!isValidPersonName(payload.employee)) return showAlert("Employee Name must contain letters only (no numbers).");
    if (Number.isNaN(hours) || hours <= 0 || hours > 24) return showAlert("Hours Worked must be greater than 0 and at most 24.");

    try {
        if (id) {
            await apiRequest(`timecards/${id}`, { method: "PUT", body: JSON.stringify(payload) });
            showAlert("Timecard updated.", "success");
        } else {
            await apiRequest("timecards", { method: "POST", body: JSON.stringify(payload) });
            showAlert("Timecard added.", "success");
        }
        clearTimecardForm();
        await refreshAll();
    } catch (err) {
        showAlert(err.message);
    }
});

window.deleteTimecard = async (id) => {
    if (!confirm("Delete this timecard?")) return;
    try {
        await apiRequest(`timecards/${id}`, { method: "DELETE" });
        showAlert("Timecard deleted.", "success");
        await refreshAll();
    } catch (err) {
        showAlert(err.message);
    }
};

// ================= CLIENTS =================
function renderClients(clients) {
    const tbody = document.getElementById("clientsTableBody");
    tbody.innerHTML = clients.map((c) => `
        <tr>
            <td>${c.id}</td>
            <td><strong>${escapeHtml(c.companyName)}</strong></td>
            <td>${escapeHtml(c.contactName)}</td>
            <td>${escapeHtml(c.telephoneNumber)}</td>
            <td class="action-cell">
                <button class="btn btn-secondary btn-sm" onclick='editClient(${JSON.stringify(c)})'>Edit</button>
                <button class="btn btn-danger btn-sm" onclick="deleteClient(${c.id})">Delete</button>
            </td>
        </tr>
    `).join("");
}

window.editClient = (c) => {
    document.getElementById("clientId").value = c.id;
    document.getElementById("clientCompany").value = c.companyName;
    document.getElementById("clientContact").value = c.contactName;
    document.getElementById("clientPhone").value = c.telephoneNumber;
    document.getElementById("btnSaveClient").textContent = "Update Client";
};

function clearClientForm() {
    document.getElementById("clientForm").reset();
    document.getElementById("clientId").value = "";
    document.getElementById("btnSaveClient").textContent = "Add Client";
}

document.getElementById("btnClearClient").addEventListener("click", clearClientForm);

document.getElementById("clientForm").addEventListener("submit", async (e) => {
    e.preventDefault();
    const id = document.getElementById("clientId").value;
    const payload = {
        id: id ? Number(id) : 0,
        companyName: document.getElementById("clientCompany").value.trim(),
        contactName: document.getElementById("clientContact").value.trim(),
        telephoneNumber: document.getElementById("clientPhone").value.trim()
    };

    if (payload.companyName.length < 2) return showAlert("Company Name is required.");
    if (!isValidPersonName(payload.contactName)) return showAlert("Contact Name must contain letters only (no numbers).");
    if (!isValidPhone(payload.telephoneNumber)) return showAlert("Telephone Number must contain 7 to 15 digits and no letters.");

    try {
        if (id) {
            await apiRequest(`clients/${id}`, { method: "PUT", body: JSON.stringify(payload) });
            showAlert("Client updated.", "success");
        } else {
            await apiRequest("clients", { method: "POST", body: JSON.stringify(payload) });
            showAlert("Client added.", "success");
        }
        clearClientForm();
        await refreshAll();
    } catch (err) {
        showAlert(err.message);
    }
});

window.deleteClient = async (id) => {
    if (!confirm("Delete this client?")) return;
    try {
        await apiRequest(`clients/${id}`, { method: "DELETE" });
        showAlert("Client deleted.", "success");
        await refreshAll();
    } catch (err) {
        showAlert(err.message);
    }
};

// ================= EMPLOYEES =================
function renderEmployees(employees) {
    const tbody = document.getElementById("employeesTableBody");
    tbody.innerHTML = employees.map((emp) => `
        <tr>
            <td>${emp.id}</td>
            <td><strong>${escapeHtml(emp.employeeCode)}</strong></td>
            <td>${escapeHtml(emp.firstName)}</td>
            <td>${escapeHtml(emp.lastName)}</td>
            <td>${escapeHtml(emp.role)}</td>
            <td>${escapeHtml(emp.email)}</td>
            <td class="action-cell">
                <button class="btn btn-secondary btn-sm" onclick='editEmployee(${JSON.stringify(emp)})'>Edit</button>
                <button class="btn btn-danger btn-sm" onclick="deleteEmployee(${emp.id})">Delete</button>
            </td>
        </tr>
    `).join("");
}

window.editEmployee = (emp) => {
    document.getElementById("employeeId").value = emp.id;
    document.getElementById("empCode").value = emp.employeeCode;
    document.getElementById("empFirstName").value = emp.firstName;
    document.getElementById("empLastName").value = emp.lastName;
    document.getElementById("empRole").value = emp.role;
    document.getElementById("empEmail").value = emp.email || "";
    document.getElementById("btnSaveEmployee").textContent = "Update Employee";
};

function clearEmployeeForm() {
    document.getElementById("employeeForm").reset();
    document.getElementById("employeeId").value = "";
    document.getElementById("btnSaveEmployee").textContent = "Add Employee";
}

document.getElementById("btnClearEmployee").addEventListener("click", clearEmployeeForm);

document.getElementById("employeeForm").addEventListener("submit", async (e) => {
    e.preventDefault();
    const id = document.getElementById("employeeId").value;
    const payload = {
        id: id ? Number(id) : 0,
        employeeCode: document.getElementById("empCode").value.trim(),
        firstName: document.getElementById("empFirstName").value.trim(),
        lastName: document.getElementById("empLastName").value.trim(),
        role: document.getElementById("empRole").value.trim(),
        email: document.getElementById("empEmail").value.trim()
    };

    if (!isValidCode(payload.employeeCode)) return showAlert("Employee Code may only contain letters, numbers, hyphens, or underscores.");
    if (!isValidPersonName(payload.firstName)) return showAlert("First Name must contain letters only.");
    if (!isValidPersonName(payload.lastName)) return showAlert("Last Name must contain letters only.");
    if (payload.role.length < 2) return showAlert("Role is required.");
    if (!isValidEmail(payload.email)) return showAlert("Please enter a valid Email address or leave it blank.");

    try {
        if (id) {
            await apiRequest(`employees/${id}`, { method: "PUT", body: JSON.stringify(payload) });
            showAlert("Employee updated.", "success");
        } else {
            await apiRequest("employees", { method: "POST", body: JSON.stringify(payload) });
            showAlert("Employee added.", "success");
        }
        clearEmployeeForm();
        await refreshAll();
    } catch (err) {
        showAlert(err.message);
    }
});

window.deleteEmployee = async (id) => {
    if (!confirm("Delete this employee?")) return;
    try {
        await apiRequest(`employees/${id}`, { method: "DELETE" });
        showAlert("Employee deleted.", "success");
        await refreshAll();
    } catch (err) {
        showAlert(err.message);
    }
};

["searchJobs", "searchTimecards", "searchClients", "searchEmployees"].forEach((id) => {
    document.getElementById(id).addEventListener("input", refreshAll);
});

document.getElementById("jobDate").value = toInputDate();
document.getElementById("tcDate").value = toInputDate();
refreshAll();