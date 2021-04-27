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
     partial class ItemSpecifications : Form
    {
        private WRHSHome whHome;
        private ItemControl itemControl;
        private Item thisItem;
        public ItemSpecifications(WRHSHome whHome, Item thisItem)
        {
            InitializeComponent();
            this.whHome = whHome;
            itemControl = whHome.GetItemControl();
            this.thisItem = thisItem;
        }

        private void ItemSpecifications_Load(object sender, EventArgs e)
        {
            List<Specification> temp = itemControl.GetSpecificationsWithItemId(thisItem.ID);
            for (int i=0;i<temp.Count;i++)
            {
                this.lbSpecifications.Items.Add(temp[i].Name + " " + temp[i].Title + " " + temp[i].Spec);
            }
        }
    }
}
