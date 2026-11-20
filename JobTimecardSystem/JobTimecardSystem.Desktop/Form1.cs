using JobTimecardSystem.Data.Models;
using JobTimecardSystem.Data.Models.JobTimecardSystem.Data.Models;
using JobTimecardSystem.Desktop.Services;
using System.Globalization;
using System.Net.Mail;
using System.Diagnostics;
using System.Net.Mail;
using JobTimecardSystem.Data.Models;
using JobTimecardSystem.Desktop.Services;

namespace JobTimecardSystem.Desktop
{
    public partial class Form1 : Form
    {
        private readonly ApiClient _api = new ApiClient("http://localhost:5295");

        private int? _selectedJobId = null;
        private int? _selectedTimecardId = null;
        private int? _selectedClientId = null;
        private int? _selectedEmployeeId = null;

        public Form1()
        {
            InitializeComponent();
            ConfigureControls();
            WireAllEvents();
        }

        private void WireAllEvents()
        {
            // 1. Form Load
            this.Load -= Form1_Load;
            this.Load += Form1_Load;

            // 2. Grids & Search Boxes
            dgvJobs.CellClick -= dgvJobs_CellClick;
            dgvJobs.CellClick += dgvJobs_CellClick;

            dgvTimecards.CellClick -= dgvTimecards_CellClick;
            dgvTimecards.CellClick += dgvTimecards_CellClick;

            dgvClients.CellClick -= dgvClients_CellClick;
            dgvClients.CellClick += dgvClients_CellClick;

            dgvEmployees.CellClick -= dgvEmployees_CellClick;
            dgvEmployees.CellClick += dgvEmployees_CellClick;

            txtSearchClient.TextChanged -= txtSearchClient_TextChanged;
            txtSearchClient.TextChanged += txtSearchClient_TextChanged;

            txtSearchEmployee.TextChanged -= txtSearchEmployee_TextChanged;
            txtSearchEmployee.TextChanged += txtSearchEmployee_TextChanged;

            // 3. Tab 1 (Jobs) & Tab 2 (Timecards) buttons (works even if still named button1/button2)
            var mainTabs = this.Controls.OfType<TabControl>().FirstOrDefault();
            if (mainTabs != null && mainTabs.TabPages.Count >= 1)
            {
                var jobsTab = mainTabs.TabPages[0];
                HookButtonByText(jobsTab, "Add Job", btnAddJob_Click);
                HookButtonByText(jobsTab, "Update Job", btnUpdateJob_Click);
                HookButtonByText(jobsTab, "Delete Job", btnDeleteJob_Click);
                HookButtonByText(jobsTab, "Clear", btnClearJob_Click);
                HookButtonByText(jobsTab, "Refresh", btnRefresh_Click);
            }

            if (mainTabs != null && mainTabs.TabPages.Count >= 2)
            {
                var timecardsTab = mainTabs.TabPages[1];
                HookButtonByText(timecardsTab, "Add Timecard", btnAddTimecard_Click);
                HookButtonByText(timecardsTab, "Update Timecard", btnUpdateTimecard_Click);
                HookButtonByText(timecardsTab, "Delete Timecard", btnDeleteTimecard_Click);
                HookButtonByText(timecardsTab, "Clear", btnClearTimecard_Click);
            }

            // 4. Tab 3 (Clients) & Tab 4 (Employees) buttons
            btnAddClient.Click -= btnAddClient_Click;
            btnAddClient.Click += btnAddClient_Click;
            btnUpdateClient.Click -= btnUpdateClient_Click;
            btnUpdateClient.Click += btnUpdateClient_Click;
            btnDeleteClient.Click -= btnDeleteClient_Click;
            btnDeleteClient.Click += btnDeleteClient_Click;
            btnClearClient.Click -= btnClearClient_Click;
            btnClearClient.Click += btnClearClient_Click;
            btnSearchClient.Click -= btnSearchClient_Click;
            btnSearchClient.Click += btnSearchClient_Click;

            btnAddEmployee.Click -= btnAddEmployee_Click;
            btnAddEmployee.Click += btnAddEmployee_Click;
            btnUpdateEmployee.Click -= btnUpdateEmployee_Click;
            btnUpdateEmployee.Click += btnUpdateEmployee_Click;
            btnDeleteEmployee.Click -= btnDeleteEmployee_Click;
            btnDeleteEmployee.Click += btnDeleteEmployee_Click;
            btnClearEmployee.Click -= btnClearEmployee_Click;
            btnClearEmployee.Click += btnClearEmployee_Click;
            btnSearchEmployee.Click -= btnSearchEmployee_Click;
            btnSearchEmployee.Click += btnSearchEmployee_Click;

            txtSearchJob.TextChanged -= txtSearchJob_TextChanged;
            txtSearchJob.TextChanged += txtSearchJob_TextChanged;
            btnSearchJob.Click -= btnSearchJob_Click;
            btnSearchJob.Click += btnSearchJob_Click;

            txtSearchTimecard.TextChanged -= txtSearchTimecard_TextChanged;
            txtSearchTimecard.TextChanged += txtSearchTimecard_TextChanged;
            btnSearchTimecard.Click -= btnSearchTimecard_Click;
            btnSearchTimecard.Click += btnSearchTimecard_Click;

            //5. Connecting Web based application on click
            HookButtonByText(this, "Web Dashboard", btnOpenWeb_Click);
        }

        private static void HookButtonByText(Control parent, string buttonTextPrefix, EventHandler handler)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is Button btn && btn.Text.Trim().StartsWith(buttonTextPrefix, StringComparison.OrdinalIgnoreCase))
                {
                    btn.Click -= handler;
                    btn.Click += handler;
                }
                if (c.HasChildren)
                {
                    HookButtonByText(c, buttonTextPrefix, handler);
                }
            }
        }
        private void btnOpenWeb_Click(object? sender, EventArgs e)
        {
            try
            {
                Process.Start(new ProcessStartInfo("http://localhost:5100")
                {
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                ShowRuntimeWarning("opening the Web Dashboard", ex);
            }
        }

        private void ConfigureControls()
        {
            cmbJobType.DataSource = Enum.GetValues(typeof(JobType));
            // Block letters in phone fields as the user types
            txtTelephone.KeyPress += Phone_KeyPress;
            txtClientPhone.KeyPress += Phone_KeyPress;

            // Configure NumericUpDown for decimal hours (e.g., 7.50)
            numHoursWorked.DecimalPlaces = 2;
            numHoursWorked.Increment = 0.5m;
            numHoursWorked.Minimum = 0;
            numHoursWorked.Maximum = 24;
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await RefreshAllAsync();
        }

        // =========================================================
        // DATA LOADING & REFRESH METHODS
        // =========================================================

        private async Task RefreshAllAsync()
        {
            try
            {
                for (int attempt = 1; attempt <= 15; attempt++)
                {
                    try
                    {
                        await RefreshJobsAndTimecardsAsync();
                        await RefreshClientsAsync();
                        await RefreshEmployeesAsync();

                        return;
                    }
                    catch (HttpRequestException) when (attempt < 15)
                    {
                        await Task.Delay(700);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Could not connect to the Web API. Ensure JobTimecardSystem.WebApi is running.\n\nDetails: {ex.Message}",
                    "API Connection Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private async Task RefreshJobsAndTimecardsAsync()
        {
            var allJobs = await _api.GetJobsAsync();
            var filteredJobs = await _api.GetJobsAsync(txtSearchJob.Text);

            dgvJobs.AutoGenerateColumns = true;
            dgvJobs.DataSource = null;
            dgvJobs.DataSource = filteredJobs;

            cmbJobSelect.DataSource = allJobs
                .Select(j => new JobDropdownItem
                {
                    Id = j.Id,
                    Display = $"{j.JobNumber} - {j.CompanyName} ({j.JobType})"
                })
                .ToList();
            cmbJobSelect.DisplayMember = nameof(JobDropdownItem.Display);
            cmbJobSelect.ValueMember = nameof(JobDropdownItem.Id);

            var timecards = await _api.GetTimecardsAsync(txtSearchTimecard.Text);

            dgvTimecards.AutoGenerateColumns = true;
            dgvTimecards.DataSource = null;
            dgvTimecards.DataSource = timecards.Select(t => new TimecardGridRow
            {
                Id = t.Id,
                JobId = t.JobId,
                JobNumber = t.Job?.JobNumber ?? $"Job #{t.JobId}",
                Company = t.Job?.CompanyName ?? string.Empty,
                Employee = t.Employee,
                DateWorked = t.DateWorked.ToShortDateString(),
                HoursWorked = t.HoursWorked
            }).ToList();
        }

        private async Task RefreshClientsAsync()
        {
            var clients = await _api.GetClientsAsync(txtSearchClient.Text);
            dgvClients.AutoGenerateColumns = true;
            dgvClients.DataSource = null;
            dgvClients.DataSource = clients;
        }

        private async Task RefreshEmployeesAsync()
        {
            var employees = await _api.GetEmployeesAsync(txtSearchEmployee.Text);
            dgvEmployees.AutoGenerateColumns = true;
            dgvEmployees.DataSource = null;
            dgvEmployees.DataSource = employees;
        }

        // =========================================================
        // TAB 1: JOBS EVENTS & HANDLERS
        // =========================================================

        private void ClearJobForm()
        {
            _selectedJobId = null;
            txtJobNumber.Clear();
            if (cmbJobType.Items.Count > 0) cmbJobType.SelectedIndex = 0;
            dtpJobDate.Value = DateTime.Today;
            txtCompanyName.Clear();
            txtContactName.Clear();
            txtTelephone.Clear();
            dgvJobs.ClearSelection();
        }

        private void dgvJobs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;
                if (dgvJobs.Rows[e.RowIndex].DataBoundItem is Job selected)
                {
                    _selectedJobId = selected.Id;
                    txtJobNumber.Text = selected.JobNumber;
                    cmbJobType.SelectedItem = selected.JobType;
                    dtpJobDate.Value = selected.JobDate;
                    txtCompanyName.Text = selected.CompanyName;
                    txtContactName.Text = selected.ContactName;
                    txtTelephone.Text = selected.TelephoneNumber;
                }
            }
            catch (Exception ex)
            {
                ShowRuntimeWarning("selecting a job", ex);
            }
        }

        private async void btnAddJob_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateJobInputs()) return;

                var job = new Job
                {
                    JobNumber = txtJobNumber.Text.Trim(),
                    JobType = (JobType)cmbJobType.SelectedItem!,
                    JobDate = dtpJobDate.Value.Date,
                    CompanyName = txtCompanyName.Text.Trim(),
                    ContactName = txtContactName.Text.Trim(),
                    TelephoneNumber = txtTelephone.Text.Trim()
                };

                var (success, error) = await _api.CreateJobAsync(job);
                if (!success)
                {
                    MessageBox.Show(error, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ClearJobForm();
                await RefreshJobsAndTimecardsAsync();
            }
            catch (Exception ex)
            {
                ShowRuntimeWarning("adding the job", ex);
            }
        }

        private async void btnUpdateJob_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selectedJobId == null)
                {
                    MessageBox.Show("Select a job from the grid first.", "No Job Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (!ValidateJobInputs()) return;

                var job = new Job
                {
                    Id = _selectedJobId.Value,
                    JobNumber = txtJobNumber.Text.Trim(),
                    JobType = (JobType)cmbJobType.SelectedItem!,
                    JobDate = dtpJobDate.Value.Date,
                    CompanyName = txtCompanyName.Text.Trim(),
                    ContactName = txtContactName.Text.Trim(),
                    TelephoneNumber = txtTelephone.Text.Trim()
                };

                var (success, error) = await _api.UpdateJobAsync(_selectedJobId.Value, job);
                if (!success)
                {
                    MessageBox.Show(error, "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ClearJobForm();
                await RefreshJobsAndTimecardsAsync();
            }
            catch (Exception ex)
            {
                ShowRuntimeWarning("updating the job", ex);
            }
        }

        private async void btnDeleteJob_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selectedJobId == null)
                {
                    MessageBox.Show("Select a job from the grid first.", "No Job Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var confirm = MessageBox.Show(
                    "Delete this job and its linked timecards?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (confirm != DialogResult.Yes) return;

                var (success, error) = await _api.DeleteJobAsync(_selectedJobId.Value);
                if (!success)
                {
                    MessageBox.Show(error, "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ClearJobForm();
                await RefreshJobsAndTimecardsAsync();
            }
            catch (Exception ex)
            {
                ShowRuntimeWarning("deleting the job", ex);
            }
        }

        private void btnClearJob_Click(object sender, EventArgs e)
        {
            ClearJobForm();
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await RefreshAllAsync();
        }

        // =========================================================
        // TAB 2: TIMECARDS EVENTS & HANDLERS
        // =========================================================

        private void ClearTimecardForm()
        {
            _selectedTimecardId = null;
            if (cmbJobSelect.Items.Count > 0) cmbJobSelect.SelectedIndex = 0;
            txtEmployee.Clear();
            dtpDateWorked.Value = DateTime.Today;
            numHoursWorked.Value = Math.Max(numHoursWorked.Minimum, 0);
            dgvTimecards.ClearSelection();
        }

        private void dgvTimecards_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;
                if (dgvTimecards.Rows[e.RowIndex].DataBoundItem is TimecardGridRow selected)
                {
                    _selectedTimecardId = selected.Id;
                    cmbJobSelect.SelectedValue = selected.JobId;
                    txtEmployee.Text = selected.Employee;
                    if (DateTime.TryParse(selected.DateWorked, out var parsedDate))
                    {
                        dtpDateWorked.Value = parsedDate;
                    }
                    numHoursWorked.Value = Math.Clamp(selected.HoursWorked, numHoursWorked.Minimum, numHoursWorked.Maximum);
                }
            }
            catch (Exception ex)
            {
                ShowRuntimeWarning("selecting a timecard", ex);
            }
        }

        private async void btnAddTimecard_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateTimecardInputs(out decimal hours)) return;

                var timecard = new Timecard
                {
                    JobId = (int)cmbJobSelect.SelectedValue!,
                    Employee = txtEmployee.Text.Trim(),
                    DateWorked = dtpDateWorked.Value.Date,
                    HoursWorked = hours
                };

                var (success, error) = await _api.CreateTimecardAsync(timecard);
                if (!success)
                {
                    MessageBox.Show(error, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ClearTimecardForm();
                await RefreshJobsAndTimecardsAsync();
            }
            catch (Exception ex)
            {
                ShowRuntimeWarning("adding the timecard", ex);
            }
        }

        private async void btnUpdateTimecard_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selectedTimecardId == null)
                {
                    MessageBox.Show("Select a timecard from the grid first.", "No Timecard Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (!ValidateTimecardInputs(out decimal hours)) return;

                var timecard = new Timecard
                {
                    Id = _selectedTimecardId.Value,
                    JobId = (int)cmbJobSelect.SelectedValue!,
                    Employee = txtEmployee.Text.Trim(),
                    DateWorked = dtpDateWorked.Value.Date,
                    HoursWorked = hours
                };

                var (success, error) = await _api.UpdateTimecardAsync(_selectedTimecardId.Value, timecard);
                if (!success)
                {
                    MessageBox.Show(error, "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ClearTimecardForm();
                await RefreshJobsAndTimecardsAsync();
            }
            catch (Exception ex)
            {
                ShowRuntimeWarning("updating the timecard", ex);
            }
        }

        private async void btnDeleteTimecard_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selectedTimecardId == null)
                {
                    MessageBox.Show("Select a timecard from the grid first.", "No Timecard Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var confirm = MessageBox.Show("Delete this timecard?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm != DialogResult.Yes) return;

                var (success, error) = await _api.DeleteTimecardAsync(_selectedTimecardId.Value);
                if (!success)
                {
                    MessageBox.Show(error, "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ClearTimecardForm();
                await RefreshJobsAndTimecardsAsync();
            }
            catch (Exception ex)
            {
                ShowRuntimeWarning("deleting the timecard", ex);
            }
        }

        private void btnClearTimecard_Click(object sender, EventArgs e)
        {
            ClearTimecardForm();
        }

        // =========================================================
        // TAB 3: CLIENTS EVENTS & HANDLERS
        // =========================================================

        private void ClearClientForm()
        {
            _selectedClientId = null;
            txtClientCompany.Clear();
            txtClientContact.Clear();
            txtClientPhone.Clear();
            dgvClients.ClearSelection();
        }

        private void dgvClients_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;
                if (dgvClients.Rows[e.RowIndex].DataBoundItem is Client selected)
                {
                    _selectedClientId = selected.Id;
                    txtClientCompany.Text = selected.CompanyName;
                    txtClientContact.Text = selected.ContactName;
                    txtClientPhone.Text = selected.TelephoneNumber;
                }
            }
            catch (Exception ex)
            {
                ShowRuntimeWarning("selecting a client", ex);
            }
        }

        private async void btnAddClient_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateClientInputs()) return;

                var client = new Client
                {
                    CompanyName = txtClientCompany.Text.Trim(),
                    ContactName = txtClientContact.Text.Trim(),
                    TelephoneNumber = txtClientPhone.Text.Trim(),
                };

                var (success, error) = await _api.CreateClientAsync(client);
                if (!success)
                {
                    MessageBox.Show(error, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ClearClientForm();
                await RefreshClientsAsync();
            }
            catch (Exception ex)
            {
                ShowRuntimeWarning("adding the client", ex);
            }
        }

        private async void btnUpdateClient_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selectedClientId == null)
                {
                    MessageBox.Show("Select a client from the grid first.", "No Client Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (!ValidateClientInputs()) return;

                var client = new Client
                {
                    Id = _selectedClientId.Value,
                    CompanyName = txtClientCompany.Text.Trim(),
                    ContactName = txtClientContact.Text.Trim(),
                    TelephoneNumber = txtClientPhone.Text.Trim(),
                };

                var (success, error) = await _api.UpdateClientAsync(_selectedClientId.Value, client);
                if (!success)
                {
                    MessageBox.Show(error, "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ClearClientForm();
                await RefreshClientsAsync();
            }
            catch (Exception ex)
            {
                ShowRuntimeWarning("updating the client", ex);
            }
        }

        private async void btnDeleteClient_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selectedClientId == null)
                {
                    MessageBox.Show("Select a client from the grid first.", "No Client Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var confirm = MessageBox.Show("Delete this client?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm != DialogResult.Yes) return;

                var (success, error) = await _api.DeleteClientAsync(_selectedClientId.Value);
                if (!success)
                {
                    MessageBox.Show(error, "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ClearClientForm();
                await RefreshClientsAsync();
            }
            catch (Exception ex)
            {
                ShowRuntimeWarning("deleting the client", ex);
            }
        }

        private void btnClearClient_Click(object sender, EventArgs e)
        {
            ClearClientForm();
        }

        private async void btnSearchClient_Click(object sender, EventArgs e)
        {
            try
            {
                await RefreshClientsAsync();
            }
            catch (Exception ex)
            {
                ShowRuntimeWarning("searching clients", ex);
            }
        }

        private async void txtSearchClient_TextChanged(object sender, EventArgs e)
        {
            try
            {
                await RefreshClientsAsync();
            }
            catch (Exception ex)
            {
                ShowRuntimeWarning("filtering clients", ex);
            }
        }

        // =========================================================
        // TAB 4: EMPLOYEES EVENTS & HANDLERS
        // =========================================================

        private void ClearEmployeeForm()
        {
            _selectedEmployeeId = null;
            txtEmpCode.Clear();
            txtEmpFirstName.Clear();
            txtEmpLastName.Clear();
            txtEmpRole.Clear();
            txtEmpEmail.Clear();
            dgvEmployees.ClearSelection();
        }

        private void dgvEmployees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;
                if (dgvEmployees.Rows[e.RowIndex].DataBoundItem is Employee selected)
                {
                    _selectedEmployeeId = selected.Id;
                    txtEmpCode.Text = selected.EmployeeCode;
                    txtEmpFirstName.Text = selected.FirstName;
                    txtEmpLastName.Text = selected.LastName;
                    txtEmpRole.Text = selected.Role;
                    txtEmpEmail.Text = selected.Email;
                }
            }
            catch (Exception ex)
            {
                ShowRuntimeWarning("selecting an employee", ex);
            }
        }

        private async void btnAddEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateEmployeeInputs()) return;

                var employee = new Employee
                {
                    EmployeeCode = txtEmpCode.Text.Trim(),
                    FirstName = txtEmpFirstName.Text.Trim(),
                    LastName = txtEmpLastName.Text.Trim(),
                    Role = txtEmpRole.Text.Trim(),
                    Email = txtEmpEmail.Text.Trim()
                };

                var (success, error) = await _api.CreateEmployeeAsync(employee);
                if (!success)
                {
                    MessageBox.Show(error, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ClearEmployeeForm();
                await RefreshEmployeesAsync();
            }
            catch (Exception ex)
            {
                ShowRuntimeWarning("adding the employee", ex);
            }
        }

        private async void btnUpdateEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selectedEmployeeId == null)
                {
                    MessageBox.Show("Select an employee from the grid first.", "No Employee Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (!ValidateEmployeeInputs()) return;

                var employee = new Employee
                {
                    Id = _selectedEmployeeId.Value,
                    EmployeeCode = txtEmpCode.Text.Trim(),
                    FirstName = txtEmpFirstName.Text.Trim(),
                    LastName = txtEmpLastName.Text.Trim(),
                    Role = txtEmpRole.Text.Trim(),
                    Email = txtEmpEmail.Text.Trim()
                };

                var (success, error) = await _api.UpdateEmployeeAsync(_selectedEmployeeId.Value, employee);
                if (!success)
                {
                    MessageBox.Show(error, "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ClearEmployeeForm();
                await RefreshEmployeesAsync();
            }
            catch (Exception ex)
            {
                ShowRuntimeWarning("updating the employee", ex);
            }
        }

        private async void btnDeleteEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selectedEmployeeId == null)
                {
                    MessageBox.Show("Select an employee from the grid first.", "No Employee Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var confirm = MessageBox.Show("Delete this employee?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm != DialogResult.Yes) return;

                var (success, error) = await _api.DeleteEmployeeAsync(_selectedEmployeeId.Value);
                if (!success)
                {
                    MessageBox.Show(error, "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ClearEmployeeForm();
                await RefreshEmployeesAsync();
            }
            catch (Exception ex)
            {
                ShowRuntimeWarning("deleting the employee", ex);
            }
        }

        private void btnClearEmployee_Click(object sender, EventArgs e)
        {
            ClearEmployeeForm();
        }

        private async void btnSearchEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                await RefreshEmployeesAsync();
            }
            catch (Exception ex)
            {
                ShowRuntimeWarning("searching employees", ex);
            }
        }

        private async void txtSearchEmployee_TextChanged(object sender, EventArgs e)
        {
            try
            {
                await RefreshEmployeesAsync();
            }
            catch (Exception ex)
            {
                ShowRuntimeWarning("filtering employees", ex);
            }
        }

        // =========================================================
        // KEYPRESS GUARDS & FORMAT VALIDATORS (ALL 4 TABS)
        // =========================================================

        private void Phone_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                e.KeyChar != '+' && e.KeyChar != '-' && e.KeyChar != ' ' &&
                e.KeyChar != '(' && e.KeyChar != ')')
            {
                e.Handled = true;
            }
        }

        private static void ShowRuntimeWarning(string actionDescription, Exception ex)
        {
            MessageBox.Show(
                $"An error occurred while {actionDescription}.\n\nDetails: {ex.Message}",
                "Operation Warning",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }

        private bool ShowValidationWarning(string message, Control controlToFocus)
        {
            MessageBox.Show(message, "Invalid Input Format", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            controlToFocus.Focus();
            return false;
        }

        private static bool IsValidPersonName(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Trim().Length < 2) return false;
            return value.Trim().All(c => char.IsLetter(c) || c == ' ' || c == '-' || c == '\'');
        }

        private static bool IsValidCode(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Trim().Length < 2) return false;
            return value.Trim().All(c => char.IsLetterOrDigit(c) || c == '-' || c == '_');
        }

        private static bool IsValidPhone(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return false;
            int digitCount = value.Count(char.IsDigit);
            return digitCount >= 7 && digitCount <= 15 &&
                   value.All(c => char.IsDigit(c) || "+- ()".Contains(c));
        }

        private static bool IsValidEmail(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return true;
            if (!MailAddress.TryCreate(value.Trim(), out var addr)) return false;
            return addr.Host.Contains('.') && !addr.Host.StartsWith('.') && !addr.Host.EndsWith('.');
        }

        private bool ValidateJobInputs()
        {
            if (!IsValidCode(txtJobNumber.Text))
                return ShowValidationWarning("Job Number is required and may only contain letters, numbers, hyphens (-), or underscores (_).", txtJobNumber);

            if (cmbJobType.SelectedItem == null)
                return ShowValidationWarning("Please select a valid Job Type from the dropdown.", cmbJobType);

            if (string.IsNullOrWhiteSpace(txtCompanyName.Text) || txtCompanyName.Text.Trim().Length < 2)
                return ShowValidationWarning("Company Name is required and must be at least 2 characters.", txtCompanyName);

            if (!IsValidPersonName(txtContactName.Text))
                return ShowValidationWarning("Contact Name is required and may only contain letters, spaces, hyphens, or apostrophes (no numbers).", txtContactName);

            if (!IsValidPhone(txtTelephone.Text))
                return ShowValidationWarning("Telephone Number must contain 7 to 15 digits and no letters (e.g., 012 345 6789).", txtTelephone);

            return true;
        }

        private bool ValidateTimecardInputs(out decimal parsedHours)
        {
            parsedHours = numHoursWorked.Value;

            if (cmbJobSelect.SelectedValue is not int)
                return ShowValidationWarning("Please select a valid Job from the dropdown list.", cmbJobSelect);

            if (!IsValidPersonName(txtEmployee.Text))
                return ShowValidationWarning("Employee Name is required and may only contain letters, spaces, hyphens, or apostrophes (no numbers).", txtEmployee);

            if (parsedHours <= 0 || parsedHours > 24)
                return ShowValidationWarning("Hours Worked must be greater than 0 and up to 24 (e.g., 7.5).", numHoursWorked);

            return true;
        }

        private bool ValidateClientInputs()
        {
            if (string.IsNullOrWhiteSpace(txtClientCompany.Text) || txtClientCompany.Text.Trim().Length < 2)
                return ShowValidationWarning("Company Name is required and must be at least 2 characters.", txtClientCompany);

            if (!IsValidPersonName(txtClientContact.Text))
                return ShowValidationWarning("Contact Name is required and may only contain letters, spaces, hyphens, or apostrophes (no numbers).", txtClientContact);

            if (!IsValidPhone(txtClientPhone.Text))
                return ShowValidationWarning("Telephone Number must contain 7 to 15 digits and no letters (e.g., 012 345 6789).", txtClientPhone);

            return true;
        }

        private bool ValidateEmployeeInputs()
        {
            if (!IsValidCode(txtEmpCode.Text))
                return ShowValidationWarning("Employee Code is required and may only contain letters, numbers, hyphens (-), or underscores (_).", txtEmpCode);

            if (!IsValidPersonName(txtEmpFirstName.Text))
                return ShowValidationWarning("First Name is required and may only contain letters (no numbers).", txtEmpFirstName);

            if (!IsValidPersonName(txtEmpLastName.Text))
                return ShowValidationWarning("Last Name is required and may only contain letters (no numbers).", txtEmpLastName);

            if (string.IsNullOrWhiteSpace(txtEmpRole.Text) || txtEmpRole.Text.Trim().Length < 2)
                return ShowValidationWarning("Role is required and must be at least 2 characters.", txtEmpRole);

            if (!IsValidEmail(txtEmpEmail.Text))
                return ShowValidationWarning("Please enter a valid Email address (e.g., employee@company.co.za) or leave it blank.", txtEmpEmail);

            return true;
        }
        private async void btnSearchJob_Click(object? sender, EventArgs e)
        {
            try
            {
                await RefreshJobsAndTimecardsAsync();
            }
            catch (Exception ex)
            {
                ShowRuntimeWarning("searching jobs", ex);
            }
        }

        private async void txtSearchJob_TextChanged(object? sender, EventArgs e)
        {
            try
            {
                await RefreshJobsAndTimecardsAsync();
            }
            catch (Exception ex)
            {
                ShowRuntimeWarning("filtering jobs", ex);
            }
        }

        private async void btnSearchTimecard_Click(object? sender, EventArgs e)
        {
            try
            {
                await RefreshJobsAndTimecardsAsync();
            }
            catch (Exception ex)
            {
                ShowRuntimeWarning("searching timecards", ex);
            }
        }

        private async void txtSearchTimecard_TextChanged(object? sender, EventArgs e)
        {
            try
            {
                await RefreshJobsAndTimecardsAsync();
            }
            catch (Exception ex)
            {
                ShowRuntimeWarning("filtering timecards", ex);
            }
        }
    }

    public class JobDropdownItem
    {
        public int Id { get; set; }
        public string Display { get; set; } = string.Empty;
    }

    public class TimecardGridRow
    {
        public int Id { get; set; }
        public int JobId { get; set; }
        public string JobNumber { get; set; } = string.Empty;
        public string Company { get; set; } = string.Empty;
        public string Employee { get; set; } = string.Empty;
        public string DateWorked { get; set; } = string.Empty;
        public decimal HoursWorked { get; set; }
    }

}

