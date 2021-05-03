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
using System.IO;

namespace PRJMediaBazaar
{
     partial class WRHSHome : Form
    {
        private ItemControl itemControl;
        private LogIn login;
        private Item thisItem;

        private Item[] items;

        private List<Button> buttons;
        private List<Timer> timers;
        public WRHSHome(LogIn login)
        {
            InitializeComponent();
            this.lblItems.ForeColor = Color.Gray;
            this.login = login;
            itemControl = new ItemControl();
            buttons = new List<Button>();
            timers = new List<Timer>();
            LoadItemsLESGOO();
        }
        public void StatusFunction(String text, int x, int y, int width, int height, Color color)
        {
            Button newButton = new Button();
            newButton.Location = new Point(x, y);
            newButton.Width = width;
            newButton.Height = height;
            newButton.Enabled = false;
            newButton.BackColor = color;
            newButton.Text = text;
            this.Controls.Add(newButton);
            newButton.BringToFront();
            buttons.Add(newButton);
            Timer temp = new Timer();
            timers.Add(temp);
            temp.Start();
        }
        public void LoadItemsLESGOO()
        {
            items = itemControl.Items;
            for (int i=0;i<items.Length;i++)
            {
                this.cbItems.Items.Add(items[i].ID + " : " + items[i].Name);
            }
        }
        public static Bitmap ByteToImage(byte[] blob)
        {
            MemoryStream mStream = new MemoryStream();
            byte[] pData = blob;
            if (pData != null)
            {
                mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
                Bitmap bm = new Bitmap(mStream, false);
                mStream.Dispose();
                return bm;
            }
            else
                return null;
            
        }
        public void LoadItemInformationLESGOO()
        {
            byte[] image = thisItem.Image;
            this.lbItems.Items.Clear();
            this.lbItems.Items.Add("ID : " + thisItem.ID);
            this.lbItems.Items.Add("Name : " + thisItem.Name);
            this.lbItems.Items.Add("Category : " + thisItem.Category);
            this.lbItems.Items.Add("Brand : " + thisItem.Brand);
            this.lbItems.Items.Add("Model : " + thisItem.Model);
            this.lbItems.Items.Add("Description : " + thisItem.Description);
            this.lbItems.Items.Add("Price : " + thisItem.Price + "$");
            this.lbItems.Items.Add("Room in Webshop : " + thisItem.RoomInWebshop);
            this.lbItems.Items.Add("Room in Shop : " + thisItem.RoomInShop);
            this.lbItems.Items.Add("Room in Storage : " + thisItem.RoomInStorage);
            this.lbItems.Items.Add("Minimum Amount in Stock : " + thisItem.MinimumAmountInStock);
            this.lbItems.Items.Add("Amount in Webshop : " + thisItem.InWebshopAmount);
            this.lbItems.Items.Add("Amount in Shop : " + thisItem.InShopAmount);
            this.lbItems.Items.Add("Amount in Storage : " + thisItem.InStorageAmount);
            this.pbItem.Image = ByteToImage(image);
        }
        private void lblItems_Click(object sender, EventArgs e)
        {
            this.pnlItems.Visible = true;
            this.pnlStatistics.Visible = false;
            this.pnlRestock.Visible = false;
            this.pnlAccount.Visible = false;
            this.lblItems.ForeColor = Color.Gray;
            this.lblStatistics.ForeColor = Color.White;
            this.lblRestock.ForeColor = Color.White;
            this.lblAccount.ForeColor = Color.White;
        }

        private void lblStatistics_Click(object sender, EventArgs e)
        {
            this.pnlItems.Visible = false;
            this.pnlStatistics.Visible = true;
            this.pnlRestock.Visible = false;
            this.pnlAccount.Visible = false;
            this.lblItems.ForeColor = Color.White;
            this.lblStatistics.ForeColor = Color.Gray;
            this.lblRestock.ForeColor = Color.White;
            this.lblAccount.ForeColor = Color.White;
        }

        private void lblRestock_Click(object sender, EventArgs e)
        {
            this.pnlItems.Visible = false;
            this.pnlStatistics.Visible = false;
            this.pnlRestock.Visible = true;
            this.pnlAccount.Visible = false;
            this.lblItems.ForeColor = Color.White;
            this.lblStatistics.ForeColor = Color.White;
            this.lblRestock.ForeColor = Color.Gray;
            this.lblAccount.ForeColor = Color.White;
        }

        private void lblAccount_Click(object sender, EventArgs e)
        {
            this.pnlItems.Visible = false;
            this.pnlStatistics.Visible = false;
            this.pnlRestock.Visible = false;
            this.pnlAccount.Visible = true;
            this.lblItems.ForeColor = Color.White;
            this.lblStatistics.ForeColor = Color.White;
            this.lblRestock.ForeColor = Color.White;
            this.lblAccount.ForeColor = Color.Gray;
        }

        private void WRHSHome_Load(object sender, EventArgs e)
        {

        }

        private void WRHSHome_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            login.Close();
        }

        private void cbItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.cbItems.SelectedItem == null)
                {
                    StatusFunction("Please select an item!", -6, -1, 900, 28, Color.Red);
                    throw new EmptyComboBoxException();
                }
                thisItem = itemControl.GetItemByIdAndName(this.cbItems.SelectedItem.ToString());
                LoadItemInformationLESGOO();
            }
            catch (Exception ex)
            {
                StatusFunction("No item found!", -6, -1, 900, 28, Color.Red);
            }
        }

        private void godTimer_Tick(object sender, EventArgs e)
        {
            for (int i=0;i<buttons.Count;i++)
            {
                if (timers[i].Enabled==true)
                {
                    timers[i].Enabled = false;
                    buttons[i].Visible = false;
                }
            }
        }
        public ItemControl GetItemControl()
        {
            return this.itemControl;
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            AddItem add = new AddItem(itemControl);
            add.Show();
        }

        private void btnEditItem_Click(object sender, EventArgs e)
        {
            if (thisItem != null)
            {
                EditItem edit = new EditItem(this, thisItem, itemControl);
                edit.Show();
            }
            else
                StatusFunction("No item found!", -6, -1, 900, 28, Color.Red);
        }
    }
}
