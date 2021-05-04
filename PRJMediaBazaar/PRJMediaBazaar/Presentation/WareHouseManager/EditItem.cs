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
        private ItemControl _itemControl;
        public EditItem(WRHSHome wh,Item x, ItemControl itemControl)
        {
            InitializeComponent();
            _itemControl = itemControl;
            this.wh = wh;
            this.x = x;
        }
        private void EditItem_Load(object sender, EventArgs e)
        {
            

        }

        private void btnUpdateItem_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> errors = new List<string>();
                Helper.ValidateInteger(tbRoomWebshop.Text, "RoomWebshop", errors);
                Helper.ValidateInteger(tbRoomShop.Text, "RoomShop", errors);
                Helper.ValidateInteger(tbRoomStorage.Text, "RoomStorage", errors);
                Helper.ValidateInteger(tbMinimumAmount.Text, "MinimumAmount", errors);
                Helper.ValidateString(tbName.Text, "ItemName", errors);
                Helper.ValidateString(tbCategory.Text, "Category", errors);
                Helper.ValidateString(tbBrand.Text, "Brand", errors);
                Helper.ValidateString(tbModel.Text, "Model", errors);
                Helper.ValidateString(tbDescription.Text, "Description", errors);
                Helper.ValidateDouble(tbPrice.Text, "Price", errors);

                if (errors.Any())
                {
                    throw new InputException(errors);
                }

                byte[] image = null;
                int id = x.ID;
                string itemName = tbName.Text;
                string category = tbCategory.Text;
                string brand = tbBrand.Text;
                string model = tbModel.Text;
                string description = tbDescription.Text;
                double price = Convert.ToDouble(tbPrice.Text);
                int roomWebshop = Convert.ToInt32(tbRoomWebshop.Text);
                int roomShop = Convert.ToInt32(tbRoomShop.Text);
                int roomStorage = Convert.ToInt32(tbRoomStorage.Text);
                int minAmount = Convert.ToInt32(tbMinimumAmount.Text);

                _itemControl.UpdateAnItem(id, itemName, category, brand, model, description, price,
                    roomWebshop, roomShop, roomStorage, minAmount, image);

            }
            catch (InputException ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
    }
}
