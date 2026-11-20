using JobTimecardSystem.Data.Models;
using JobTimecardSystem.Desktop.Services;

namespace JobTimecardSystem.Desktop
{
    public partial class Form1 : Form
    {
        private readonly ApiClient _api = new ApiClient("https://localhost:7023");
        private int? _selectedJobId = null;
        private int? _selectedTimecardId = null;

        public Form1()
        {
            InitializeComponent();
            WireEvents();
        }

        private void WireEvents()
        {
            cmbJobType.DataSource = Enum.GetValues(typeof(JobType));
            Load += async (_, _) => await RefreshAllAsync();

            // Jobs tab events
            btnAddJob.Click += async (_, _) => await SaveJobAsync(isUpdate: false);
            btnUpdateJob.Click += async (_, _) => await SaveJobAsync(isUpdate: true);
            btnDeleteJob.Click += async (_, _) => await DeleteJobAsync();
            btnClearJob.Click += (_, _) => ClearJobForm();
            btnRefreshJob.Click += async (_, _) => await RefreshAllAsync();
            dgvJobs.CellClick += (_, _) => PopulateJobFromSelection();

            // Timecards tab events
            btnAddTimecard.Click += async (_, _) => await SaveTimecardAsync(isUpdate: false);
            btnUpdateTimecard.Click += async (_, _) => await SaveTimecardAsync(isUpdate: true);
            btnDeleteTimecard.Click += async (_, _) => await DeleteTimecardAsync();
            btnClearTimecard.Click += (_, _) => ClearTimecardForm();
            btnRefreshTimecard.Click += async (_, _) => await RefreshAllAsync();
            dgvTimecards.CellClick += (_, _) => PopulateTimecardFromSelection();
        }

        private async Task RefreshAllAsync()
        {
            try
            {
                for (int attempt = 1; attempt <= 6; attempt++)
                {
                    try
                    {
                        var jobs = await _api.GetJobsAsync();

                        dgvJobs.AutoGenerateColumns = true;
                        dgvJobs.DataSource = null;
                        dgvJobs.DataSource = jobs;

                        cmbJobSelect.DataSource = jobs
                            .Select(j => new JobDropdownItem
                            {
                                Id = j.Id,
                                Display = $"{j.JobNumber} - {j.CompanyName} ({j.JobType})"
                            })
                            .ToList();
                        cmbJobSelect.DisplayMember = nameof(JobDropdownItem.Display);
                        cmbJobSelect.ValueMember = nameof(JobDropdownItem.Id);

                        var timecards = await _api.GetTimecardsAsync();

                        dgvTimecards.AutoGenerateColumns = true;
                        dgvTimecards.DataSource = null;
                        dgvTimecards.DataSource = timecards.Select(t => new TimecardGridRow
                        {
                            Id = t.Id,
                            JobId = t.JobId,
                            JobNumber = t.Job?.JobNumber ?? $"Job #{t.JobId}",
                            Company = t.Job?.CompanyName ?? "",
                            Employee = t.Employee,
                            DateWorked = t.DateWorked.ToShortDateString(),
                            HoursWorked = t.HoursWorked
                        }).ToList();

                        return;
                    }
                    catch (HttpRequestException) when (attempt < 6)
                    {
                        await Task.Delay(500);
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

        // --- JOBS CRUD ---
        private void PopulateJobFromSelection()
        {
            if (dgvJobs.CurrentRow?.DataBoundItem is not Job job) return;
            _selectedJobId = job.Id;
            txtJobNumber.Text = job.JobNumber;
            cmbJobType.SelectedItem = job.JobType;
            dtpJobDate.Value = job.JobDate;
            txtCompanyName.Text = job.CompanyName;
            txtContactName.Text = job.ContactName;
            txtTelephone.Text = job.TelephoneNumber;
        }

        private async Task SaveJobAsync(bool isUpdate)
        {
            if (isUpdate && !_selectedJobId.HasValue)
            {
                MessageBox.Show("Select a job from the grid first to update it.", "No Job Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var job = new Job
            {
                Id = _selectedJobId ?? 0,
                JobNumber = txtJobNumber.Text,
                JobType = (JobType)cmbJobType.SelectedItem!,
                JobDate = dtpJobDate.Value.Date,
                CompanyName = txtCompanyName.Text,
                ContactName = txtContactName.Text,
                TelephoneNumber = txtTelephone.Text
            };

            var (success, error) = isUpdate
                ? await _api.UpdateJobAsync(_selectedJobId!.Value, job)
                : await _api.CreateJobAsync(job);

            if (!success)
            {
                MessageBox.Show(error, "Validation / API Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ClearJobForm();
            await RefreshAllAsync();
        }

        private async Task DeleteJobAsync()
        {
            if (!_selectedJobId.HasValue)
            {
                MessageBox.Show("Select a job from the grid first.", "No Job Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirm = MessageBox.Show("Delete selected job?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            var (success, error) = await _api.DeleteJobAsync(_selectedJobId.Value);
            if (!success)
            {
                MessageBox.Show(error, "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ClearJobForm();
            await RefreshAllAsync();
        }

        private void ClearJobForm()
        {
            _selectedJobId = null;
            txtJobNumber.Clear();
            if (cmbJobType.Items.Count > 0) cmbJobType.SelectedIndex = 0;
            dtpJobDate.Value = DateTime.Today;
            txtCompanyName.Clear();
            txtContactName.Clear();
            txtTelephone.Clear();
        }

        // --- TIMECARDS CRUD ---
        private void PopulateTimecardFromSelection()
        {
            if (dgvTimecards.CurrentRow?.DataBoundItem is not TimecardGridRow row) return;
            _selectedTimecardId = row.Id;
            cmbJobSelect.SelectedValue = row.JobId;
            txtEmployee.Text = row.Employee;
            if (DateTime.TryParse(row.DateWorked, out var parsedDate))
                dtpDateWorked.Value = parsedDate;
            numHoursWorked.Value = row.HoursWorked;
        }

        private async Task SaveTimecardAsync(bool isUpdate)
        {
            if (isUpdate && !_selectedTimecardId.HasValue)
            {
                MessageBox.Show("Select a timecard from the grid first to update it.", "No Timecard Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (cmbJobSelect.SelectedValue is not int jobId)
            {
                MessageBox.Show("Create and select a Job first.", "No Job Available", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var timecard = new Timecard
            {
                Id = _selectedTimecardId ?? 0,
                JobId = jobId,
                Employee = txtEmployee.Text,
                DateWorked = dtpDateWorked.Value.Date,
                HoursWorked = numHoursWorked.Value
            };

            var (success, error) = isUpdate
                ? await _api.UpdateTimecardAsync(_selectedTimecardId!.Value, timecard)
                : await _api.CreateTimecardAsync(timecard);

            if (!success)
            {
                MessageBox.Show(error, "Validation / API Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ClearTimecardForm();
            await RefreshAllAsync();
        }

        private async Task DeleteTimecardAsync()
        {
            if (!_selectedTimecardId.HasValue)
            {
                MessageBox.Show("Select a timecard from the grid first.", "No Timecard Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirm = MessageBox.Show("Delete selected timecard?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            var (success, error) = await _api.DeleteTimecardAsync(_selectedTimecardId.Value);
            if (!success)
            {
                MessageBox.Show(error, "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ClearTimecardForm();
            await RefreshAllAsync();
        }

        private void ClearTimecardForm()
        {
            _selectedTimecardId = null;
            txtEmployee.Clear();
            dtpDateWorked.Value = DateTime.Today;
            numHoursWorked.Value = 8.00m;
        }

        private class JobDropdownItem
        {
            public int Id { get; set; }
            public string Display { get; set; } = string.Empty;
        }

        private class TimecardGridRow
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
}