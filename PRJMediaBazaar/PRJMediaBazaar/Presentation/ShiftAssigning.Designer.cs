namespace PRJMediaBazaar
{
    partial class ShiftAssigning
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
            this.lblPosition = new System.Windows.Forms.Label();
            this.lblShift = new System.Windows.Forms.Label();
            this.lblDay = new System.Windows.Forms.Label();
            this.customInstaller1 = new MySql.Data.MySqlClient.CustomInstaller();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.PanelTableScrollAvailable = new System.Windows.Forms.Panel();
            this.AvailableTable = new System.Windows.Forms.TableLayoutPanel();
            this.PanelTableScrollUnavailable = new System.Windows.Forms.Panel();
            this.UnavailableTable = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.PanelTableScrollAvailable.SuspendLayout();
            this.PanelTableScrollUnavailable.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = true;
            this.lblPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPosition.Location = new System.Drawing.Point(817, 265);
            this.lblPosition.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(106, 29);
            this.lblPosition.TabIndex = 2;
            this.lblPosition.Text = "Position:";
            // 
            // lblShift
            // 
            this.lblShift.AutoSize = true;
            this.lblShift.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShift.Location = new System.Drawing.Point(817, 294);
            this.lblShift.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblShift.Name = "lblShift";
            this.lblShift.Size = new System.Drawing.Size(60, 29);
            this.lblShift.TabIndex = 2;
            this.lblShift.Text = "Shift";
            // 
            // lblDay
            // 
            this.lblDay.AutoSize = true;
            this.lblDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDay.Location = new System.Drawing.Point(817, 235);
            this.lblDay.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDay.Name = "lblDay";
            this.lblDay.Size = new System.Drawing.Size(69, 29);
            this.lblDay.TabIndex = 2;
            this.lblDay.Text = "Date:";
            // 
            // customInstaller1
            // 
            this.customInstaller1.AfterInstall += new System.Configuration.Install.InstallEventHandler(this.customInstaller1_AfterInstall);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(32, 78);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkRed;
            this.label2.Location = new System.Drawing.Point(1228, 11);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(409, 42);
            this.label2.TabIndex = 2;
            this.label2.Text = "Unavailable Employees";
            // 
            // PanelTableScrollAvailable
            // 
            this.PanelTableScrollAvailable.AutoScroll = true;
            this.PanelTableScrollAvailable.BackColor = System.Drawing.Color.Silver;
            this.PanelTableScrollAvailable.Controls.Add(this.AvailableTable);
            this.PanelTableScrollAvailable.Location = new System.Drawing.Point(13, 111);
            this.PanelTableScrollAvailable.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PanelTableScrollAvailable.Name = "PanelTableScrollAvailable";
            this.PanelTableScrollAvailable.Size = new System.Drawing.Size(796, 438);
            this.PanelTableScrollAvailable.TabIndex = 31;
            // 
            // AvailableTable
            // 
            this.AvailableTable.AutoSize = true;
            this.AvailableTable.BackColor = System.Drawing.Color.Silver;
            this.AvailableTable.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.AvailableTable.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.AvailableTable.ColumnCount = 6;
            this.AvailableTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.AvailableTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.72727F));
            this.AvailableTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.72727F));
            this.AvailableTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.63636F));
            this.AvailableTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.63636F));
            this.AvailableTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.18182F));
            this.AvailableTable.Dock = System.Windows.Forms.DockStyle.Top;
            this.AvailableTable.Location = new System.Drawing.Point(0, 0);
            this.AvailableTable.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.AvailableTable.Name = "AvailableTable";
            this.AvailableTable.RowCount = 1;
            this.AvailableTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.AvailableTable.Size = new System.Drawing.Size(796, 4);
            this.AvailableTable.TabIndex = 11;
            // 
            // PanelTableScrollUnavailable
            // 
            this.PanelTableScrollUnavailable.AutoScroll = true;
            this.PanelTableScrollUnavailable.BackColor = System.Drawing.Color.Silver;
            this.PanelTableScrollUnavailable.Controls.Add(this.UnavailableTable);
            this.PanelTableScrollUnavailable.Location = new System.Drawing.Point(1057, 111);
            this.PanelTableScrollUnavailable.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PanelTableScrollUnavailable.Name = "PanelTableScrollUnavailable";
            this.PanelTableScrollUnavailable.Size = new System.Drawing.Size(761, 438);
            this.PanelTableScrollUnavailable.TabIndex = 31;
            // 
            // UnavailableTable
            // 
            this.UnavailableTable.AutoSize = true;
            this.UnavailableTable.BackColor = System.Drawing.Color.Silver;
            this.UnavailableTable.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.UnavailableTable.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.UnavailableTable.ColumnCount = 5;
            this.UnavailableTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.UnavailableTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.25F));
            this.UnavailableTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.25F));
            this.UnavailableTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.UnavailableTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.UnavailableTable.Dock = System.Windows.Forms.DockStyle.Top;
            this.UnavailableTable.Location = new System.Drawing.Point(0, 0);
            this.UnavailableTable.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.UnavailableTable.Name = "UnavailableTable";
            this.UnavailableTable.RowCount = 1;
            this.UnavailableTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.UnavailableTable.Size = new System.Drawing.Size(761, 4);
            this.UnavailableTable.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(137, 78);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 29);
            this.label3.TabIndex = 2;
            this.label3.Text = "Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(284, 78);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 29);
            this.label4.TabIndex = 2;
            this.label4.Text = "Occupation";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(443, 78);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 29);
            this.label5.TabIndex = 2;
            this.label5.Text = "Worked";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(552, 78);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 29);
            this.label6.TabIndex = 2;
            this.label6.Text = "Contract";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(1091, 78);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 29);
            this.label7.TabIndex = 2;
            this.label7.Text = "ID";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(1619, 78);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 29);
            this.label8.TabIndex = 2;
            this.label8.Text = "Worked";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(1728, 78);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(102, 29);
            this.label9.TabIndex = 2;
            this.label9.Text = "Contract";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(1231, 78);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(78, 29);
            this.label10.TabIndex = 2;
            this.label10.Text = "Name";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(1416, 78);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(135, 29);
            this.label11.TabIndex = 2;
            this.label11.Text = "Occupation";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.DarkGreen;
            this.label12.Location = new System.Drawing.Point(184, 11);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(365, 42);
            this.label12.TabIndex = 2;
            this.label12.Text = "Available Employees";
            // 
            // ShiftAssigning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1835, 564);
            this.Controls.Add(this.PanelTableScrollUnavailable);
            this.Controls.Add(this.PanelTableScrollAvailable);
            this.Controls.Add(this.lblDay);
            this.Controls.Add(this.lblShift);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblPosition);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ShiftAssigning";
            this.Text = "ShiftAssigning";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ShiftAssigning_FormClosed);
            this.PanelTableScrollAvailable.ResumeLayout(false);
            this.PanelTableScrollAvailable.PerformLayout();
            this.PanelTableScrollUnavailable.ResumeLayout(false);
            this.PanelTableScrollUnavailable.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.Label lblShift;
        private System.Windows.Forms.Label lblDay;
        private MySql.Data.MySqlClient.CustomInstaller customInstaller1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel PanelTableScrollAvailable;
        public System.Windows.Forms.TableLayoutPanel AvailableTable;
        private System.Windows.Forms.Panel PanelTableScrollUnavailable;
        public System.Windows.Forms.TableLayoutPanel UnavailableTable;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
    }
}