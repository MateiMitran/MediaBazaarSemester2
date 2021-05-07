
namespace PRJMediaBazaar
{
    partial class StockerHome
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
            this.pnlNavbar = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblDashboard = new System.Windows.Forms.Label();
            this.lblRestocks = new System.Windows.Forms.Label();
            this.lbItemsInShop = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.pnlDashboard = new System.Windows.Forms.Panel();
            this.pnlRestocks = new System.Windows.Forms.Panel();
            this.lbRestocks = new System.Windows.Forms.ListBox();
            this.btnSendRequest = new System.Windows.Forms.Button();
            this.pnlNavbar.SuspendLayout();
            this.pnlDashboard.SuspendLayout();
            this.pnlRestocks.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlNavbar
            // 
            this.pnlNavbar.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pnlNavbar.Controls.Add(this.pnlRestocks);
            this.pnlNavbar.Controls.Add(this.pnlDashboard);
            this.pnlNavbar.Controls.Add(this.lblRestocks);
            this.pnlNavbar.Controls.Add(this.lblDashboard);
            this.pnlNavbar.Controls.Add(this.lblTitle);
            this.pnlNavbar.Location = new System.Drawing.Point(1, 1);
            this.pnlNavbar.Name = "pnlNavbar";
            this.pnlNavbar.Size = new System.Drawing.Size(831, 47);
            this.pnlNavbar.TabIndex = 8;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Black;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft YaHei", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblTitle.ForeColor = System.Drawing.SystemColors.Control;
            this.lblTitle.Location = new System.Drawing.Point(358, 8);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(165, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Media Bazaar";
            // 
            // lblDashboard
            // 
            this.lblDashboard.AutoSize = true;
            this.lblDashboard.BackColor = System.Drawing.Color.Black;
            this.lblDashboard.Font = new System.Drawing.Font("Microsoft YaHei", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblDashboard.ForeColor = System.Drawing.SystemColors.Control;
            this.lblDashboard.Location = new System.Drawing.Point(49, 8);
            this.lblDashboard.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDashboard.Name = "lblDashboard";
            this.lblDashboard.Size = new System.Drawing.Size(134, 30);
            this.lblDashboard.TabIndex = 1;
            this.lblDashboard.Text = "Dashboard";
            // 
            // lblRestocks
            // 
            this.lblRestocks.AutoSize = true;
            this.lblRestocks.BackColor = System.Drawing.Color.Black;
            this.lblRestocks.Font = new System.Drawing.Font("Microsoft YaHei", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblRestocks.ForeColor = System.Drawing.SystemColors.Control;
            this.lblRestocks.Location = new System.Drawing.Point(645, 8);
            this.lblRestocks.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRestocks.Name = "lblRestocks";
            this.lblRestocks.Size = new System.Drawing.Size(110, 30);
            this.lblRestocks.TabIndex = 2;
            this.lblRestocks.Text = "Restocks";
            // 
            // lbItemsInShop
            // 
            this.lbItemsInShop.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbItemsInShop.FormattingEnabled = true;
            this.lbItemsInShop.ItemHeight = 18;
            this.lbItemsInShop.Location = new System.Drawing.Point(4, 37);
            this.lbItemsInShop.Name = "lbItemsInShop";
            this.lbItemsInShop.Size = new System.Drawing.Size(341, 382);
            this.lbItemsInShop.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Items in Shop :";
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.Location = new System.Drawing.Point(429, 55);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(23, 20);
            this.lblInfo.TabIndex = 11;
            this.lblInfo.Text = "xx";
            this.lblInfo.Visible = false;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(433, 115);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(146, 31);
            this.button1.TabIndex = 12;
            this.button1.Text = "Move";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            // 
            // pnlDashboard
            // 
            this.pnlDashboard.Controls.Add(this.button1);
            this.pnlDashboard.Controls.Add(this.lblInfo);
            this.pnlDashboard.Controls.Add(this.label3);
            this.pnlDashboard.Controls.Add(this.lbItemsInShop);
            this.pnlDashboard.Location = new System.Drawing.Point(142, 11);
            this.pnlDashboard.Name = "pnlDashboard";
            this.pnlDashboard.Size = new System.Drawing.Size(100, 23);
            this.pnlDashboard.TabIndex = 13;
            // 
            // pnlRestocks
            // 
            this.pnlRestocks.Controls.Add(this.btnSendRequest);
            this.pnlRestocks.Controls.Add(this.lbRestocks);
            this.pnlRestocks.Location = new System.Drawing.Point(695, 13);
            this.pnlRestocks.Name = "pnlRestocks";
            this.pnlRestocks.Size = new System.Drawing.Size(103, 21);
            this.pnlRestocks.TabIndex = 9;
            // 
            // lbRestocks
            // 
            this.lbRestocks.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRestocks.FormattingEnabled = true;
            this.lbRestocks.ItemHeight = 24;
            this.lbRestocks.Location = new System.Drawing.Point(118, 18);
            this.lbRestocks.Name = "lbRestocks";
            this.lbRestocks.Size = new System.Drawing.Size(586, 364);
            this.lbRestocks.TabIndex = 0;
            // 
            // btnSendRequest
            // 
            this.btnSendRequest.Location = new System.Drawing.Point(302, 397);
            this.btnSendRequest.Name = "btnSendRequest";
            this.btnSendRequest.Size = new System.Drawing.Size(232, 32);
            this.btnSendRequest.TabIndex = 1;
            this.btnSendRequest.Text = "Send To Manager";
            this.btnSendRequest.UseVisualStyleBackColor = true;
            // 
            // StockerHome
            // 
            this.ClientSize = new System.Drawing.Size(832, 499);
            this.Controls.Add(this.pnlNavbar);
            this.Name = "StockerHome";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StockerHome_FormClosing);
            this.pnlNavbar.ResumeLayout(false);
            this.pnlNavbar.PerformLayout();
            this.pnlDashboard.ResumeLayout(false);
            this.pnlDashboard.PerformLayout();
            this.pnlRestocks.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlNavbar;
        private System.Windows.Forms.Panel pnlRestocks;
        private System.Windows.Forms.Button btnSendRequest;
        private System.Windows.Forms.ListBox lbRestocks;
        private System.Windows.Forms.Panel pnlDashboard;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lbItemsInShop;
        private System.Windows.Forms.Label lblRestocks;
        private System.Windows.Forms.Label lblDashboard;
        private System.Windows.Forms.Label lblTitle;
    }
}