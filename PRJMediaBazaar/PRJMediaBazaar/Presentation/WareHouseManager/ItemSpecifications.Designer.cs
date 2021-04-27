
namespace PRJMediaBazaar
{
    partial class ItemSpecifications
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
            this.lbSpecifications = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lbSpecifications
            // 
            this.lbSpecifications.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbSpecifications.FormattingEnabled = true;
            this.lbSpecifications.ItemHeight = 25;
            this.lbSpecifications.Location = new System.Drawing.Point(4, 4);
            this.lbSpecifications.Name = "lbSpecifications";
            this.lbSpecifications.Size = new System.Drawing.Size(793, 429);
            this.lbSpecifications.TabIndex = 0;
            // 
            // ItemSpecifications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbSpecifications);
            this.Name = "ItemSpecifications";
            this.Text = "ItemSpecifications";
            this.Load += new System.EventHandler(this.ItemSpecifications_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbSpecifications;
    }
}