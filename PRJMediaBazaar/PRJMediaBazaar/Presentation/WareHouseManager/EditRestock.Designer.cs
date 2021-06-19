namespace PRJMediaBazaar.Presentation.WareHouseManager
{
    partial class EditRestock
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
            this.lblItemInfo = new MaterialSkin.Controls.MaterialLabel();
            this.tbOldAmount = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.btnChangeAmount = new MaterialSkin.Controls.MaterialRaisedButton();
            this.lbItemInfo = new System.Windows.Forms.ListBox();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.tbNewAmount = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.SuspendLayout();
            // 
            // lblItemInfo
            // 
            this.lblItemInfo.AutoSize = true;
            this.lblItemInfo.Depth = 0;
            this.lblItemInfo.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblItemInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblItemInfo.Location = new System.Drawing.Point(39, 48);
            this.lblItemInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblItemInfo.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblItemInfo.Name = "lblItemInfo";
            this.lblItemInfo.Size = new System.Drawing.Size(53, 24);
            this.lblItemInfo.TabIndex = 1;
            this.lblItemInfo.Text = "Item:";
            // 
            // tbOldAmount
            // 
            this.tbOldAmount.Depth = 0;
            this.tbOldAmount.Enabled = false;
            this.tbOldAmount.Hint = "";
            this.tbOldAmount.Location = new System.Drawing.Point(572, 89);
            this.tbOldAmount.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbOldAmount.MaxLength = 32767;
            this.tbOldAmount.MouseState = MaterialSkin.MouseState.HOVER;
            this.tbOldAmount.Name = "tbOldAmount";
            this.tbOldAmount.PasswordChar = '\0';
            this.tbOldAmount.SelectedText = "";
            this.tbOldAmount.SelectionLength = 0;
            this.tbOldAmount.SelectionStart = 0;
            this.tbOldAmount.Size = new System.Drawing.Size(140, 28);
            this.tbOldAmount.TabIndex = 2;
            this.tbOldAmount.TabStop = false;
            this.tbOldAmount.UseSystemPasswordChar = false;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(439, 94);
            this.materialLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(116, 24);
            this.materialLabel1.TabIndex = 1;
            this.materialLabel1.Text = "For restock: ";
            // 
            // btnChangeAmount
            // 
            this.btnChangeAmount.AutoSize = true;
            this.btnChangeAmount.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnChangeAmount.Depth = 0;
            this.btnChangeAmount.Icon = null;
            this.btnChangeAmount.Location = new System.Drawing.Point(435, 266);
            this.btnChangeAmount.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnChangeAmount.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnChangeAmount.Name = "btnChangeAmount";
            this.btnChangeAmount.Primary = true;
            this.btnChangeAmount.Size = new System.Drawing.Size(167, 36);
            this.btnChangeAmount.TabIndex = 3;
            this.btnChangeAmount.Text = "Change amount";
            this.btnChangeAmount.UseVisualStyleBackColor = true;
            this.btnChangeAmount.Click += new System.EventHandler(this.btnChangeAmount_Click);
            // 
            // lbItemInfo
            // 
            this.lbItemInfo.FormattingEnabled = true;
            this.lbItemInfo.ItemHeight = 16;
            this.lbItemInfo.Location = new System.Drawing.Point(24, 97);
            this.lbItemInfo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lbItemInfo.Name = "lbItemInfo";
            this.lbItemInfo.Size = new System.Drawing.Size(245, 180);
            this.lbItemInfo.TabIndex = 4;
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(431, 177);
            this.materialLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(127, 24);
            this.materialLabel2.TabIndex = 1;
            this.materialLabel2.Text = "New amount: ";
            // 
            // tbNewAmount
            // 
            this.tbNewAmount.Depth = 0;
            this.tbNewAmount.Hint = "";
            this.tbNewAmount.Location = new System.Drawing.Point(572, 171);
            this.tbNewAmount.Margin = new System.Windows.Forms.Padding(4);
            this.tbNewAmount.MaxLength = 32767;
            this.tbNewAmount.MouseState = MaterialSkin.MouseState.HOVER;
            this.tbNewAmount.Name = "tbNewAmount";
            this.tbNewAmount.PasswordChar = '\0';
            this.tbNewAmount.SelectedText = "";
            this.tbNewAmount.SelectionLength = 0;
            this.tbNewAmount.SelectionStart = 0;
            this.tbNewAmount.Size = new System.Drawing.Size(140, 28);
            this.tbNewAmount.TabIndex = 2;
            this.tbNewAmount.TabStop = false;
            this.tbNewAmount.UseSystemPasswordChar = false;
            // 
            // EditRestock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(765, 380);
            this.Controls.Add(this.lbItemInfo);
            this.Controls.Add(this.btnChangeAmount);
            this.Controls.Add(this.tbNewAmount);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.tbOldAmount);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.lblItemInfo);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "EditRestock";
            this.Text = "EditRestock";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MaterialSkin.Controls.MaterialLabel lblItemInfo;
        private MaterialSkin.Controls.MaterialSingleLineTextField tbOldAmount;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialRaisedButton btnChangeAmount;
        private System.Windows.Forms.ListBox lbItemInfo;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialSingleLineTextField tbNewAmount;
    }
}