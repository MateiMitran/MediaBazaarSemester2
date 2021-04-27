
namespace PRJMediaBazaar
{
    partial class EditItem
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
            this.btnEditItem = new System.Windows.Forms.Button();
            this.btnImage2 = new System.Windows.Forms.Button();
            this.btnImage1 = new System.Windows.Forms.Button();
            this.tbQuantity = new System.Windows.Forms.NumericUpDown();
            this.cbSubcategory = new System.Windows.Forms.ComboBox();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbPrice = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbItemName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.tbQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEditItem
            // 
            this.btnEditItem.Location = new System.Drawing.Point(56, 301);
            this.btnEditItem.Name = "btnEditItem";
            this.btnEditItem.Size = new System.Drawing.Size(305, 31);
            this.btnEditItem.TabIndex = 29;
            this.btnEditItem.Text = "Confirm";
            this.btnEditItem.UseVisualStyleBackColor = true;
            this.btnEditItem.Click += new System.EventHandler(this.btnEditItem_Click);
            // 
            // btnImage2
            // 
            this.btnImage2.Location = new System.Drawing.Point(56, 243);
            this.btnImage2.Name = "btnImage2";
            this.btnImage2.Size = new System.Drawing.Size(198, 31);
            this.btnImage2.TabIndex = 28;
            this.btnImage2.Text = "Image2";
            this.btnImage2.UseVisualStyleBackColor = true;
            this.btnImage2.Click += new System.EventHandler(this.btnImage2_Click);
            // 
            // btnImage1
            // 
            this.btnImage1.Location = new System.Drawing.Point(56, 206);
            this.btnImage1.Name = "btnImage1";
            this.btnImage1.Size = new System.Drawing.Size(198, 31);
            this.btnImage1.TabIndex = 27;
            this.btnImage1.Text = "Image1";
            this.btnImage1.UseVisualStyleBackColor = true;
            this.btnImage1.Click += new System.EventHandler(this.btnImage1_Click);
            // 
            // tbQuantity
            // 
            this.tbQuantity.Location = new System.Drawing.Point(153, 165);
            this.tbQuantity.Name = "tbQuantity";
            this.tbQuantity.Size = new System.Drawing.Size(208, 22);
            this.tbQuantity.TabIndex = 26;
            // 
            // cbSubcategory
            // 
            this.cbSubcategory.FormattingEnabled = true;
            this.cbSubcategory.Location = new System.Drawing.Point(153, 96);
            this.cbSubcategory.Name = "cbSubcategory";
            this.cbSubcategory.Size = new System.Drawing.Size(208, 24);
            this.cbSubcategory.TabIndex = 25;
            // 
            // cbCategory
            // 
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Location = new System.Drawing.Point(153, 63);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(208, 24);
            this.cbCategory.TabIndex = 24;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(51, 161);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 25);
            this.label5.TabIndex = 23;
            this.label5.Text = "Quantity :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(80, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 25);
            this.label4.TabIndex = 22;
            this.label4.Text = "Price :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(13, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 25);
            this.label3.TabIndex = 21;
            this.label3.Text = "Subcategory :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(44, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 25);
            this.label2.TabIndex = 20;
            this.label2.Text = "Category :";
            // 
            // tbPrice
            // 
            this.tbPrice.Location = new System.Drawing.Point(153, 129);
            this.tbPrice.Name = "tbPrice";
            this.tbPrice.Size = new System.Drawing.Size(208, 22);
            this.tbPrice.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(67, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 25);
            this.label1.TabIndex = 18;
            this.label1.Text = "Name : ";
            // 
            // tbItemName
            // 
            this.tbItemName.Location = new System.Drawing.Point(153, 28);
            this.tbItemName.Name = "tbItemName";
            this.tbItemName.Size = new System.Drawing.Size(208, 22);
            this.tbItemName.TabIndex = 17;
            // 
            // EditItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 369);
            this.Controls.Add(this.btnEditItem);
            this.Controls.Add(this.btnImage2);
            this.Controls.Add(this.btnImage1);
            this.Controls.Add(this.tbQuantity);
            this.Controls.Add(this.cbSubcategory);
            this.Controls.Add(this.cbCategory);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbPrice);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbItemName);
            this.Name = "EditItem";
            this.Text = "EditItem";
            this.Load += new System.EventHandler(this.EditItem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEditItem;
        private System.Windows.Forms.Button btnImage2;
        private System.Windows.Forms.Button btnImage1;
        private System.Windows.Forms.NumericUpDown tbQuantity;
        private System.Windows.Forms.ComboBox cbSubcategory;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbPrice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbItemName;
    }
}