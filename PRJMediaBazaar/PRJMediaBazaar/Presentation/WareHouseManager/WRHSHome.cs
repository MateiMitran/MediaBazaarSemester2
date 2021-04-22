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
        public void LoadItemInformationLESGOO()
        {
            this.lbItems.Items.Clear();
            this.lbItems.Items.Add("ID : " + thisItem.ID);
            this.lbItems.Items.Add("Name : " + thisItem.Name);
            this.lbItems.Items.Add("Category : " + thisItem.Category);
            this.lbItems.Items.Add("Subcategory : " + thisItem.Subcategory);
            this.lbItems.Items.Add("Price : " + thisItem.Price + "$");
            this.lbItems.Items.Add("Quantity : " + thisItem.Quantity);
            this.lbItems.Items.Add("Total Cost : " + thisItem.TotalPrice + "$");
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

        private void btnViewSpecs_Click(object sender, EventArgs e)
        {
            if (thisItem != null)
            {
                ItemSpecifications itemSpecifications = new ItemSpecifications(this,thisItem);
                itemSpecifications.Show();
            }
            else
                StatusFunction("No item found!", -6, -1, 900, 28, Color.Red);
        }
        public ItemControl GetItemControl()
        {
            return this.itemControl;
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            AddItem add = new AddItem();
            add.Show();
        }

        private void btnEditItem_Click(object sender, EventArgs e)
        {
            if (thisItem != null)
            {
                EditItem edit = new EditItem(this, thisItem);
                edit.Show();
            }
            else
                StatusFunction("No item found!", -6, -1, 900, 28, Color.Red);
        }
    }
}
