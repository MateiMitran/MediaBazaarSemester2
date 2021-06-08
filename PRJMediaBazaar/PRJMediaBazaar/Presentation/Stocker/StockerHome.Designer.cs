
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
            this.pnlDashboard = new System.Windows.Forms.Panel();
            this.btnSendRestocks = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnMoveItems = new MaterialSkin.Controls.MaterialRaisedButton();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.lbRestocks = new System.Windows.Forms.ListBox();
            this.lbSpacesInShop = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pnlNavbar.SuspendLayout();
            this.pnlDashboard.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlNavbar
            // 
            this.pnlNavbar.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pnlNavbar.Controls.Add(this.lblTitle);
            this.pnlNavbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlNavbar.Location = new System.Drawing.Point(0, 0);
            this.pnlNavbar.Name = "pnlNavbar";
            this.pnlNavbar.Size = new System.Drawing.Size(1308, 48);
            this.pnlNavbar.TabIndex = 8;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Black;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft YaHei", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblTitle.ForeColor = System.Drawing.SystemColors.Control;
            this.lblTitle.Location = new System.Drawing.Point(528, 9);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(206, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Media Bazaar";
            // 
            // pnlDashboard
            // 
            this.pnlDashboard.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlDashboard.Controls.Add(this.label7);
            this.pnlDashboard.Controls.Add(this.label5);
            this.pnlDashboard.Controls.Add(this.label6);
            this.pnlDashboard.Controls.Add(this.label3);
            this.pnlDashboard.Controls.Add(this.panel1);
            this.pnlDashboard.Controls.Add(this.btnSendRestocks);
            this.pnlDashboard.Controls.Add(this.lbRestocks);
            this.pnlDashboard.Controls.Add(this.materialLabel2);
            this.pnlDashboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDashboard.Location = new System.Drawing.Point(0, 0);
            this.pnlDashboard.Name = "pnlDashboard";
            this.pnlDashboard.Size = new System.Drawing.Size(1308, 643);
            this.pnlDashboard.TabIndex = 13;
            // 
            // btnSendRestocks
            // 
            this.btnSendRestocks.AutoSize = true;
            this.btnSendRestocks.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSendRestocks.Depth = 0;
            this.btnSendRestocks.Icon = null;
            this.btnSendRestocks.Location = new System.Drawing.Point(884, 501);
            this.btnSendRestocks.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSendRestocks.Name = "btnSendRestocks";
            this.btnSendRestocks.Primary = true;
            this.btnSendRestocks.Size = new System.Drawing.Size(223, 36);
            this.btnSendRestocks.TabIndex = 15;
            this.btnSendRestocks.Text = "Send Restock Request";
            this.btnSendRestocks.UseVisualStyleBackColor = true;
            this.btnSendRestocks.Click += new System.EventHandler(this.btnSendRestocks_Click);
            // 
            // btnMoveItems
            // 
            this.btnMoveItems.AutoSize = true;
            this.btnMoveItems.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnMoveItems.Depth = 0;
            this.btnMoveItems.Icon = null;
            this.btnMoveItems.Location = new System.Drawing.Point(237, 385);
            this.btnMoveItems.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnMoveItems.Name = "btnMoveItems";
            this.btnMoveItems.Primary = true;
            this.btnMoveItems.Size = new System.Drawing.Size(124, 36);
            this.btnMoveItems.TabIndex = 15;
            this.btnMoveItems.Text = "Move items";
            this.btnMoveItems.UseVisualStyleBackColor = true;
            this.btnMoveItems.Click += new System.EventHandler(this.btnMoveItems_Click);
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(803, 149);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(321, 24);
            this.materialLabel2.TabIndex = 14;
            this.materialLabel2.Text = "Send restock request for these items";
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(134, 93);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(305, 24);
            this.materialLabel1.TabIndex = 14;
            this.materialLabel1.Text = "Replenish those items for the shop";
            // 
            // lbRestocks
            // 
            this.lbRestocks.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRestocks.FormattingEnabled = true;
            this.lbRestocks.ItemHeight = 20;
            this.lbRestocks.Location = new System.Drawing.Point(684, 184);
            this.lbRestocks.Name = "lbRestocks";
            this.lbRestocks.Size = new System.Drawing.Size(582, 244);
            this.lbRestocks.TabIndex = 9;
            // 
            // lbSpacesInShop
            // 
            this.lbSpacesInShop.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSpacesInShop.FormattingEnabled = true;
            this.lbSpacesInShop.ItemHeight = 20;
            this.lbSpacesInShop.Location = new System.Drawing.Point(35, 135);
            this.lbSpacesInShop.Name = "lbSpacesInShop";
            this.lbSpacesInShop.Size = new System.Drawing.Size(548, 244);
            this.lbSpacesInShop.TabIndex = 9;
            this.lbSpacesInShop.SelectedIndexChanged += new System.EventHandler(this.lbSpacesInShop_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkOrange;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lbSpacesInShop);
            this.panel1.Controls.Add(this.materialLabel1);
            this.panel1.Controls.Add(this.btnMoveItems);
            this.panel1.Location = new System.Drawing.Point(3, 49);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(621, 591);
            this.panel1.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(686, 20);
            this.label1.TabIndex = 16;
            this.label1.Text = "*The items that appear here are either DEPLEATED or are CLOSE to depletion !";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(67, 428);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(487, 60);
            this.label2.TabIndex = 17;
            this.label2.Text = "*By clicking the button you are moving items from the\r\nwarehouse to the shelves, " +
    "thus influencing the ammount \r\ndisplayed in the shop !\r\n";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(647, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(550, 48);
            this.label3.TabIndex = 17;
            this.label3.Text = "*Items that appear here have been checked by the system\r\nand were deemed as resto" +
    "ckable !";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(435, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 32);
            this.label4.TabIndex = 18;
            this.label4.Text = "↓";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(1116, 142);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 32);
            this.label5.TabIndex = 19;
            this.label5.Text = "↓";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.HotPink;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(756, 441);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(469, 40);
            this.label6.TabIndex = 20;
            this.label6.Text = "BY CLICKING THE BUTTON YOU CONFIRM THE SENDING\r\nOF THE RESTOCK REQUEST TO THE MAN" +
    "AGER !";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(1107, 491);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 46);
            this.label7.TabIndex = 21;
            this.label7.Text = "↲";
            // 
            // StockerHome
            // 
            this.ClientSize = new System.Drawing.Size(1308, 643);
            this.Controls.Add(this.pnlNavbar);
            this.Controls.Add(this.pnlDashboard);
            this.Name = "StockerHome";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StockerHome_FormClosing);
            this.pnlNavbar.ResumeLayout(false);
            this.pnlNavbar.PerformLayout();
            this.pnlDashboard.ResumeLayout(false);
            this.pnlDashboard.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlNavbar;
        private System.Windows.Forms.Panel pnlDashboard;
        private System.Windows.Forms.ListBox lbSpacesInShop;
        private System.Windows.Forms.Label lblTitle;
        private MaterialSkin.Controls.MaterialRaisedButton btnSendRestocks;
        private MaterialSkin.Controls.MaterialRaisedButton btnMoveItems;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private System.Windows.Forms.ListBox lbRestocks;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}