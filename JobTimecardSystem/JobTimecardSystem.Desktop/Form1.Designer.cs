namespace JobTimecardSystem.Desktop
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabControlMain = new TabControl();
            tabJobs = new TabPage();
            dgvJobs = new DataGridView();
            flpJobButtons = new FlowLayoutPanel();
            btnAddJob = new Button();
            btnUpdateJob = new Button();
            btnDeleteJob = new Button();
            btnClearJob = new Button();
            btnRefreshJob = new Button();
            flpJobInputs = new FlowLayoutPanel();
            pnlJobNum = new Panel();
            txtJobNumber = new TextBox();
            lblJobNum = new Label();
            pnlJobType = new Panel();
            cmbJobType = new ComboBox();
            lblJobType = new Label();
            pnlJobDate = new Panel();
            dtpJobDate = new DateTimePicker();
            lblJobDate = new Label();
            pnlCompanyName = new Panel();
            txtCompanyName = new TextBox();
            lblCompanyName = new Label();
            pnlContactName = new Panel();
            txtContactName = new TextBox();
            lblContactName = new Label();
            pnlTelephone = new Panel();
            txtTelephone = new TextBox();
            lblTelephone = new Label();
            pnlJobSearch = new Panel();
            btnSearchJob = new Button();
            txtSearchJob = new TextBox();
            lblSearchJob = new Label();
            tabTimecards = new TabPage();
            dgvTimecards = new DataGridView();
            flpTimecardButtons = new FlowLayoutPanel();
            btnAddTimecard = new Button();
            btnUpdateTimecard = new Button();
            btnDeleteTimecard = new Button();
            btnClearTimecard = new Button();
            btnRefreshTimecard = new Button();
            flpTimecardInputs = new FlowLayoutPanel();
            pnlJobSelect = new Panel();
            cmbJobSelect = new ComboBox();
            lblJobSelect = new Label();
            pnlEmployee = new Panel();
            txtEmployee = new TextBox();
            lblEmployee = new Label();
            pnlDateWorked = new Panel();
            dtpDateWorked = new DateTimePicker();
            lblDateWorked = new Label();
            pnlHoursWorked = new Panel();
            numHoursWorked = new NumericUpDown();
            lblHoursWorked = new Label();
            pnlTimecardSearch = new Panel();
            btnSearchTimecard = new Button();
            txtSearchTimecard = new TextBox();
            lblSearchTimecard = new Label();
            tabClients = new TabPage();
            dgvClients = new DataGridView();
            flpClientButtons = new FlowLayoutPanel();
            btnAddClient = new Button();
            btnUpdateClient = new Button();
            btnDeleteClient = new Button();
            btnClearClient = new Button();
            flpClientsInputs = new FlowLayoutPanel();
            pnlClientCompany = new Panel();
            txtClientCompany = new TextBox();
            lblClientCompany = new Label();
            pnlClientContact = new Panel();
            txtClientContact = new TextBox();
            lblClientContact = new Label();
            pnlClientPhone = new Panel();
            txtClientPhone = new TextBox();
            lblClientPhone = new Label();
            pnlClientSearch = new Panel();
            btnSearchClient = new Button();
            txtSearchClient = new TextBox();
            lblSearchClient = new Label();
            tabEmployees = new TabPage();
            dgvEmployees = new DataGridView();
            flpEmployeeInputs = new FlowLayoutPanel();
            pnlEmpCode = new Panel();
            txtEmpCode = new TextBox();
            lblEmpCode = new Label();
            pnlEmpFirstName = new Panel();
            txtEmpFirstName = new TextBox();
            lblEmpFirstName = new Label();
            pnlEmpLastName = new Panel();
            txtEmpLastName = new TextBox();
            lblEmpLastName = new Label();
            pnlEmpRole = new Panel();
            txtEmpRole = new TextBox();
            lblEmpRole = new Label();
            pnlEmpEmail = new Panel();
            txtEmpEmail = new TextBox();
            lblEmpEmail = new Label();
            pnlEmpSearch = new Panel();
            btnSearchEmployee = new Button();
            txtSearchEmployee = new TextBox();
            lblSearchEmployee = new Label();
            flpEmployeeButtons = new FlowLayoutPanel();
            btnAddEmployee = new Button();
            btnUpdateEmployee = new Button();
            btnDeleteEmployee = new Button();
            btnClearEmployee = new Button();
            btnOpenWeb = new Button();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            tabControlMain.SuspendLayout();
            tabJobs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvJobs).BeginInit();
            flpJobButtons.SuspendLayout();
            flpJobInputs.SuspendLayout();
            pnlJobNum.SuspendLayout();
            pnlJobType.SuspendLayout();
            pnlJobDate.SuspendLayout();
            pnlCompanyName.SuspendLayout();
            pnlContactName.SuspendLayout();
            pnlTelephone.SuspendLayout();
            pnlJobSearch.SuspendLayout();
            tabTimecards.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTimecards).BeginInit();
            flpTimecardButtons.SuspendLayout();
            flpTimecardInputs.SuspendLayout();
            pnlJobSelect.SuspendLayout();
            pnlEmployee.SuspendLayout();
            pnlDateWorked.SuspendLayout();
            pnlHoursWorked.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numHoursWorked).BeginInit();
            pnlTimecardSearch.SuspendLayout();
            tabClients.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvClients).BeginInit();
            flpClientButtons.SuspendLayout();
            flpClientsInputs.SuspendLayout();
            pnlClientCompany.SuspendLayout();
            pnlClientContact.SuspendLayout();
            pnlClientPhone.SuspendLayout();
            pnlClientSearch.SuspendLayout();
            tabEmployees.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).BeginInit();
            flpEmployeeInputs.SuspendLayout();
            pnlEmpCode.SuspendLayout();
            pnlEmpFirstName.SuspendLayout();
            pnlEmpLastName.SuspendLayout();
            pnlEmpRole.SuspendLayout();
            pnlEmpEmail.SuspendLayout();
            pnlEmpSearch.SuspendLayout();
            flpEmployeeButtons.SuspendLayout();
            SuspendLayout();
            // 
            // tabControlMain
            // 
            tabControlMain.Controls.Add(tabJobs);
            tabControlMain.Controls.Add(tabTimecards);
            tabControlMain.Controls.Add(tabClients);
            tabControlMain.Controls.Add(tabEmployees);
            tabControlMain.Dock = DockStyle.Fill;
            tabControlMain.ImeMode = ImeMode.Off;
            tabControlMain.Location = new Point(0, 0);
            tabControlMain.Name = "tabControlMain";
            tabControlMain.SelectedIndex = 0;
            tabControlMain.Size = new Size(984, 641);
            tabControlMain.TabIndex = 0;
            // 
            // tabJobs
            // 
            tabJobs.Controls.Add(dgvJobs);
            tabJobs.Controls.Add(flpJobButtons);
            tabJobs.Controls.Add(flpJobInputs);
            tabJobs.Location = new Point(4, 24);
            tabJobs.Name = "tabJobs";
            tabJobs.Padding = new Padding(3);
            tabJobs.Size = new Size(976, 613);
            tabJobs.TabIndex = 0;
            tabJobs.Text = "Jobs";
            tabJobs.UseVisualStyleBackColor = true;
            // 
            // dgvJobs
            // 
            dgvJobs.AllowUserToAddRows = false;
            dgvJobs.AllowUserToDeleteRows = false;
            dgvJobs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvJobs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvJobs.Dock = DockStyle.Fill;
            dgvJobs.Location = new Point(3, 187);
            dgvJobs.MultiSelect = false;
            dgvJobs.Name = "dgvJobs";
            dgvJobs.ReadOnly = true;
            dgvJobs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvJobs.Size = new Size(970, 423);
            dgvJobs.TabIndex = 0;
            // 
            // flpJobButtons
            // 
            flpJobButtons.AutoSize = true;
            flpJobButtons.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flpJobButtons.Controls.Add(btnAddJob);
            flpJobButtons.Controls.Add(btnUpdateJob);
            flpJobButtons.Controls.Add(btnDeleteJob);
            flpJobButtons.Controls.Add(btnClearJob);
            flpJobButtons.Controls.Add(btnRefreshJob);
            flpJobButtons.Controls.Add(btnOpenWeb);
            flpJobButtons.Dock = DockStyle.Top;
            flpJobButtons.Location = new Point(3, 137);
            flpJobButtons.Name = "flpJobButtons";
            flpJobButtons.Padding = new Padding(10, 6, 10, 6);
            flpJobButtons.Size = new Size(970, 50);
            flpJobButtons.TabIndex = 1;
            // 
            // btnAddJob
            // 
            btnAddJob.Location = new Point(13, 9);
            btnAddJob.Name = "btnAddJob";
            btnAddJob.Size = new Size(115, 32);
            btnAddJob.TabIndex = 0;
            btnAddJob.Text = "Add Job";
            btnAddJob.UseVisualStyleBackColor = true;
            // 
            // btnUpdateJob
            // 
            btnUpdateJob.Location = new Point(134, 9);
            btnUpdateJob.Name = "btnUpdateJob";
            btnUpdateJob.Size = new Size(115, 32);
            btnUpdateJob.TabIndex = 1;
            btnUpdateJob.Text = "Update Job";
            btnUpdateJob.UseVisualStyleBackColor = true;
            // 
            // btnDeleteJob
            // 
            btnDeleteJob.Location = new Point(255, 9);
            btnDeleteJob.Name = "btnDeleteJob";
            btnDeleteJob.Size = new Size(115, 32);
            btnDeleteJob.TabIndex = 2;
            btnDeleteJob.Text = "Delete Job";
            btnDeleteJob.UseVisualStyleBackColor = true;
            // 
            // btnClearJob
            // 
            btnClearJob.Location = new Point(376, 9);
            btnClearJob.Name = "btnClearJob";
            btnClearJob.Size = new Size(115, 32);
            btnClearJob.TabIndex = 3;
            btnClearJob.Text = "Clear";
            btnClearJob.UseVisualStyleBackColor = true;
            // 
            // btnRefreshJob
            // 
            btnRefreshJob.Location = new Point(497, 9);
            btnRefreshJob.Name = "btnRefreshJob";
            btnRefreshJob.Size = new Size(115, 32);
            btnRefreshJob.TabIndex = 4;
            btnRefreshJob.Text = "Refresh";
            btnRefreshJob.UseVisualStyleBackColor = true;
            // 
            // flpJobInputs
            // 
            flpJobInputs.AutoSize = true;
            flpJobInputs.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flpJobInputs.Controls.Add(pnlJobNum);
            flpJobInputs.Controls.Add(pnlJobType);
            flpJobInputs.Controls.Add(pnlJobDate);
            flpJobInputs.Controls.Add(pnlCompanyName);
            flpJobInputs.Controls.Add(pnlContactName);
            flpJobInputs.Controls.Add(pnlTelephone);
            flpJobInputs.Controls.Add(pnlJobSearch);
            flpJobInputs.Dock = DockStyle.Top;
            flpJobInputs.Location = new Point(3, 3);
            flpJobInputs.Name = "flpJobInputs";
            flpJobInputs.Padding = new Padding(10, 10, 10, 4);
            flpJobInputs.Size = new Size(970, 134);
            flpJobInputs.TabIndex = 2;
            // 
            // pnlJobNum
            // 
            pnlJobNum.Controls.Add(txtJobNumber);
            pnlJobNum.Controls.Add(lblJobNum);
            pnlJobNum.Location = new Point(14, 14);
            pnlJobNum.Margin = new Padding(4, 4, 12, 4);
            pnlJobNum.Name = "pnlJobNum";
            pnlJobNum.Size = new Size(220, 52);
            pnlJobNum.TabIndex = 0;
            // 
            // txtJobNumber
            // 
            txtJobNumber.Location = new Point(0, 20);
            txtJobNumber.Name = "txtJobNumber";
            txtJobNumber.Size = new Size(215, 23);
            txtJobNumber.TabIndex = 1;
            // 
            // lblJobNum
            // 
            lblJobNum.AutoSize = true;
            lblJobNum.Location = new Point(0, 0);
            lblJobNum.Name = "lblJobNum";
            lblJobNum.Size = new Size(75, 15);
            lblJobNum.TabIndex = 0;
            lblJobNum.Text = "Job Number:";
            // 
            // pnlJobType
            // 
            pnlJobType.Controls.Add(cmbJobType);
            pnlJobType.Controls.Add(lblJobType);
            pnlJobType.Location = new Point(250, 14);
            pnlJobType.Margin = new Padding(4, 4, 12, 4);
            pnlJobType.Name = "pnlJobType";
            pnlJobType.Size = new Size(220, 52);
            pnlJobType.TabIndex = 1;
            // 
            // cmbJobType
            // 
            cmbJobType.FormattingEnabled = true;
            cmbJobType.Location = new Point(0, 20);
            cmbJobType.Name = "cmbJobType";
            cmbJobType.Size = new Size(215, 23);
            cmbJobType.TabIndex = 1;
            // 
            // lblJobType
            // 
            lblJobType.AutoSize = true;
            lblJobType.Location = new Point(0, 0);
            lblJobType.Name = "lblJobType";
            lblJobType.Size = new Size(56, 15);
            lblJobType.TabIndex = 0;
            lblJobType.Text = "Job Type:";
            // 
            // pnlJobDate
            // 
            pnlJobDate.Controls.Add(dtpJobDate);
            pnlJobDate.Controls.Add(lblJobDate);
            pnlJobDate.Location = new Point(486, 14);
            pnlJobDate.Margin = new Padding(4, 4, 12, 4);
            pnlJobDate.Name = "pnlJobDate";
            pnlJobDate.Size = new Size(220, 52);
            pnlJobDate.TabIndex = 2;
            // 
            // dtpJobDate
            // 
            dtpJobDate.Format = DateTimePickerFormat.Short;
            dtpJobDate.Location = new Point(0, 20);
            dtpJobDate.Name = "dtpJobDate";
            dtpJobDate.Size = new Size(215, 23);
            dtpJobDate.TabIndex = 1;
            // 
            // lblJobDate
            // 
            lblJobDate.AutoSize = true;
            lblJobDate.Location = new Point(0, 0);
            lblJobDate.Name = "lblJobDate";
            lblJobDate.Size = new Size(52, 15);
            lblJobDate.TabIndex = 0;
            lblJobDate.Text = "Job Date";
            // 
            // pnlCompanyName
            // 
            pnlCompanyName.Controls.Add(txtCompanyName);
            pnlCompanyName.Controls.Add(lblCompanyName);
            pnlCompanyName.Location = new Point(722, 14);
            pnlCompanyName.Margin = new Padding(4, 4, 12, 4);
            pnlCompanyName.Name = "pnlCompanyName";
            pnlCompanyName.Size = new Size(220, 52);
            pnlCompanyName.TabIndex = 3;
            // 
            // txtCompanyName
            // 
            txtCompanyName.Location = new Point(0, 20);
            txtCompanyName.Name = "txtCompanyName";
            txtCompanyName.Size = new Size(215, 23);
            txtCompanyName.TabIndex = 1;
            // 
            // lblCompanyName
            // 
            lblCompanyName.AutoSize = true;
            lblCompanyName.Location = new Point(0, 0);
            lblCompanyName.Name = "lblCompanyName";
            lblCompanyName.Size = new Size(97, 15);
            lblCompanyName.TabIndex = 0;
            lblCompanyName.Text = "Company Name:";
            // 
            // pnlContactName
            // 
            pnlContactName.Controls.Add(txtContactName);
            pnlContactName.Controls.Add(lblContactName);
            pnlContactName.Location = new Point(14, 74);
            pnlContactName.Margin = new Padding(4, 4, 12, 4);
            pnlContactName.Name = "pnlContactName";
            pnlContactName.Size = new Size(220, 52);
            pnlContactName.TabIndex = 4;
            // 
            // txtContactName
            // 
            txtContactName.Location = new Point(0, 20);
            txtContactName.Name = "txtContactName";
            txtContactName.Size = new Size(215, 23);
            txtContactName.TabIndex = 1;
            // 
            // lblContactName
            // 
            lblContactName.AutoSize = true;
            lblContactName.Location = new Point(0, 0);
            lblContactName.Name = "lblContactName";
            lblContactName.Size = new Size(84, 15);
            lblContactName.TabIndex = 0;
            lblContactName.Text = "Contact Name";
            // 
            // pnlTelephone
            // 
            pnlTelephone.Controls.Add(txtTelephone);
            pnlTelephone.Controls.Add(lblTelephone);
            pnlTelephone.Location = new Point(250, 74);
            pnlTelephone.Margin = new Padding(4, 4, 12, 4);
            pnlTelephone.Name = "pnlTelephone";
            pnlTelephone.Size = new Size(220, 52);
            pnlTelephone.TabIndex = 5;
            // 
            // txtTelephone
            // 
            txtTelephone.Location = new Point(0, 20);
            txtTelephone.Name = "txtTelephone";
            txtTelephone.Size = new Size(215, 23);
            txtTelephone.TabIndex = 1;
            // 
            // lblTelephone
            // 
            lblTelephone.AutoSize = true;
            lblTelephone.Location = new Point(0, 0);
            lblTelephone.Name = "lblTelephone";
            lblTelephone.Size = new Size(62, 15);
            lblTelephone.TabIndex = 0;
            lblTelephone.Text = "Telephone";
            // 
            // pnlJobSearch
            // 
            pnlJobSearch.Controls.Add(btnSearchJob);
            pnlJobSearch.Controls.Add(txtSearchJob);
            pnlJobSearch.Controls.Add(lblSearchJob);
            pnlJobSearch.Location = new Point(485, 73);
            pnlJobSearch.Margin = new Padding(3, 3, 12, 6);
            pnlJobSearch.Name = "pnlJobSearch";
            pnlJobSearch.Size = new Size(270, 50);
            pnlJobSearch.TabIndex = 6;
            // 
            // btnSearchJob
            // 
            btnSearchJob.Location = new Point(186, 21);
            btnSearchJob.Name = "btnSearchJob";
            btnSearchJob.Size = new Size(75, 25);
            btnSearchJob.TabIndex = 2;
            btnSearchJob.Text = "Search";
            btnSearchJob.UseVisualStyleBackColor = true;
            // 
            // txtSearchJob
            // 
            txtSearchJob.Location = new Point(0, 22);
            txtSearchJob.Name = "txtSearchJob";
            txtSearchJob.PlaceholderText = "Type to search...";
            txtSearchJob.Size = new Size(180, 23);
            txtSearchJob.TabIndex = 1;
            // 
            // lblSearchJob
            // 
            lblSearchJob.AutoSize = true;
            lblSearchJob.Location = new Point(0, 0);
            lblSearchJob.Name = "lblSearchJob";
            lblSearchJob.Size = new Size(71, 15);
            lblSearchJob.TabIndex = 0;
            lblSearchJob.Text = "Search Jobs:";
            // 
            // tabTimecards
            // 
            tabTimecards.Controls.Add(dgvTimecards);
            tabTimecards.Controls.Add(flpTimecardButtons);
            tabTimecards.Controls.Add(flpTimecardInputs);
            tabTimecards.Location = new Point(4, 24);
            tabTimecards.Name = "tabTimecards";
            tabTimecards.Padding = new Padding(3);
            tabTimecards.Size = new Size(976, 613);
            tabTimecards.TabIndex = 1;
            tabTimecards.Text = "Timecards";
            tabTimecards.UseVisualStyleBackColor = true;
            // 
            // dgvTimecards
            // 
            dgvTimecards.AllowUserToAddRows = false;
            dgvTimecards.AllowUserToDeleteRows = false;
            dgvTimecards.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTimecards.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTimecards.Dock = DockStyle.Fill;
            dgvTimecards.Location = new Point(3, 187);
            dgvTimecards.MultiSelect = false;
            dgvTimecards.Name = "dgvTimecards";
            dgvTimecards.ReadOnly = true;
            dgvTimecards.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTimecards.Size = new Size(970, 423);
            dgvTimecards.TabIndex = 0;
            // 
            // flpTimecardButtons
            // 
            flpTimecardButtons.AutoSize = true;
            flpTimecardButtons.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flpTimecardButtons.Controls.Add(btnAddTimecard);
            flpTimecardButtons.Controls.Add(btnUpdateTimecard);
            flpTimecardButtons.Controls.Add(btnDeleteTimecard);
            flpTimecardButtons.Controls.Add(btnClearTimecard);
            flpTimecardButtons.Controls.Add(btnRefreshTimecard);
            flpTimecardButtons.Controls.Add(button1);
            flpTimecardButtons.Dock = DockStyle.Top;
            flpTimecardButtons.Location = new Point(3, 137);
            flpTimecardButtons.Name = "flpTimecardButtons";
            flpTimecardButtons.Padding = new Padding(10, 6, 10, 6);
            flpTimecardButtons.Size = new Size(970, 50);
            flpTimecardButtons.TabIndex = 1;
            // 
            // btnAddTimecard
            // 
            btnAddTimecard.Location = new Point(13, 9);
            btnAddTimecard.Name = "btnAddTimecard";
            btnAddTimecard.Size = new Size(125, 32);
            btnAddTimecard.TabIndex = 0;
            btnAddTimecard.Text = "Add Timecard";
            btnAddTimecard.UseVisualStyleBackColor = true;
            // 
            // btnUpdateTimecard
            // 
            btnUpdateTimecard.Location = new Point(144, 9);
            btnUpdateTimecard.Name = "btnUpdateTimecard";
            btnUpdateTimecard.Size = new Size(125, 32);
            btnUpdateTimecard.TabIndex = 1;
            btnUpdateTimecard.Text = "Update Timecard";
            btnUpdateTimecard.UseVisualStyleBackColor = true;
            // 
            // btnDeleteTimecard
            // 
            btnDeleteTimecard.Location = new Point(275, 9);
            btnDeleteTimecard.Name = "btnDeleteTimecard";
            btnDeleteTimecard.Size = new Size(125, 32);
            btnDeleteTimecard.TabIndex = 2;
            btnDeleteTimecard.Text = "Delete Timecard";
            btnDeleteTimecard.UseVisualStyleBackColor = true;
            // 
            // btnClearTimecard
            // 
            btnClearTimecard.Location = new Point(406, 9);
            btnClearTimecard.Name = "btnClearTimecard";
            btnClearTimecard.Size = new Size(125, 32);
            btnClearTimecard.TabIndex = 3;
            btnClearTimecard.Text = "Clear";
            btnClearTimecard.UseVisualStyleBackColor = true;
            // 
            // btnRefreshTimecard
            // 
            btnRefreshTimecard.Location = new Point(537, 9);
            btnRefreshTimecard.Name = "btnRefreshTimecard";
            btnRefreshTimecard.Size = new Size(125, 32);
            btnRefreshTimecard.TabIndex = 4;
            btnRefreshTimecard.Text = "Refresh";
            btnRefreshTimecard.UseVisualStyleBackColor = true;
            // 
            // flpTimecardInputs
            // 
            flpTimecardInputs.AutoSize = true;
            flpTimecardInputs.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flpTimecardInputs.Controls.Add(pnlJobSelect);
            flpTimecardInputs.Controls.Add(pnlEmployee);
            flpTimecardInputs.Controls.Add(pnlDateWorked);
            flpTimecardInputs.Controls.Add(pnlHoursWorked);
            flpTimecardInputs.Controls.Add(pnlTimecardSearch);
            flpTimecardInputs.Dock = DockStyle.Top;
            flpTimecardInputs.Location = new Point(3, 3);
            flpTimecardInputs.Name = "flpTimecardInputs";
            flpTimecardInputs.Padding = new Padding(10, 10, 10, 4);
            flpTimecardInputs.Size = new Size(970, 134);
            flpTimecardInputs.TabIndex = 2;
            // 
            // pnlJobSelect
            // 
            pnlJobSelect.Controls.Add(cmbJobSelect);
            pnlJobSelect.Controls.Add(lblJobSelect);
            pnlJobSelect.Location = new Point(13, 13);
            pnlJobSelect.Name = "pnlJobSelect";
            pnlJobSelect.Size = new Size(280, 52);
            pnlJobSelect.TabIndex = 0;
            // 
            // cmbJobSelect
            // 
            cmbJobSelect.FormattingEnabled = true;
            cmbJobSelect.Location = new Point(0, 20);
            cmbJobSelect.Name = "cmbJobSelect";
            cmbJobSelect.Size = new Size(275, 23);
            cmbJobSelect.TabIndex = 1;
            // 
            // lblJobSelect
            // 
            lblJobSelect.AutoSize = true;
            lblJobSelect.Location = new Point(0, 0);
            lblJobSelect.Name = "lblJobSelect";
            lblJobSelect.Size = new Size(28, 15);
            lblJobSelect.TabIndex = 0;
            lblJobSelect.Text = "Job:";
            // 
            // pnlEmployee
            // 
            pnlEmployee.Controls.Add(txtEmployee);
            pnlEmployee.Controls.Add(lblEmployee);
            pnlEmployee.Location = new Point(300, 14);
            pnlEmployee.Margin = new Padding(4, 4, 12, 4);
            pnlEmployee.Name = "pnlEmployee";
            pnlEmployee.Size = new Size(220, 52);
            pnlEmployee.TabIndex = 1;
            // 
            // txtEmployee
            // 
            txtEmployee.Location = new Point(0, 20);
            txtEmployee.Name = "txtEmployee";
            txtEmployee.Size = new Size(215, 23);
            txtEmployee.TabIndex = 1;
            // 
            // lblEmployee
            // 
            lblEmployee.AutoSize = true;
            lblEmployee.Location = new Point(0, 0);
            lblEmployee.Name = "lblEmployee";
            lblEmployee.Size = new Size(62, 15);
            lblEmployee.TabIndex = 0;
            lblEmployee.Text = "Employee:";
            // 
            // pnlDateWorked
            // 
            pnlDateWorked.Controls.Add(dtpDateWorked);
            pnlDateWorked.Controls.Add(lblDateWorked);
            pnlDateWorked.Location = new Point(536, 14);
            pnlDateWorked.Margin = new Padding(4, 4, 12, 4);
            pnlDateWorked.Name = "pnlDateWorked";
            pnlDateWorked.Size = new Size(220, 52);
            pnlDateWorked.TabIndex = 2;
            // 
            // dtpDateWorked
            // 
            dtpDateWorked.Format = DateTimePickerFormat.Short;
            dtpDateWorked.Location = new Point(0, 20);
            dtpDateWorked.Name = "dtpDateWorked";
            dtpDateWorked.Size = new Size(215, 23);
            dtpDateWorked.TabIndex = 1;
            // 
            // lblDateWorked
            // 
            lblDateWorked.AutoSize = true;
            lblDateWorked.Location = new Point(0, 0);
            lblDateWorked.Name = "lblDateWorked";
            lblDateWorked.Size = new Size(78, 15);
            lblDateWorked.TabIndex = 0;
            lblDateWorked.Text = "Date Worked:";
            // 
            // pnlHoursWorked
            // 
            pnlHoursWorked.Controls.Add(numHoursWorked);
            pnlHoursWorked.Controls.Add(lblHoursWorked);
            pnlHoursWorked.Location = new Point(14, 74);
            pnlHoursWorked.Margin = new Padding(4, 4, 12, 4);
            pnlHoursWorked.Name = "pnlHoursWorked";
            pnlHoursWorked.Size = new Size(220, 52);
            pnlHoursWorked.TabIndex = 3;
            // 
            // numHoursWorked
            // 
            numHoursWorked.DecimalPlaces = 2;
            numHoursWorked.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
            numHoursWorked.Location = new Point(0, 20);
            numHoursWorked.Maximum = new decimal(new int[] { 24, 0, 0, 0 });
            numHoursWorked.Minimum = new decimal(new int[] { 25, 0, 0, 131072 });
            numHoursWorked.Name = "numHoursWorked";
            numHoursWorked.Size = new Size(215, 23);
            numHoursWorked.TabIndex = 1;
            numHoursWorked.Value = new decimal(new int[] { 8, 0, 0, 0 });
            // 
            // lblHoursWorked
            // 
            lblHoursWorked.AutoSize = true;
            lblHoursWorked.Location = new Point(0, 0);
            lblHoursWorked.Name = "lblHoursWorked";
            lblHoursWorked.Size = new Size(86, 15);
            lblHoursWorked.TabIndex = 0;
            lblHoursWorked.Text = "Hours Worked:";
            // 
            // pnlTimecardSearch
            // 
            pnlTimecardSearch.Controls.Add(btnSearchTimecard);
            pnlTimecardSearch.Controls.Add(txtSearchTimecard);
            pnlTimecardSearch.Controls.Add(lblSearchTimecard);
            pnlTimecardSearch.Location = new Point(249, 73);
            pnlTimecardSearch.Margin = new Padding(3, 3, 12, 6);
            pnlTimecardSearch.Name = "pnlTimecardSearch";
            pnlTimecardSearch.Size = new Size(270, 50);
            pnlTimecardSearch.TabIndex = 7;
            // 
            // btnSearchTimecard
            // 
            btnSearchTimecard.Location = new Point(186, 21);
            btnSearchTimecard.Name = "btnSearchTimecard";
            btnSearchTimecard.Size = new Size(75, 25);
            btnSearchTimecard.TabIndex = 2;
            btnSearchTimecard.Text = "Search";
            btnSearchTimecard.UseVisualStyleBackColor = true;
            // 
            // txtSearchTimecard
            // 
            txtSearchTimecard.Location = new Point(0, 22);
            txtSearchTimecard.Name = "txtSearchTimecard";
            txtSearchTimecard.PlaceholderText = "Type to search...";
            txtSearchTimecard.Size = new Size(180, 23);
            txtSearchTimecard.TabIndex = 1;
            // 
            // lblSearchTimecard
            // 
            lblSearchTimecard.AutoSize = true;
            lblSearchTimecard.Location = new Point(0, 0);
            lblSearchTimecard.Name = "lblSearchTimecard";
            lblSearchTimecard.Size = new Size(103, 15);
            lblSearchTimecard.TabIndex = 0;
            lblSearchTimecard.Text = "Search Timecards:";
            // 
            // tabClients
            // 
            tabClients.Controls.Add(dgvClients);
            tabClients.Controls.Add(flpClientButtons);
            tabClients.Controls.Add(flpClientsInputs);
            tabClients.Location = new Point(4, 24);
            tabClients.Name = "tabClients";
            tabClients.Size = new Size(976, 613);
            tabClients.TabIndex = 2;
            tabClients.Text = "Clients";
            tabClients.UseVisualStyleBackColor = true;
            // 
            // dgvClients
            // 
            dgvClients.AllowUserToAddRows = false;
            dgvClients.AllowUserToDeleteRows = false;
            dgvClients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClients.Dock = DockStyle.Fill;
            dgvClients.Location = new Point(0, 122);
            dgvClients.Name = "dgvClients";
            dgvClients.ReadOnly = true;
            dgvClients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClients.Size = new Size(976, 491);
            dgvClients.TabIndex = 0;
            dgvClients.CellClick += dgvClients_CellClick;
            // 
            // flpClientButtons
            // 
            flpClientButtons.AutoSize = true;
            flpClientButtons.Controls.Add(btnAddClient);
            flpClientButtons.Controls.Add(btnUpdateClient);
            flpClientButtons.Controls.Add(btnDeleteClient);
            flpClientButtons.Controls.Add(btnClearClient);
            flpClientButtons.Controls.Add(button2);
            flpClientButtons.Dock = DockStyle.Top;
            flpClientButtons.Location = new Point(0, 74);
            flpClientButtons.Name = "flpClientButtons";
            flpClientButtons.Padding = new Padding(10, 0, 10, 10);
            flpClientButtons.Size = new Size(976, 48);
            flpClientButtons.TabIndex = 1;
            // 
            // btnAddClient
            // 
            btnAddClient.Location = new Point(13, 3);
            btnAddClient.Margin = new Padding(3, 3, 8, 3);
            btnAddClient.Name = "btnAddClient";
            btnAddClient.Size = new Size(100, 30);
            btnAddClient.TabIndex = 0;
            btnAddClient.Text = "Add Client";
            btnAddClient.UseVisualStyleBackColor = true;
            btnAddClient.Click += btnAddClient_Click;
            // 
            // btnUpdateClient
            // 
            btnUpdateClient.Location = new Point(124, 3);
            btnUpdateClient.Margin = new Padding(3, 3, 8, 3);
            btnUpdateClient.Name = "btnUpdateClient";
            btnUpdateClient.Size = new Size(100, 30);
            btnUpdateClient.TabIndex = 1;
            btnUpdateClient.Text = "Update Client";
            btnUpdateClient.UseVisualStyleBackColor = true;
            btnUpdateClient.Click += btnUpdateClient_Click;
            // 
            // btnDeleteClient
            // 
            btnDeleteClient.Location = new Point(235, 3);
            btnDeleteClient.Margin = new Padding(3, 3, 8, 3);
            btnDeleteClient.Name = "btnDeleteClient";
            btnDeleteClient.Size = new Size(100, 30);
            btnDeleteClient.TabIndex = 2;
            btnDeleteClient.Text = "Delete Client";
            btnDeleteClient.UseVisualStyleBackColor = true;
            btnDeleteClient.Click += btnDeleteClient_Click;
            // 
            // btnClearClient
            // 
            btnClearClient.Location = new Point(346, 3);
            btnClearClient.Margin = new Padding(3, 3, 8, 3);
            btnClearClient.Name = "btnClearClient";
            btnClearClient.Size = new Size(100, 30);
            btnClearClient.TabIndex = 3;
            btnClearClient.Text = "Clear";
            btnClearClient.UseVisualStyleBackColor = true;
            btnClearClient.Click += btnClearClient_Click;
            // 
            // flpClientsInputs
            // 
            flpClientsInputs.AutoSize = true;
            flpClientsInputs.Controls.Add(pnlClientCompany);
            flpClientsInputs.Controls.Add(pnlClientContact);
            flpClientsInputs.Controls.Add(pnlClientPhone);
            flpClientsInputs.Controls.Add(pnlClientSearch);
            flpClientsInputs.Dock = DockStyle.Top;
            flpClientsInputs.Location = new Point(0, 0);
            flpClientsInputs.Name = "flpClientsInputs";
            flpClientsInputs.Padding = new Padding(10, 10, 10, 5);
            flpClientsInputs.Size = new Size(976, 74);
            flpClientsInputs.TabIndex = 2;
            // 
            // pnlClientCompany
            // 
            pnlClientCompany.AutoSize = true;
            pnlClientCompany.Controls.Add(txtClientCompany);
            pnlClientCompany.Controls.Add(lblClientCompany);
            pnlClientCompany.Location = new Point(13, 13);
            pnlClientCompany.Margin = new Padding(3, 3, 12, 6);
            pnlClientCompany.Name = "pnlClientCompany";
            pnlClientCompany.Size = new Size(188, 48);
            pnlClientCompany.TabIndex = 0;
            // 
            // txtClientCompany
            // 
            txtClientCompany.Location = new Point(0, 22);
            txtClientCompany.Name = "txtClientCompany";
            txtClientCompany.Size = new Size(185, 23);
            txtClientCompany.TabIndex = 1;
            // 
            // lblClientCompany
            // 
            lblClientCompany.AutoSize = true;
            lblClientCompany.Location = new Point(0, 3);
            lblClientCompany.Name = "lblClientCompany";
            lblClientCompany.Size = new Size(97, 15);
            lblClientCompany.TabIndex = 0;
            lblClientCompany.Text = "Company Name:";
            // 
            // pnlClientContact
            // 
            pnlClientContact.Controls.Add(txtClientContact);
            pnlClientContact.Controls.Add(lblClientContact);
            pnlClientContact.Location = new Point(216, 13);
            pnlClientContact.Margin = new Padding(3, 3, 12, 6);
            pnlClientContact.Name = "pnlClientContact";
            pnlClientContact.Size = new Size(170, 50);
            pnlClientContact.TabIndex = 1;
            // 
            // txtClientContact
            // 
            txtClientContact.Location = new Point(0, 22);
            txtClientContact.Name = "txtClientContact";
            txtClientContact.Size = new Size(165, 23);
            txtClientContact.TabIndex = 1;
            // 
            // lblClientContact
            // 
            lblClientContact.AutoSize = true;
            lblClientContact.Location = new Point(0, 3);
            lblClientContact.Name = "lblClientContact";
            lblClientContact.Size = new Size(87, 15);
            lblClientContact.TabIndex = 0;
            lblClientContact.Text = "Contact Name:";
            // 
            // pnlClientPhone
            // 
            pnlClientPhone.Controls.Add(txtClientPhone);
            pnlClientPhone.Controls.Add(lblClientPhone);
            pnlClientPhone.Location = new Point(401, 13);
            pnlClientPhone.Margin = new Padding(3, 3, 12, 6);
            pnlClientPhone.Name = "pnlClientPhone";
            pnlClientPhone.Size = new Size(150, 50);
            pnlClientPhone.TabIndex = 2;
            // 
            // txtClientPhone
            // 
            txtClientPhone.Location = new Point(0, 22);
            txtClientPhone.Name = "txtClientPhone";
            txtClientPhone.Size = new Size(145, 23);
            txtClientPhone.TabIndex = 1;
            // 
            // lblClientPhone
            // 
            lblClientPhone.AutoSize = true;
            lblClientPhone.Location = new Point(0, 3);
            lblClientPhone.Name = "lblClientPhone";
            lblClientPhone.Size = new Size(65, 15);
            lblClientPhone.TabIndex = 0;
            lblClientPhone.Text = "Telephone:";
            // 
            // pnlClientSearch
            // 
            pnlClientSearch.Controls.Add(btnSearchClient);
            pnlClientSearch.Controls.Add(txtSearchClient);
            pnlClientSearch.Controls.Add(lblSearchClient);
            pnlClientSearch.Location = new Point(566, 13);
            pnlClientSearch.Margin = new Padding(3, 3, 12, 6);
            pnlClientSearch.Name = "pnlClientSearch";
            pnlClientSearch.Size = new Size(270, 50);
            pnlClientSearch.TabIndex = 4;
            // 
            // btnSearchClient
            // 
            btnSearchClient.Location = new Point(186, 21);
            btnSearchClient.Name = "btnSearchClient";
            btnSearchClient.Size = new Size(75, 25);
            btnSearchClient.TabIndex = 2;
            btnSearchClient.Text = "Search";
            btnSearchClient.UseVisualStyleBackColor = true;
            btnSearchClient.Click += btnSearchClient_Click;
            // 
            // txtSearchClient
            // 
            txtSearchClient.Location = new Point(0, 22);
            txtSearchClient.Name = "txtSearchClient";
            txtSearchClient.PlaceholderText = "Type to search...";
            txtSearchClient.Size = new Size(180, 23);
            txtSearchClient.TabIndex = 1;
            txtSearchClient.TextChanged += txtSearchClient_TextChanged;
            // 
            // lblSearchClient
            // 
            lblSearchClient.AutoSize = true;
            lblSearchClient.Location = new Point(0, 3);
            lblSearchClient.Name = "lblSearchClient";
            lblSearchClient.Size = new Size(84, 15);
            lblSearchClient.TabIndex = 0;
            lblSearchClient.Text = "Search Clients:";
            // 
            // tabEmployees
            // 
            tabEmployees.Controls.Add(dgvEmployees);
            tabEmployees.Controls.Add(flpEmployeeButtons);
            tabEmployees.Controls.Add(flpEmployeeInputs);
            tabEmployees.Location = new Point(4, 24);
            tabEmployees.Name = "tabEmployees";
            tabEmployees.Size = new Size(976, 613);
            tabEmployees.TabIndex = 3;
            tabEmployees.Text = "Employees";
            tabEmployees.UseVisualStyleBackColor = true;
            // 
            // dgvEmployees
            // 
            dgvEmployees.AllowUserToAddRows = false;
            dgvEmployees.AllowUserToDeleteRows = false;
            dgvEmployees.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEmployees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEmployees.Dock = DockStyle.Fill;
            dgvEmployees.Location = new Point(0, 180);
            dgvEmployees.Name = "dgvEmployees";
            dgvEmployees.ReadOnly = true;
            dgvEmployees.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEmployees.Size = new Size(976, 433);
            dgvEmployees.TabIndex = 0;
            dgvEmployees.CellClick += dgvEmployees_CellClick;
            // 
            // flpEmployeeInputs
            // 
            flpEmployeeInputs.AutoSize = true;
            flpEmployeeInputs.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flpEmployeeInputs.Controls.Add(pnlEmpCode);
            flpEmployeeInputs.Controls.Add(pnlEmpFirstName);
            flpEmployeeInputs.Controls.Add(pnlEmpLastName);
            flpEmployeeInputs.Controls.Add(pnlEmpRole);
            flpEmployeeInputs.Controls.Add(pnlEmpEmail);
            flpEmployeeInputs.Controls.Add(pnlEmpSearch);
            flpEmployeeInputs.Dock = DockStyle.Top;
            flpEmployeeInputs.Location = new Point(0, 0);
            flpEmployeeInputs.Name = "flpEmployeeInputs";
            flpEmployeeInputs.Padding = new Padding(10, 10, 10, 5);
            flpEmployeeInputs.Size = new Size(976, 127);
            flpEmployeeInputs.TabIndex = 2;
            // 
            // pnlEmpCode
            // 
            pnlEmpCode.Controls.Add(txtEmpCode);
            pnlEmpCode.Controls.Add(lblEmpCode);
            pnlEmpCode.Location = new Point(13, 13);
            pnlEmpCode.Name = "pnlEmpCode";
            pnlEmpCode.Size = new Size(130, 50);
            pnlEmpCode.TabIndex = 0;
            // 
            // txtEmpCode
            // 
            txtEmpCode.Location = new Point(0, 22);
            txtEmpCode.Name = "txtEmpCode";
            txtEmpCode.Size = new Size(125, 23);
            txtEmpCode.TabIndex = 1;
            // 
            // lblEmpCode
            // 
            lblEmpCode.AutoSize = true;
            lblEmpCode.Location = new Point(0, 0);
            lblEmpCode.Margin = new Padding(3, 3, 12, 6);
            lblEmpCode.Name = "lblEmpCode";
            lblEmpCode.Size = new Size(93, 15);
            lblEmpCode.TabIndex = 0;
            lblEmpCode.Text = "Employee Code:";
            // 
            // pnlEmpFirstName
            // 
            pnlEmpFirstName.Controls.Add(txtEmpFirstName);
            pnlEmpFirstName.Controls.Add(lblEmpFirstName);
            pnlEmpFirstName.Location = new Point(149, 13);
            pnlEmpFirstName.Name = "pnlEmpFirstName";
            pnlEmpFirstName.Size = new Size(155, 50);
            pnlEmpFirstName.TabIndex = 1;
            // 
            // txtEmpFirstName
            // 
            txtEmpFirstName.Location = new Point(0, 22);
            txtEmpFirstName.Name = "txtEmpFirstName";
            txtEmpFirstName.Size = new Size(150, 23);
            txtEmpFirstName.TabIndex = 1;
            // 
            // lblEmpFirstName
            // 
            lblEmpFirstName.AutoSize = true;
            lblEmpFirstName.Location = new Point(0, 0);
            lblEmpFirstName.Margin = new Padding(3, 3, 12, 6);
            lblEmpFirstName.Name = "lblEmpFirstName";
            lblEmpFirstName.Size = new Size(67, 15);
            lblEmpFirstName.TabIndex = 0;
            lblEmpFirstName.Text = "First Name:";
            // 
            // pnlEmpLastName
            // 
            pnlEmpLastName.Controls.Add(txtEmpLastName);
            pnlEmpLastName.Controls.Add(lblEmpLastName);
            pnlEmpLastName.Location = new Point(310, 13);
            pnlEmpLastName.Name = "pnlEmpLastName";
            pnlEmpLastName.Size = new Size(155, 50);
            pnlEmpLastName.TabIndex = 2;
            // 
            // txtEmpLastName
            // 
            txtEmpLastName.Location = new Point(0, 22);
            txtEmpLastName.Name = "txtEmpLastName";
            txtEmpLastName.Size = new Size(150, 23);
            txtEmpLastName.TabIndex = 1;
            // 
            // lblEmpLastName
            // 
            lblEmpLastName.AutoSize = true;
            lblEmpLastName.Location = new Point(0, 0);
            lblEmpLastName.Margin = new Padding(3, 3, 12, 6);
            lblEmpLastName.Name = "lblEmpLastName";
            lblEmpLastName.Size = new Size(66, 15);
            lblEmpLastName.TabIndex = 0;
            lblEmpLastName.Text = "Last Name:";
            // 
            // pnlEmpRole
            // 
            pnlEmpRole.Controls.Add(txtEmpRole);
            pnlEmpRole.Controls.Add(lblEmpRole);
            pnlEmpRole.Location = new Point(471, 13);
            pnlEmpRole.Name = "pnlEmpRole";
            pnlEmpRole.Size = new Size(155, 50);
            pnlEmpRole.TabIndex = 3;
            // 
            // txtEmpRole
            // 
            txtEmpRole.Location = new Point(0, 22);
            txtEmpRole.Name = "txtEmpRole";
            txtEmpRole.Size = new Size(150, 23);
            txtEmpRole.TabIndex = 1;
            // 
            // lblEmpRole
            // 
            lblEmpRole.AutoSize = true;
            lblEmpRole.Location = new Point(0, 0);
            lblEmpRole.Margin = new Padding(3, 3, 12, 6);
            lblEmpRole.Name = "lblEmpRole";
            lblEmpRole.Size = new Size(33, 15);
            lblEmpRole.TabIndex = 0;
            lblEmpRole.Text = "Role:";
            // 
            // pnlEmpEmail
            // 
            pnlEmpEmail.Controls.Add(txtEmpEmail);
            pnlEmpEmail.Controls.Add(lblEmpEmail);
            pnlEmpEmail.Location = new Point(632, 13);
            pnlEmpEmail.Name = "pnlEmpEmail";
            pnlEmpEmail.Size = new Size(185, 50);
            pnlEmpEmail.TabIndex = 4;
            // 
            // txtEmpEmail
            // 
            txtEmpEmail.Location = new Point(0, 22);
            txtEmpEmail.Name = "txtEmpEmail";
            txtEmpEmail.Size = new Size(180, 23);
            txtEmpEmail.TabIndex = 1;
            // 
            // lblEmpEmail
            // 
            lblEmpEmail.AutoSize = true;
            lblEmpEmail.Location = new Point(0, 0);
            lblEmpEmail.Margin = new Padding(3, 3, 12, 6);
            lblEmpEmail.Name = "lblEmpEmail";
            lblEmpEmail.Size = new Size(39, 15);
            lblEmpEmail.TabIndex = 0;
            lblEmpEmail.Text = "Email:";
            // 
            // pnlEmpSearch
            // 
            pnlEmpSearch.Controls.Add(btnSearchEmployee);
            pnlEmpSearch.Controls.Add(txtSearchEmployee);
            pnlEmpSearch.Controls.Add(lblSearchEmployee);
            pnlEmpSearch.Location = new Point(13, 69);
            pnlEmpSearch.Name = "pnlEmpSearch";
            pnlEmpSearch.Size = new Size(270, 50);
            pnlEmpSearch.TabIndex = 5;
            // 
            // btnSearchEmployee
            // 
            btnSearchEmployee.Location = new Point(186, 21);
            btnSearchEmployee.Name = "btnSearchEmployee";
            btnSearchEmployee.Size = new Size(75, 25);
            btnSearchEmployee.TabIndex = 2;
            btnSearchEmployee.Text = "Search";
            btnSearchEmployee.UseVisualStyleBackColor = true;
            // 
            // txtSearchEmployee
            // 
            txtSearchEmployee.Location = new Point(0, 22);
            txtSearchEmployee.Name = "txtSearchEmployee";
            txtSearchEmployee.PlaceholderText = "Type to search...";
            txtSearchEmployee.Size = new Size(180, 23);
            txtSearchEmployee.TabIndex = 1;
            txtSearchEmployee.TextChanged += txtSearchEmployee_TextChanged;
            // 
            // lblSearchEmployee
            // 
            lblSearchEmployee.AutoSize = true;
            lblSearchEmployee.Location = new Point(0, 0);
            lblSearchEmployee.Margin = new Padding(3, 3, 12, 6);
            lblSearchEmployee.Name = "lblSearchEmployee";
            lblSearchEmployee.Size = new Size(105, 15);
            lblSearchEmployee.TabIndex = 0;
            lblSearchEmployee.Text = "Search Employees:";
            // 
            // flpEmployeeButtons
            // 
            flpEmployeeButtons.AutoSize = true;
            flpEmployeeButtons.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flpEmployeeButtons.Controls.Add(btnAddEmployee);
            flpEmployeeButtons.Controls.Add(btnUpdateEmployee);
            flpEmployeeButtons.Controls.Add(btnDeleteEmployee);
            flpEmployeeButtons.Controls.Add(btnClearEmployee);
            flpEmployeeButtons.Controls.Add(button3);
            flpEmployeeButtons.Dock = DockStyle.Top;
            flpEmployeeButtons.Location = new Point(0, 127);
            flpEmployeeButtons.Name = "flpEmployeeButtons";
            flpEmployeeButtons.Padding = new Padding(10, 10, 10, 5);
            flpEmployeeButtons.Size = new Size(976, 53);
            flpEmployeeButtons.TabIndex = 1;
            // 
            // btnAddEmployee
            // 
            btnAddEmployee.Location = new Point(13, 13);
            btnAddEmployee.Margin = new Padding(3, 3, 8, 3);
            btnAddEmployee.Name = "btnAddEmployee";
            btnAddEmployee.Size = new Size(115, 30);
            btnAddEmployee.TabIndex = 0;
            btnAddEmployee.Text = "Add Employee";
            btnAddEmployee.UseVisualStyleBackColor = true;
            btnAddEmployee.Click += btnAddEmployee_Click;
            // 
            // btnUpdateEmployee
            // 
            btnUpdateEmployee.Location = new Point(139, 13);
            btnUpdateEmployee.Margin = new Padding(3, 3, 8, 3);
            btnUpdateEmployee.Name = "btnUpdateEmployee";
            btnUpdateEmployee.Size = new Size(115, 30);
            btnUpdateEmployee.TabIndex = 1;
            btnUpdateEmployee.Text = "Update Employee";
            btnUpdateEmployee.UseVisualStyleBackColor = true;
            btnUpdateEmployee.Click += btnUpdateEmployee_Click;
            // 
            // btnDeleteEmployee
            // 
            btnDeleteEmployee.Location = new Point(265, 13);
            btnDeleteEmployee.Margin = new Padding(3, 3, 8, 3);
            btnDeleteEmployee.Name = "btnDeleteEmployee";
            btnDeleteEmployee.Size = new Size(115, 30);
            btnDeleteEmployee.TabIndex = 2;
            btnDeleteEmployee.Text = "Delete Employee";
            btnDeleteEmployee.UseVisualStyleBackColor = true;
            btnDeleteEmployee.Click += btnDeleteEmployee_Click;
            // 
            // btnClearEmployee
            // 
            btnClearEmployee.Location = new Point(391, 13);
            btnClearEmployee.Margin = new Padding(3, 3, 8, 3);
            btnClearEmployee.Name = "btnClearEmployee";
            btnClearEmployee.Size = new Size(115, 30);
            btnClearEmployee.TabIndex = 3;
            btnClearEmployee.Text = "Clear";
            btnClearEmployee.UseVisualStyleBackColor = true;
            btnClearEmployee.Click += btnClearEmployee_Click;
            // 
            // btnOpenWeb
            // 
            btnOpenWeb.Location = new Point(618, 9);
            btnOpenWeb.Name = "btnOpenWeb";
            btnOpenWeb.Size = new Size(125, 32);
            btnOpenWeb.TabIndex = 5;
            btnOpenWeb.Text = "Web Dashboard";
            btnOpenWeb.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(668, 9);
            button1.Name = "button1";
            button1.Size = new Size(125, 32);
            button1.TabIndex = 6;
            button1.Text = "Web Dashboard";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(457, 3);
            button2.Name = "button2";
            button2.Size = new Size(125, 32);
            button2.TabIndex = 6;
            button2.Text = "Web Dashboard";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(517, 13);
            button3.Name = "button3";
            button3.Size = new Size(125, 32);
            button3.TabIndex = 6;
            button3.Text = "Web Dashboard";
            button3.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoScroll = true;
            ClientSize = new Size(984, 641);
            Controls.Add(tabControlMain);
            MinimumSize = new Size(420, 500);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Job Timecard System";
            tabControlMain.ResumeLayout(false);
            tabJobs.ResumeLayout(false);
            tabJobs.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvJobs).EndInit();
            flpJobButtons.ResumeLayout(false);
            flpJobInputs.ResumeLayout(false);
            pnlJobNum.ResumeLayout(false);
            pnlJobNum.PerformLayout();
            pnlJobType.ResumeLayout(false);
            pnlJobType.PerformLayout();
            pnlJobDate.ResumeLayout(false);
            pnlJobDate.PerformLayout();
            pnlCompanyName.ResumeLayout(false);
            pnlCompanyName.PerformLayout();
            pnlContactName.ResumeLayout(false);
            pnlContactName.PerformLayout();
            pnlTelephone.ResumeLayout(false);
            pnlTelephone.PerformLayout();
            pnlJobSearch.ResumeLayout(false);
            pnlJobSearch.PerformLayout();
            tabTimecards.ResumeLayout(false);
            tabTimecards.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTimecards).EndInit();
            flpTimecardButtons.ResumeLayout(false);
            flpTimecardInputs.ResumeLayout(false);
            pnlJobSelect.ResumeLayout(false);
            pnlJobSelect.PerformLayout();
            pnlEmployee.ResumeLayout(false);
            pnlEmployee.PerformLayout();
            pnlDateWorked.ResumeLayout(false);
            pnlDateWorked.PerformLayout();
            pnlHoursWorked.ResumeLayout(false);
            pnlHoursWorked.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numHoursWorked).EndInit();
            pnlTimecardSearch.ResumeLayout(false);
            pnlTimecardSearch.PerformLayout();
            tabClients.ResumeLayout(false);
            tabClients.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvClients).EndInit();
            flpClientButtons.ResumeLayout(false);
            flpClientsInputs.ResumeLayout(false);
            flpClientsInputs.PerformLayout();
            pnlClientCompany.ResumeLayout(false);
            pnlClientCompany.PerformLayout();
            pnlClientContact.ResumeLayout(false);
            pnlClientContact.PerformLayout();
            pnlClientPhone.ResumeLayout(false);
            pnlClientPhone.PerformLayout();
            pnlClientSearch.ResumeLayout(false);
            pnlClientSearch.PerformLayout();
            tabEmployees.ResumeLayout(false);
            tabEmployees.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).EndInit();
            flpEmployeeInputs.ResumeLayout(false);
            pnlEmpCode.ResumeLayout(false);
            pnlEmpCode.PerformLayout();
            pnlEmpFirstName.ResumeLayout(false);
            pnlEmpFirstName.PerformLayout();
            pnlEmpLastName.ResumeLayout(false);
            pnlEmpLastName.PerformLayout();
            pnlEmpRole.ResumeLayout(false);
            pnlEmpRole.PerformLayout();
            pnlEmpEmail.ResumeLayout(false);
            pnlEmpEmail.PerformLayout();
            pnlEmpSearch.ResumeLayout(false);
            pnlEmpSearch.PerformLayout();
            flpEmployeeButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControlMain;
        private TabPage tabJobs;
        private TabPage tabTimecards;
        private DataGridView dgvJobs;
        private FlowLayoutPanel flpJobButtons;
        private Button btnAddJob;
        private Button btnUpdateJob;
        private Button btnDeleteJob;
        private Button btnClearJob;
        private Button btnRefreshJob;
        private FlowLayoutPanel flpJobInputs;
        private Panel pnlJobNum;
        private TextBox txtJobNumber;
        private Label lblJobNum;
        private Panel pnlJobType;
        private ComboBox cmbJobType;
        private Label lblJobType;
        private Panel pnlJobDate;
        private DateTimePicker dtpJobDate;
        private Label lblJobDate;
        private Panel pnlCompanyName;
        private TextBox txtCompanyName;
        private Label lblCompanyName;
        private Panel pnlContactName;
        private Label lblContactName;
        private TextBox txtContactName;
        private Panel pnlTelephone;
        private TextBox txtTelephone;
        private Label lblTelephone;
        private DataGridView dgvTimecards;
        private FlowLayoutPanel flpTimecardButtons;
        private Button btnAddTimecard;
        private Button btnUpdateTimecard;
        private Button btnDeleteTimecard;
        private Button btnClearTimecard;
        private Button btnRefreshTimecard;
        private FlowLayoutPanel flpTimecardInputs;
        private Panel pnlJobSelect;
        private Label lblJobSelect;
        private ComboBox cmbJobSelect;
        private Panel pnlEmployee;
        private TextBox txtEmployee;
        private Label lblEmployee;
        private Panel pnlDateWorked;
        private DateTimePicker dtpDateWorked;
        private Label lblDateWorked;
        private Panel pnlHoursWorked;
        private Label lblHoursWorked;
        private NumericUpDown numHoursWorked;
        private TabPage tabClients;
        private DataGridView dgvClients;
        private FlowLayoutPanel flpClientButtons;
        private Button btnAddClient;
        private Button btnUpdateClient;
        private Button btnDeleteClient;
        private FlowLayoutPanel flpClientsInputs;
        private Panel pnlClientCompany;
        private Button btnClearClient;
        private TextBox txtClientCompany;
        private Label lblClientCompany;
        private Panel pnlClientContact;
        private TextBox txtClientContact;
        private Label lblClientContact;
        private Panel pnlClientPhone;
        private TextBox txtClientPhone;
        private Label lblClientPhone;
        private Panel pnlClientSearch;
        private TextBox txtSearchClient;
        private Label lblSearchClient;
        private Button btnSearchClient;
        private TabPage tabEmployees;
        private DataGridView dgvEmployees;
        private FlowLayoutPanel flpEmployeeInputs;
        private FlowLayoutPanel flpEmployeeButtons;
        private Panel pnlEmpCode;
        private TextBox txtEmpCode;
        private Label lblEmpCode;
        private Panel pnlEmpFirstName;
        private TextBox txtEmpFirstName;
        private Label lblEmpFirstName;
        private Panel pnlEmpLastName;
        private TextBox txtEmpLastName;
        private Label lblEmpLastName;
        private Panel pnlEmpRole;
        private TextBox txtEmpRole;
        private Label lblEmpRole;
        private Panel pnlEmpEmail;
        private TextBox txtEmpEmail;
        private Label lblEmpEmail;
        private Panel pnlEmpSearch;
        private Button btnSearchEmployee;
        private TextBox txtSearchEmployee;
        private Label lblSearchEmployee;
        private Button btnAddEmployee;
        private Button btnUpdateEmployee;
        private Button btnDeleteEmployee;
        private Button btnClearEmployee;
        private Panel pnlJobSearch;
        private Button btnSearchJob;
        private TextBox txtSearchJob;
        private Label lblSearchJob;
        private Panel pnlTimecardSearch;
        private Button btnSearchTimecard;
        private TextBox txtSearchTimecard;
        private Label lblSearchTimecard;
        private Button btnOpenWeb;
        private Button button1;
        private Button button2;
        private Button button3;
    }
}
