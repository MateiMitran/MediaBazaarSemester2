
namespace PRJMediaBazaar
{
    partial class WRHSHome
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.pnlNavbar = new System.Windows.Forms.Panel();
            this.pnlAccount = new System.Windows.Forms.Panel();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.btnChangePassword = new System.Windows.Forms.Button();
            this.lblConfirmNewPassword = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblNewPassword = new System.Windows.Forms.Label();
            this.tbVerifyNewPassword = new System.Windows.Forms.TextBox();
            this.tbCurrentPassword = new System.Windows.Forms.TextBox();
            this.tbNewPassword = new System.Windows.Forms.TextBox();
            this.pnlStatistics = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pnlRestock = new System.Windows.Forms.Panel();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.lbRestockRequests = new System.Windows.Forms.ListBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblAccount = new System.Windows.Forms.Label();
            this.lblItems = new System.Windows.Forms.Label();
            this.lblRestock = new System.Windows.Forms.Label();
            this.lblStatistics = new System.Windows.Forms.Label();
            this.pnlItems = new System.Windows.Forms.Panel();
            this.btnEditItem = new System.Windows.Forms.Button();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.cbItems = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbItems = new System.Windows.Forms.ListBox();
            this.lblInfo = new System.Windows.Forms.Label();
            this.godTimer = new System.Windows.Forms.Timer(this.components);
            this.pnlNavbar.SuspendLayout();
            this.pnlAccount.SuspendLayout();
            this.pnlStatistics.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.pnlRestock.SuspendLayout();
            this.pnlItems.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlNavbar
            // 
            this.pnlNavbar.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pnlNavbar.Controls.Add(this.pnlAccount);
            this.pnlNavbar.Controls.Add(this.pnlStatistics);
            this.pnlNavbar.Controls.Add(this.pnlRestock);
            this.pnlNavbar.Controls.Add(this.lblTitle);
            this.pnlNavbar.Controls.Add(this.lblAccount);
            this.pnlNavbar.Controls.Add(this.lblItems);
            this.pnlNavbar.Controls.Add(this.lblRestock);
            this.pnlNavbar.Controls.Add(this.lblStatistics);
            this.pnlNavbar.Location = new System.Drawing.Point(1, 1);
            this.pnlNavbar.Margin = new System.Windows.Forms.Padding(4);
            this.pnlNavbar.Name = "pnlNavbar";
            this.pnlNavbar.Size = new System.Drawing.Size(893, 59);
            this.pnlNavbar.TabIndex = 6;
            // 
            // pnlAccount
            // 
            this.pnlAccount.Controls.Add(this.btnLogOut);
            this.pnlAccount.Controls.Add(this.btnChangePassword);
            this.pnlAccount.Controls.Add(this.lblConfirmNewPassword);
            this.pnlAccount.Controls.Add(this.label4);
            this.pnlAccount.Controls.Add(this.lblNewPassword);
            this.pnlAccount.Controls.Add(this.tbVerifyNewPassword);
            this.pnlAccount.Controls.Add(this.tbCurrentPassword);
            this.pnlAccount.Controls.Add(this.tbNewPassword);
            this.pnlAccount.Location = new System.Drawing.Point(780, 17);
            this.pnlAccount.Name = "pnlAccount";
            this.pnlAccount.Size = new System.Drawing.Size(90, 29);
            this.pnlAccount.TabIndex = 18;
            // 
            // btnLogOut
            // 
            this.btnLogOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogOut.Location = new System.Drawing.Point(32, 304);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(289, 34);
            this.btnLogOut.TabIndex = 17;
            this.btnLogOut.Text = "Log Out";
            this.btnLogOut.UseVisualStyleBackColor = true;
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnChangePassword.Location = new System.Drawing.Point(32, 241);
            this.btnChangePassword.Margin = new System.Windows.Forms.Padding(2);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(289, 34);
            this.btnChangePassword.TabIndex = 16;
            this.btnChangePassword.Text = "Change Password";
            this.btnChangePassword.UseVisualStyleBackColor = true;
            // 
            // lblConfirmNewPassword
            // 
            this.lblConfirmNewPassword.AutoSize = true;
            this.lblConfirmNewPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblConfirmNewPassword.Location = new System.Drawing.Point(28, 162);
            this.lblConfirmNewPassword.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblConfirmNewPassword.Name = "lblConfirmNewPassword";
            this.lblConfirmNewPassword.Size = new System.Drawing.Size(190, 20);
            this.lblConfirmNewPassword.TabIndex = 13;
            this.lblConfirmNewPassword.Text = "Confirm New Password:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.Location = new System.Drawing.Point(28, 29);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(149, 20);
            this.label4.TabIndex = 14;
            this.label4.Text = "Current Password:";
            // 
            // lblNewPassword
            // 
            this.lblNewPassword.AutoSize = true;
            this.lblNewPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblNewPassword.Location = new System.Drawing.Point(28, 96);
            this.lblNewPassword.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNewPassword.Name = "lblNewPassword";
            this.lblNewPassword.Size = new System.Drawing.Size(126, 20);
            this.lblNewPassword.TabIndex = 15;
            this.lblNewPassword.Text = "New Password:";
            // 
            // tbVerifyNewPassword
            // 
            this.tbVerifyNewPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tbVerifyNewPassword.Location = new System.Drawing.Point(32, 185);
            this.tbVerifyNewPassword.Margin = new System.Windows.Forms.Padding(2);
            this.tbVerifyNewPassword.Name = "tbVerifyNewPassword";
            this.tbVerifyNewPassword.PasswordChar = '*';
            this.tbVerifyNewPassword.Size = new System.Drawing.Size(290, 26);
            this.tbVerifyNewPassword.TabIndex = 10;
            this.tbVerifyNewPassword.UseSystemPasswordChar = true;
            // 
            // tbCurrentPassword
            // 
            this.tbCurrentPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tbCurrentPassword.Location = new System.Drawing.Point(32, 52);
            this.tbCurrentPassword.Margin = new System.Windows.Forms.Padding(2);
            this.tbCurrentPassword.Name = "tbCurrentPassword";
            this.tbCurrentPassword.PasswordChar = '*';
            this.tbCurrentPassword.Size = new System.Drawing.Size(290, 26);
            this.tbCurrentPassword.TabIndex = 11;
            this.tbCurrentPassword.UseSystemPasswordChar = true;
            // 
            // tbNewPassword
            // 
            this.tbNewPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tbNewPassword.Location = new System.Drawing.Point(32, 119);
            this.tbNewPassword.Margin = new System.Windows.Forms.Padding(2);
            this.tbNewPassword.Name = "tbNewPassword";
            this.tbNewPassword.PasswordChar = '*';
            this.tbNewPassword.Size = new System.Drawing.Size(290, 26);
            this.tbNewPassword.TabIndex = 12;
            this.tbNewPassword.UseSystemPasswordChar = true;
            // 
            // pnlStatistics
            // 
            this.pnlStatistics.Controls.Add(this.label3);
            this.pnlStatistics.Controls.Add(this.label2);
            this.pnlStatistics.Controls.Add(this.chart2);
            this.pnlStatistics.Controls.Add(this.chart1);
            this.pnlStatistics.Location = new System.Drawing.Point(235, 16);
            this.pnlStatistics.Name = "pnlStatistics";
            this.pnlStatistics.Size = new System.Drawing.Size(50, 30);
            this.pnlStatistics.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(540, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(223, 25);
            this.label3.TabIndex = 10;
            this.label3.Text = "Most Expensive Items";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(94, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(167, 25);
            this.label2.TabIndex = 9;
            this.label2.Text = "Most Sold Items";
            // 
            // chart2
            // 
            chartArea3.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chart2.Legends.Add(legend3);
            this.chart2.Location = new System.Drawing.Point(520, 95);
            this.chart2.Name = "chart2";
            this.chart2.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chart2.Series.Add(series3);
            this.chart2.Size = new System.Drawing.Size(300, 300);
            this.chart2.TabIndex = 8;
            this.chart2.Text = "chart2";
            // 
            // chart1
            // 
            chartArea4.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chart1.Legends.Add(legend4);
            this.chart1.Location = new System.Drawing.Point(53, 95);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.chart1.Series.Add(series4);
            this.chart1.Size = new System.Drawing.Size(300, 300);
            this.chart1.TabIndex = 7;
            this.chart1.Text = "chart1";
            // 
            // pnlRestock
            // 
            this.pnlRestock.Controls.Add(this.btnConfirm);
            this.pnlRestock.Controls.Add(this.lbRestockRequests);
            this.pnlRestock.Location = new System.Drawing.Point(575, 9);
            this.pnlRestock.Name = "pnlRestock";
            this.pnlRestock.Size = new System.Drawing.Size(37, 35);
            this.pnlRestock.TabIndex = 9;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(267, 563);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(373, 40);
            this.btnConfirm.TabIndex = 8;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = true;
            // 
            // lbRestockRequests
            // 
            this.lbRestockRequests.FormattingEnabled = true;
            this.lbRestockRequests.ItemHeight = 16;
            this.lbRestockRequests.Location = new System.Drawing.Point(272, 186);
            this.lbRestockRequests.Name = "lbRestockRequests";
            this.lbRestockRequests.Size = new System.Drawing.Size(227, 228);
            this.lbRestockRequests.TabIndex = 7;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Black;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft YaHei", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblTitle.ForeColor = System.Drawing.SystemColors.Control;
            this.lblTitle.Location = new System.Drawing.Point(333, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(206, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Media Bazaar";
            // 
            // lblAccount
            // 
            this.lblAccount.AutoSize = true;
            this.lblAccount.BackColor = System.Drawing.Color.Black;
            this.lblAccount.Font = new System.Drawing.Font("Microsoft YaHei", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblAccount.ForeColor = System.Drawing.SystemColors.Control;
            this.lblAccount.Location = new System.Drawing.Point(724, 13);
            this.lblAccount.Name = "lblAccount";
            this.lblAccount.Size = new System.Drawing.Size(114, 31);
            this.lblAccount.TabIndex = 4;
            this.lblAccount.Text = "Account";
            this.lblAccount.Click += new System.EventHandler(this.lblAccount_Click);
            // 
            // lblItems
            // 
            this.lblItems.AutoSize = true;
            this.lblItems.BackColor = System.Drawing.Color.Black;
            this.lblItems.Font = new System.Drawing.Font("Microsoft YaHei", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblItems.ForeColor = System.Drawing.SystemColors.Control;
            this.lblItems.Location = new System.Drawing.Point(21, 13);
            this.lblItems.Name = "lblItems";
            this.lblItems.Size = new System.Drawing.Size(82, 31);
            this.lblItems.TabIndex = 1;
            this.lblItems.Text = "Items";
            this.lblItems.Click += new System.EventHandler(this.lblItems_Click);
            // 
            // lblRestock
            // 
            this.lblRestock.AutoSize = true;
            this.lblRestock.BackColor = System.Drawing.Color.Black;
            this.lblRestock.Font = new System.Drawing.Font("Microsoft YaHei", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblRestock.ForeColor = System.Drawing.SystemColors.Control;
            this.lblRestock.Location = new System.Drawing.Point(569, 13);
            this.lblRestock.Name = "lblRestock";
            this.lblRestock.Size = new System.Drawing.Size(109, 31);
            this.lblRestock.TabIndex = 3;
            this.lblRestock.Text = "Restock";
            this.lblRestock.Click += new System.EventHandler(this.lblRestock_Click);
            // 
            // lblStatistics
            // 
            this.lblStatistics.AutoSize = true;
            this.lblStatistics.BackColor = System.Drawing.Color.Black;
            this.lblStatistics.Font = new System.Drawing.Font("Microsoft YaHei", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblStatistics.ForeColor = System.Drawing.SystemColors.Control;
            this.lblStatistics.Location = new System.Drawing.Point(163, 15);
            this.lblStatistics.Name = "lblStatistics";
            this.lblStatistics.Size = new System.Drawing.Size(122, 31);
            this.lblStatistics.TabIndex = 2;
            this.lblStatistics.Text = "Statistics";
            this.lblStatistics.Click += new System.EventHandler(this.lblStatistics_Click);
            // 
            // pnlItems
            // 
            this.pnlItems.Controls.Add(this.btnEditItem);
            this.pnlItems.Controls.Add(this.btnAddItem);
            this.pnlItems.Controls.Add(this.cbItems);
            this.pnlItems.Controls.Add(this.label1);
            this.pnlItems.Controls.Add(this.lbItems);
            this.pnlItems.Controls.Add(this.lblInfo);
            this.pnlItems.Location = new System.Drawing.Point(1, 67);
            this.pnlItems.Name = "pnlItems";
            this.pnlItems.Size = new System.Drawing.Size(893, 610);
            this.pnlItems.TabIndex = 13;
            // 
            // btnEditItem
            // 
            this.btnEditItem.Location = new System.Drawing.Point(369, 188);
            this.btnEditItem.Name = "btnEditItem";
            this.btnEditItem.Size = new System.Drawing.Size(313, 27);
            this.btnEditItem.TabIndex = 12;
            this.btnEditItem.Text = "Edit Current Item";
            this.btnEditItem.UseVisualStyleBackColor = true;
            // 
            // btnAddItem
            // 
            this.btnAddItem.Location = new System.Drawing.Point(369, 144);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(313, 27);
            this.btnAddItem.TabIndex = 11;
            this.btnAddItem.Text = "Add a New Item";
            this.btnAddItem.UseVisualStyleBackColor = true;
            // 
            // cbItems
            // 
            this.cbItems.FormattingEnabled = true;
            this.cbItems.Location = new System.Drawing.Point(369, 44);
            this.cbItems.Name = "cbItems";
            this.cbItems.Size = new System.Drawing.Size(313, 24);
            this.cbItems.TabIndex = 10;
            this.cbItems.SelectedIndexChanged += new System.EventHandler(this.cbItems_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(364, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 25);
            this.label1.TabIndex = 9;
            this.label1.Text = "Items :";
            // 
            // lbItems
            // 
            this.lbItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbItems.FormattingEnabled = true;
            this.lbItems.ItemHeight = 22;
            this.lbItems.Location = new System.Drawing.Point(11, 44);
            this.lbItems.Name = "lbItems";
            this.lbItems.Size = new System.Drawing.Size(316, 466);
            this.lbItems.TabIndex = 7;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblInfo.Location = new System.Drawing.Point(11, 16);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(132, 25);
            this.lblInfo.TabIndex = 8;
            this.lblInfo.Text = "Information :";
            // 
            // godTimer
            // 
            this.godTimer.Enabled = true;
            this.godTimer.Interval = 2500;
            this.godTimer.Tick += new System.EventHandler(this.godTimer_Tick);
            // 
            // WRHSHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 679);
            this.Controls.Add(this.pnlNavbar);
            this.Controls.Add(this.pnlItems);
            this.Name = "WRHSHome";
            this.Text = "WRHSHome";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WRHSHome_FormClosing_1);
            this.Load += new System.EventHandler(this.WRHSHome_Load);
            this.pnlNavbar.ResumeLayout(false);
            this.pnlNavbar.PerformLayout();
            this.pnlAccount.ResumeLayout(false);
            this.pnlAccount.PerformLayout();
            this.pnlStatistics.ResumeLayout(false);
            this.pnlStatistics.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.pnlRestock.ResumeLayout(false);
            this.pnlItems.ResumeLayout(false);
            this.pnlItems.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlNavbar;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblAccount;
        private System.Windows.Forms.Label lblItems;
        private System.Windows.Forms.Label lblRestock;
        private System.Windows.Forms.Label lblStatistics;
        private System.Windows.Forms.Panel pnlItems;
        private System.Windows.Forms.Button btnEditItem;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.ComboBox cbItems;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbItems;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Panel pnlAccount;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Button btnChangePassword;
        private System.Windows.Forms.Label lblConfirmNewPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblNewPassword;
        private System.Windows.Forms.TextBox tbVerifyNewPassword;
        private System.Windows.Forms.TextBox tbCurrentPassword;
        private System.Windows.Forms.TextBox tbNewPassword;
        private System.Windows.Forms.Panel pnlStatistics;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.Panel pnlRestock;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.ListBox lbRestockRequests;
        private System.Windows.Forms.Timer godTimer;
    }
}