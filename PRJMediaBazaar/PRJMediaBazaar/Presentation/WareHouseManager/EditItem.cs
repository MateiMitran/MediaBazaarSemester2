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
        public EditItem(WRHSHome wh,Item x)
        {
            InitializeComponent();
            this.wh = wh;
            this.x = x;
        }
        private void EditItem_Load(object sender, EventArgs e)
        {
            

        }

        private void btnUpdateItem_Click(object sender, EventArgs e)
        {

        }
    }
}
