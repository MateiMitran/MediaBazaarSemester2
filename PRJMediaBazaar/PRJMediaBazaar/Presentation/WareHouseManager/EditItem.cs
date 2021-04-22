using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PRJMediaBazaar.Logic;
namespace PRJMediaBazaar
{
     partial class EditItem : Form
    {
        private WRHSHome wh;
        private Item x;
        private String image1Path = "";
        private String image2Path = "";
        public EditItem(WRHSHome wh,Item x)
        {
            InitializeComponent();
            this.wh = wh;
            this.x = x;
        }
        private void btnEditItem_Click(object sender, EventArgs e)
        {

        }

        private void EditItem_Load(object sender, EventArgs e)
        {
            this.tbItemName.Text = x.Name;
            this.cbCategory.Text = x.Category;
            this.cbSubcategory.Text = x.Subcategory;
            this.tbPrice.Text = x.Price.ToString();
            this.tbQuantity.Text = x.Quantity.ToString();

        }

        private void btnImage1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFile = new OpenFileDialog())
            {
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    this.image1Path = openFile.FileName;
                }
            }
            MessageBox.Show(image1Path);
        }

        private void btnImage2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFile = new OpenFileDialog())
            {
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    this.image2Path = openFile.FileName;
                }
            }
            MessageBox.Show(image2Path);
        }
    }
}
