
namespace PRJMediaBazaar
{
    partial class HRHome
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblDayOffReports = new System.Windows.Forms.Label();
            this.lblSickReports = new System.Windows.Forms.Label();
            this.lblSchedule = new System.Windows.Forms.Label();
            this.lblEmployees = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelEmployees = new System.Windows.Forms.Panel();
            this.btnDemote = new System.Windows.Forms.Button();
            this.btnShowInfo = new System.Windows.Forms.Button();
            this.lbGeneralInfo = new System.Windows.Forms.ListBox();
            this.btnPromote = new System.Windows.Forms.Button();
            this.lbEmployeeInfo = new System.Windows.Forms.ListBox();
            this.lblAllEmployees = new System.Windows.Forms.Label();
            this.cbAllEmployees = new System.Windows.Forms.ComboBox();
            this.cbWeek = new System.Windows.Forms.ComboBox();
            this.lblWeek = new System.Windows.Forms.Label();
            this.btnGenerateSchedule = new System.Windows.Forms.Button();
            this.btnPreferences = new System.Windows.Forms.Button();
            this.lblMorningShift = new System.Windows.Forms.Label();
            this.lblMiddayShift = new System.Windows.Forms.Label();
            this.lblEveningShift = new System.Windows.Forms.Label();
            this.cbPosition = new System.Windows.Forms.ComboBox();
            this.lblPosition = new System.Windows.Forms.Label();
            this.btnAssignForm = new System.Windows.Forms.Button();
            this.panelSchedule = new System.Windows.Forms.Panel();
            this.btnSaveChanges = new System.Windows.Forms.Button();
            this.lbSickReports = new System.Windows.Forms.ListBox();
            this.btnSickConfirm = new System.Windows.Forms.Button();
            this.btnSickDeny = new System.Windows.Forms.Button();
            this.panelSickReports = new System.Windows.Forms.Panel();
            this.pnlDayOff = new System.Windows.Forms.Panel();
            this.btnDenyDayOff = new System.Windows.Forms.Button();
            this.btnConfirmDayOff = new System.Windows.Forms.Button();
            this.lbDayOff = new System.Windows.Forms.ListBox();
            this.pnlNavbar = new System.Windows.Forms.Panel();
            this.panelEmployees.SuspendLayout();
            this.panelSchedule.SuspendLayout();
            this.panelSickReports.SuspendLayout();
            this.pnlDayOff.SuspendLayout();
            this.pnlNavbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDayOffReports
            // 
            this.lblDayOffReports.AutoSize = true;
            this.lblDayOffReports.BackColor = System.Drawing.Color.Black;
            this.lblDayOffReports.Font = new System.Drawing.Font("Microsoft YaHei", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblDayOffReports.ForeColor = System.Drawing.SystemColors.Control;
            this.lblDayOffReports.Location = new System.Drawing.Point(809, 17);
            this.lblDayOffReports.Name = "lblDayOffReports";
            this.lblDayOffReports.Size = new System.Drawing.Size(210, 31);
            this.lblDayOffReports.TabIndex = 4;
            this.lblDayOffReports.Text = "Day Off Reports";
            this.lblDayOffReports.Click += new System.EventHandler(this.label5_Click);
            // 
            // lblSickReports
            // 
            this.lblSickReports.AutoSize = true;
            this.lblSickReports.BackColor = System.Drawing.Color.Black;
            this.lblSickReports.Font = new System.Drawing.Font("Microsoft YaHei", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblSickReports.ForeColor = System.Drawing.SystemColors.Control;
            this.lblSickReports.Location = new System.Drawing.Point(631, 15);
            this.lblSickReports.Name = "lblSickReports";
            this.lblSickReports.Size = new System.Drawing.Size(163, 31);
            this.lblSickReports.TabIndex = 3;
            this.lblSickReports.Text = "Sick Reports";
            this.lblSickReports.Click += new System.EventHandler(this.label4_Click);
            // 
            // lblSchedule
            // 
            this.lblSchedule.AutoSize = true;
            this.lblSchedule.BackColor = System.Drawing.Color.Black;
            this.lblSchedule.Font = new System.Drawing.Font("Microsoft YaHei", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblSchedule.ForeColor = System.Drawing.SystemColors.Control;
            this.lblSchedule.Location = new System.Drawing.Point(229, 15);
            this.lblSchedule.Name = "lblSchedule";
            this.lblSchedule.Size = new System.Drawing.Size(123, 31);
            this.lblSchedule.TabIndex = 2;
            this.lblSchedule.Text = "Schedule";
            this.lblSchedule.Click += new System.EventHandler(this.label3_Click);
            // 
            // lblEmployees
            // 
            this.lblEmployees.AutoSize = true;
            this.lblEmployees.BackColor = System.Drawing.Color.Black;
            this.lblEmployees.Font = new System.Drawing.Font("Microsoft YaHei", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblEmployees.ForeColor = System.Drawing.SystemColors.Control;
            this.lblEmployees.Location = new System.Drawing.Point(37, 15);
            this.lblEmployees.Name = "lblEmployees";
            this.lblEmployees.Size = new System.Drawing.Size(145, 31);
            this.lblEmployees.TabIndex = 1;
            this.lblEmployees.Text = "Employees";
            this.lblEmployees.Click += new System.EventHandler(this.label2_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Black;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft YaHei", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblTitle.ForeColor = System.Drawing.SystemColors.Control;
            this.lblTitle.Location = new System.Drawing.Point(400, 11);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(206, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Media Bazaar";
            this.lblTitle.Click += new System.EventHandler(this.label1_Click);
            // 
            // panelEmployees
            // 
            this.panelEmployees.Controls.Add(this.btnDemote);
            this.panelEmployees.Controls.Add(this.btnShowInfo);
            this.panelEmployees.Controls.Add(this.lbGeneralInfo);
            this.panelEmployees.Controls.Add(this.btnPromote);
            this.panelEmployees.Controls.Add(this.lbEmployeeInfo);
            this.panelEmployees.Controls.Add(this.lblAllEmployees);
            this.panelEmployees.Controls.Add(this.cbAllEmployees);
            this.panelEmployees.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEmployees.Location = new System.Drawing.Point(0, 0);
            this.panelEmployees.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelEmployees.Name = "panelEmployees";
            this.panelEmployees.Size = new System.Drawing.Size(1043, 609);
            this.panelEmployees.TabIndex = 8;
            this.panelEmployees.Paint += new System.Windows.Forms.PaintEventHandler(this.panelEmployees_Paint);
            // 
            // btnDemote
            // 
            this.btnDemote.Location = new System.Drawing.Point(632, 230);
            this.btnDemote.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDemote.Name = "btnDemote";
            this.btnDemote.Size = new System.Drawing.Size(188, 25);
            this.btnDemote.TabIndex = 6;
            this.btnDemote.Text = "Demote";
            this.btnDemote.UseVisualStyleBackColor = true;
            this.btnDemote.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnShowInfo
            // 
            this.btnShowInfo.Location = new System.Drawing.Point(632, 165);
            this.btnShowInfo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnShowInfo.Name = "btnShowInfo";
            this.btnShowInfo.Size = new System.Drawing.Size(188, 25);
            this.btnShowInfo.TabIndex = 4;
            this.btnShowInfo.Text = "Show Info";
            this.btnShowInfo.UseVisualStyleBackColor = true;
            this.btnShowInfo.Click += new System.EventHandler(this.btnShowInfo_Click);
            // 
            // lbGeneralInfo
            // 
            this.lbGeneralInfo.FormattingEnabled = true;
            this.lbGeneralInfo.ItemHeight = 16;
            this.lbGeneralInfo.Location = new System.Drawing.Point(632, 319);
            this.lbGeneralInfo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lbGeneralInfo.Name = "lbGeneralInfo";
            this.lbGeneralInfo.Size = new System.Drawing.Size(399, 228);
            this.lbGeneralInfo.TabIndex = 7;
            // 
            // btnPromote
            // 
            this.btnPromote.Location = new System.Drawing.Point(632, 196);
            this.btnPromote.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPromote.Name = "btnPromote";
            this.btnPromote.Size = new System.Drawing.Size(188, 25);
            this.btnPromote.TabIndex = 5;
            this.btnPromote.Text = "Promote";
            this.btnPromote.UseVisualStyleBackColor = true;
            // 
            // lbEmployeeInfo
            // 
            this.lbEmployeeInfo.FormattingEnabled = true;
            this.lbEmployeeInfo.ItemHeight = 16;
            this.lbEmployeeInfo.Location = new System.Drawing.Point(17, 95);
            this.lbEmployeeInfo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lbEmployeeInfo.Name = "lbEmployeeInfo";
            this.lbEmployeeInfo.Size = new System.Drawing.Size(601, 452);
            this.lbEmployeeInfo.TabIndex = 1;
            this.lbEmployeeInfo.SelectedIndexChanged += new System.EventHandler(this.lbEmployeeInfo_SelectedIndexChanged);
            // 
            // lblAllEmployees
            // 
            this.lblAllEmployees.AutoSize = true;
            this.lblAllEmployees.Location = new System.Drawing.Point(628, 95);
            this.lblAllEmployees.Name = "lblAllEmployees";
            this.lblAllEmployees.Size = new System.Drawing.Size(81, 17);
            this.lblAllEmployees.TabIndex = 3;
            this.lblAllEmployees.Text = "Employees:";
            this.lblAllEmployees.Click += new System.EventHandler(this.lblAllEmployees_Click);
            // 
            // cbAllEmployees
            // 
            this.cbAllEmployees.FormattingEnabled = true;
            this.cbAllEmployees.Location = new System.Drawing.Point(632, 126);
            this.cbAllEmployees.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbAllEmployees.Name = "cbAllEmployees";
            this.cbAllEmployees.Size = new System.Drawing.Size(203, 24);
            this.cbAllEmployees.TabIndex = 2;
            // 
            // cbWeek
            // 
            this.cbWeek.FormattingEnabled = true;
            this.cbWeek.Location = new System.Drawing.Point(29, 107);
            this.cbWeek.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbWeek.Name = "cbWeek";
            this.cbWeek.Size = new System.Drawing.Size(183, 24);
            this.cbWeek.TabIndex = 9;
            // 
            // lblWeek
            // 
            this.lblWeek.AutoSize = true;
            this.lblWeek.Location = new System.Drawing.Point(29, 87);
            this.lblWeek.Name = "lblWeek";
            this.lblWeek.Size = new System.Drawing.Size(52, 17);
            this.lblWeek.TabIndex = 10;
            this.lblWeek.Text = "Week :";
            // 
            // btnGenerateSchedule
            // 
            this.btnGenerateSchedule.Location = new System.Drawing.Point(36, 503);
            this.btnGenerateSchedule.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGenerateSchedule.Name = "btnGenerateSchedule";
            this.btnGenerateSchedule.Size = new System.Drawing.Size(191, 55);
            this.btnGenerateSchedule.TabIndex = 11;
            this.btnGenerateSchedule.Text = "Generate \r\nSchedule\r\n";
            this.btnGenerateSchedule.UseVisualStyleBackColor = true;
            this.btnGenerateSchedule.Click += new System.EventHandler(this.btnGenerateSchedule_Click);
            // 
            // btnPreferences
            // 
            this.btnPreferences.Location = new System.Drawing.Point(453, 503);
            this.btnPreferences.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPreferences.Name = "btnPreferences";
            this.btnPreferences.Size = new System.Drawing.Size(191, 55);
            this.btnPreferences.TabIndex = 13;
            this.btnPreferences.Text = "Preferences";
            this.btnPreferences.UseVisualStyleBackColor = true;
            // 
            // lblMorningShift
            // 
            this.lblMorningShift.AutoSize = true;
            this.lblMorningShift.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblMorningShift.Location = new System.Drawing.Point(743, 490);
            this.lblMorningShift.Name = "lblMorningShift";
            this.lblMorningShift.Size = new System.Drawing.Size(211, 20);
            this.lblMorningShift.TabIndex = 14;
            this.lblMorningShift.Text = "Morning Shift : 08:00-12:30";
            // 
            // lblMiddayShift
            // 
            this.lblMiddayShift.AutoSize = true;
            this.lblMiddayShift.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblMiddayShift.Location = new System.Drawing.Point(740, 519);
            this.lblMiddayShift.Name = "lblMiddayShift";
            this.lblMiddayShift.Size = new System.Drawing.Size(214, 20);
            this.lblMiddayShift.TabIndex = 15;
            this.lblMiddayShift.Text = "Midday Shift : 12:30 - 17:00";
            // 
            // lblEveningShift
            // 
            this.lblEveningShift.AutoSize = true;
            this.lblEveningShift.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblEveningShift.Location = new System.Drawing.Point(733, 553);
            this.lblEveningShift.Name = "lblEveningShift";
            this.lblEveningShift.Size = new System.Drawing.Size(220, 20);
            this.lblEveningShift.TabIndex = 16;
            this.lblEveningShift.Text = "Evening Shift : 17:00 - 21:30";
            // 
            // cbPosition
            // 
            this.cbPosition.FormattingEnabled = true;
            this.cbPosition.Location = new System.Drawing.Point(619, 107);
            this.cbPosition.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbPosition.Name = "cbPosition";
            this.cbPosition.Size = new System.Drawing.Size(183, 24);
            this.cbPosition.TabIndex = 17;
            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = true;
            this.lblPosition.Location = new System.Drawing.Point(616, 87);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(66, 17);
            this.lblPosition.TabIndex = 18;
            this.lblPosition.Text = "Position :";
            // 
            // btnAssignForm
            // 
            this.btnAssignForm.Location = new System.Drawing.Point(837, 107);
            this.btnAssignForm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAssignForm.Name = "btnAssignForm";
            this.btnAssignForm.Size = new System.Drawing.Size(191, 25);
            this.btnAssignForm.TabIndex = 19;
            this.btnAssignForm.Text = "Assign Form";
            this.btnAssignForm.UseVisualStyleBackColor = true;
            // 
            // panelSchedule
            // 
            this.panelSchedule.Controls.Add(this.btnAssignForm);
            this.panelSchedule.Controls.Add(this.lblPosition);
            this.panelSchedule.Controls.Add(this.cbPosition);
            this.panelSchedule.Controls.Add(this.lblEveningShift);
            this.panelSchedule.Controls.Add(this.lblMiddayShift);
            this.panelSchedule.Controls.Add(this.lblMorningShift);
            this.panelSchedule.Controls.Add(this.btnPreferences);
            this.panelSchedule.Controls.Add(this.btnSaveChanges);
            this.panelSchedule.Controls.Add(this.btnGenerateSchedule);
            this.panelSchedule.Controls.Add(this.lblWeek);
            this.panelSchedule.Controls.Add(this.cbWeek);
            this.panelSchedule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSchedule.Location = new System.Drawing.Point(0, 0);
            this.panelSchedule.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelSchedule.Name = "panelSchedule";
            this.panelSchedule.Size = new System.Drawing.Size(1043, 609);
            this.panelSchedule.TabIndex = 20;
            this.panelSchedule.Paint += new System.Windows.Forms.PaintEventHandler(this.panelSchedule_Paint);
            // 
            // btnSaveChanges
            // 
            this.btnSaveChanges.Location = new System.Drawing.Point(243, 503);
            this.btnSaveChanges.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.Size = new System.Drawing.Size(191, 55);
            this.btnSaveChanges.TabIndex = 12;
            this.btnSaveChanges.Text = "Save Changes";
            this.btnSaveChanges.UseVisualStyleBackColor = true;
            // 
            // lbSickReports
            // 
            this.lbSickReports.FormattingEnabled = true;
            this.lbSickReports.ItemHeight = 16;
            this.lbSickReports.Location = new System.Drawing.Point(16, 78);
            this.lbSickReports.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lbSickReports.Name = "lbSickReports";
            this.lbSickReports.Size = new System.Drawing.Size(1000, 420);
            this.lbSickReports.TabIndex = 21;
            // 
            // btnSickConfirm
            // 
            this.btnSickConfirm.Location = new System.Drawing.Point(829, 543);
            this.btnSickConfirm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSickConfirm.Name = "btnSickConfirm";
            this.btnSickConfirm.Size = new System.Drawing.Size(213, 34);
            this.btnSickConfirm.TabIndex = 22;
            this.btnSickConfirm.Text = "Confirm";
            this.btnSickConfirm.UseVisualStyleBackColor = true;
            // 
            // btnSickDeny
            // 
            this.btnSickDeny.Location = new System.Drawing.Point(12, 543);
            this.btnSickDeny.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSickDeny.Name = "btnSickDeny";
            this.btnSickDeny.Size = new System.Drawing.Size(213, 34);
            this.btnSickDeny.TabIndex = 23;
            this.btnSickDeny.Text = "Deny";
            this.btnSickDeny.UseVisualStyleBackColor = true;
            // 
            // panelSickReports
            // 
            this.panelSickReports.Controls.Add(this.lbSickReports);
            this.panelSickReports.Controls.Add(this.btnSickConfirm);
            this.panelSickReports.Controls.Add(this.btnSickDeny);
            this.panelSickReports.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSickReports.Location = new System.Drawing.Point(0, 0);
            this.panelSickReports.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelSickReports.Name = "panelSickReports";
            this.panelSickReports.Size = new System.Drawing.Size(1043, 609);
            this.panelSickReports.TabIndex = 24;
            this.panelSickReports.Paint += new System.Windows.Forms.PaintEventHandler(this.panelSickReports_Paint);
            // 
            // pnlDayOff
            // 
            this.pnlDayOff.Controls.Add(this.btnDenyDayOff);
            this.pnlDayOff.Controls.Add(this.btnConfirmDayOff);
            this.pnlDayOff.Controls.Add(this.lbDayOff);
            this.pnlDayOff.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDayOff.Location = new System.Drawing.Point(0, 0);
            this.pnlDayOff.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlDayOff.Name = "pnlDayOff";
            this.pnlDayOff.Size = new System.Drawing.Size(1043, 609);
            this.pnlDayOff.TabIndex = 24;
            // 
            // btnDenyDayOff
            // 
            this.btnDenyDayOff.Location = new System.Drawing.Point(823, 555);
            this.btnDenyDayOff.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDenyDayOff.Name = "btnDenyDayOff";
            this.btnDenyDayOff.Size = new System.Drawing.Size(213, 30);
            this.btnDenyDayOff.TabIndex = 26;
            this.btnDenyDayOff.Text = "Deny";
            this.btnDenyDayOff.UseVisualStyleBackColor = true;
            // 
            // btnConfirmDayOff
            // 
            this.btnConfirmDayOff.Location = new System.Drawing.Point(13, 555);
            this.btnConfirmDayOff.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnConfirmDayOff.Name = "btnConfirmDayOff";
            this.btnConfirmDayOff.Size = new System.Drawing.Size(209, 30);
            this.btnConfirmDayOff.TabIndex = 25;
            this.btnConfirmDayOff.Text = "Confirm";
            this.btnConfirmDayOff.UseVisualStyleBackColor = true;
            this.btnConfirmDayOff.Click += new System.EventHandler(this.btnConfirmDayOff_Click);
            // 
            // lbDayOff
            // 
            this.lbDayOff.FormattingEnabled = true;
            this.lbDayOff.ItemHeight = 16;
            this.lbDayOff.Location = new System.Drawing.Point(13, 98);
            this.lbDayOff.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lbDayOff.Name = "lbDayOff";
            this.lbDayOff.Size = new System.Drawing.Size(1003, 420);
            this.lbDayOff.TabIndex = 24;
            // 
            // pnlNavbar
            // 
            this.pnlNavbar.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pnlNavbar.Controls.Add(this.lblTitle);
            this.pnlNavbar.Controls.Add(this.lblDayOffReports);
            this.pnlNavbar.Controls.Add(this.lblEmployees);
            this.pnlNavbar.Controls.Add(this.lblSickReports);
            this.pnlNavbar.Controls.Add(this.lblSchedule);
            this.pnlNavbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlNavbar.Location = new System.Drawing.Point(0, 0);
            this.pnlNavbar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlNavbar.Name = "pnlNavbar";
            this.pnlNavbar.Size = new System.Drawing.Size(1043, 59);
            this.pnlNavbar.TabIndex = 5;
            // 
            // HRHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1043, 609);
            this.Controls.Add(this.pnlNavbar);
            this.Controls.Add(this.pnlDayOff);
            this.Controls.Add(this.panelSickReports);
            this.Controls.Add(this.panelEmployees);
            this.Controls.Add(this.panelSchedule);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "HRHome";
            this.Text = "HRHome";
            this.Load += new System.EventHandler(this.HRHome_Load);
            this.panelEmployees.ResumeLayout(false);
            this.panelEmployees.PerformLayout();
            this.panelSchedule.ResumeLayout(false);
            this.panelSchedule.PerformLayout();
            this.panelSickReports.ResumeLayout(false);
            this.pnlDayOff.ResumeLayout(false);
            this.pnlNavbar.ResumeLayout(false);
            this.pnlNavbar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblDayOffReports;
        private System.Windows.Forms.Label lblSickReports;
        private System.Windows.Forms.Label lblSchedule;
        private System.Windows.Forms.Label lblEmployees;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ComboBox cbAllEmployees;
        private System.Windows.Forms.Label lblAllEmployees;
        private System.Windows.Forms.Button btnShowInfo;
        private System.Windows.Forms.Button btnPromote;
        private System.Windows.Forms.Button btnDemote;
        private System.Windows.Forms.ListBox lbGeneralInfo;
        private System.Windows.Forms.ListBox lbEmployeeInfo;
        private System.Windows.Forms.Panel panelEmployees;
        private System.Windows.Forms.ComboBox cbWeek;
        private System.Windows.Forms.Label lblWeek;
        private System.Windows.Forms.Button btnGenerateSchedule;
        private System.Windows.Forms.Button btnPreferences;
        private System.Windows.Forms.Label lblMorningShift;
        private System.Windows.Forms.Label lblMiddayShift;
        private System.Windows.Forms.Label lblEveningShift;
        private System.Windows.Forms.ComboBox cbPosition;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.Button btnAssignForm;
        private System.Windows.Forms.Panel panelSchedule;
        private System.Windows.Forms.ListBox lbSickReports;
        private System.Windows.Forms.Button btnSickConfirm;
        private System.Windows.Forms.Button btnSickDeny;
        private System.Windows.Forms.Panel panelSickReports;
        private System.Windows.Forms.Panel pnlDayOff;
        private System.Windows.Forms.Button btnDenyDayOff;
        private System.Windows.Forms.Button btnConfirmDayOff;
        private System.Windows.Forms.ListBox lbDayOff;
        private System.Windows.Forms.Button btnSaveChanges;
        private System.Windows.Forms.Panel pnlNavbar;
    }
}