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
            this.lbAvailableEmployees = new System.Windows.Forms.ListBox();
            this.lbUnavailableEmployees = new System.Windows.Forms.ListBox();
            this.lblPosition = new System.Windows.Forms.Label();
            this.lblShift = new System.Windows.Forms.Label();
            this.lblDay = new System.Windows.Forms.Label();
            this.btnAssign = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbAvailableEmployees
            // 
            this.lbAvailableEmployees.FormattingEnabled = true;
            this.lbAvailableEmployees.Location = new System.Drawing.Point(12, 86);
            this.lbAvailableEmployees.Name = "lbAvailableEmployees";
            this.lbAvailableEmployees.Size = new System.Drawing.Size(449, 303);
            this.lbAvailableEmployees.TabIndex = 0;
            // 
            // lbUnavailableEmployees
            // 
            this.lbUnavailableEmployees.FormattingEnabled = true;
            this.lbUnavailableEmployees.Location = new System.Drawing.Point(477, 86);
            this.lbUnavailableEmployees.Name = "lbUnavailableEmployees";
            this.lbUnavailableEmployees.Size = new System.Drawing.Size(477, 303);
            this.lbUnavailableEmployees.TabIndex = 1;
            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = true;
            this.lblPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPosition.Location = new System.Drawing.Point(283, 31);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(76, 24);
            this.lblPosition.TabIndex = 2;
            this.lblPosition.Text = "Position";
            // 
            // lblShift
            // 
            this.lblShift.AutoSize = true;
            this.lblShift.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShift.Location = new System.Drawing.Point(660, 31);
            this.lblShift.Name = "lblShift";
            this.lblShift.Size = new System.Drawing.Size(45, 24);
            this.lblShift.TabIndex = 2;
            this.lblShift.Text = "Shift";
            // 
            // lblDay
            // 
            this.lblDay.AutoSize = true;
            this.lblDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDay.Location = new System.Drawing.Point(12, 31);
            this.lblDay.Name = "lblDay";
            this.lblDay.Size = new System.Drawing.Size(40, 24);
            this.lblDay.TabIndex = 2;
            this.lblDay.Text = "day";
            // 
            // btnAssign
            // 
            this.btnAssign.Location = new System.Drawing.Point(98, 395);
            this.btnAssign.Name = "btnAssign";
            this.btnAssign.Size = new System.Drawing.Size(109, 56);
            this.btnAssign.TabIndex = 3;
            this.btnAssign.Text = "Assign";
            this.btnAssign.UseVisualStyleBackColor = true;
            this.btnAssign.Click += new System.EventHandler(this.btnAssign_Click);
            // 
            // ShiftAssigning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(966, 540);
            this.Controls.Add(this.btnAssign);
            this.Controls.Add(this.lblDay);
            this.Controls.Add(this.lblShift);
            this.Controls.Add(this.lblPosition);
            this.Controls.Add(this.lbUnavailableEmployees);
            this.Controls.Add(this.lbAvailableEmployees);
            this.Name = "ShiftAssigning";
            this.Text = "ShiftAssigning";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ShiftAssigning_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbAvailableEmployees;
        private System.Windows.Forms.ListBox lbUnavailableEmployees;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.Label lblShift;
        private System.Windows.Forms.Label lblDay;
        private System.Windows.Forms.Button btnAssign;
    }
}