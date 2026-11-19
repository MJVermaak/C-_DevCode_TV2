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
            dgvJobs = new DataGridView();
            tabTimecards = new TabPage();
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
            dgvTimecards = new DataGridView();
            tabControlMain.SuspendLayout();
            tabJobs.SuspendLayout();
            flpJobButtons.SuspendLayout();
            flpJobInputs.SuspendLayout();
            pnlJobNum.SuspendLayout();
            pnlJobType.SuspendLayout();
            pnlJobDate.SuspendLayout();
            pnlCompanyName.SuspendLayout();
            pnlContactName.SuspendLayout();
            pnlTelephone.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvJobs).BeginInit();
            tabTimecards.SuspendLayout();
            flpTimecardButtons.SuspendLayout();
            flpTimecardInputs.SuspendLayout();
            pnlJobSelect.SuspendLayout();
            pnlEmployee.SuspendLayout();
            pnlDateWorked.SuspendLayout();
            pnlHoursWorked.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numHoursWorked).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvTimecards).BeginInit();
            SuspendLayout();
            // 
            // tabControlMain
            // 
            tabControlMain.Controls.Add(tabJobs);
            tabControlMain.Controls.Add(tabTimecards);
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
            // flpJobButtons
            // 
            flpJobButtons.AutoSize = true;
            flpJobButtons.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flpJobButtons.Controls.Add(btnAddJob);
            flpJobButtons.Controls.Add(btnUpdateJob);
            flpJobButtons.Controls.Add(btnDeleteJob);
            flpJobButtons.Controls.Add(btnClearJob);
            flpJobButtons.Controls.Add(btnRefreshJob);
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
            // flpTimecardButtons
            // 
            flpTimecardButtons.AutoSize = true;
            flpTimecardButtons.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flpTimecardButtons.Controls.Add(btnAddTimecard);
            flpTimecardButtons.Controls.Add(btnUpdateTimecard);
            flpTimecardButtons.Controls.Add(btnDeleteTimecard);
            flpTimecardButtons.Controls.Add(btnClearTimecard);
            flpTimecardButtons.Controls.Add(btnRefreshTimecard);
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
            ((System.ComponentModel.ISupportInitialize)dgvJobs).EndInit();
            tabTimecards.ResumeLayout(false);
            tabTimecards.PerformLayout();
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
            ((System.ComponentModel.ISupportInitialize)dgvTimecards).EndInit();
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
    }
}
