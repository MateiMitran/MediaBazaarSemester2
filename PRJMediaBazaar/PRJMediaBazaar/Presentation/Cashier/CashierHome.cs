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
using System.Threading;

namespace PRJMediaBazaar
{
     partial class CashierHome : Form
    {
        private ItemControl itemControl;
        private LogIn login;
        private Item thisItem;
        private Item[] items;
        private Employee cashier;
        List<Item> scannedItems;
        List<Item> allItems;

        private List<Button> buttons;
        private List<System.Windows.Forms.Timer> timers;

        private int ammount;

        public CashierHome(LogIn login, Employee salesman)
        {
            InitializeComponent();
            this.login = login;

            itemControl = new ItemControl();
            buttons = new List<Button>();
            timers = new List<System.Windows.Forms.Timer>();
            allItems = itemControl.GetItems();
            scannedItems = new List<Item>();
            cashier = salesman;
            ammount = 0;

            LoadItemsLESGOO();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            login.Show();
        }

        private void StockerHome_FormClosing(object sender, FormClosingEventArgs e)
        {
            login.Close();
        }

        public void LoadItemsLESGOO()
        {
            List<String> categories = this.itemControl.GetCategories();
            this.cbCategory.Items.AddRange(categories.ToArray());
        }

        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lbAllItems.Items.Clear();
            this.cbSubcategory.SelectedItem = null;
            
            foreach (Item temp in allItems)
            {
                if (temp.Category == this.cbCategory.SelectedItem.ToString())
                {
                    this.lbAllItems.Items.Add(temp.ToString());
                }
            }
            this.cbSubcategory.Enabled = true;
            List<String> subcategories = this.itemControl.GetSubcategories(this.cbCategory.SelectedItem.ToString());
            this.cbSubcategory.Items.AddRange(subcategories.ToArray());
        }

        private void cbBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbSubcategory.SelectedItem != null)
            {
                this.lbAllItems.Items.Clear();
                foreach (Item temp in allItems)
                {

                    if (temp.Subcategory == this.cbSubcategory.SelectedItem.ToString())
                    {
                        this.lbAllItems.Items.Add(temp.ToString());

                    }
                }
            }
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
           
            try
            {
                //this.thisItem = (Item)this.lbAllItems.SelectedItem;
                string id1 = new string(this.lbAllItems.SelectedItem.ToString().SkipWhile(c => !char.IsDigit(c))
                       .TakeWhile(c => char.IsDigit(c))
                       .ToArray());
                int id = Convert.ToInt32(id1);
                thisItem = this.itemControl.GetItem(id);
                

                this.ammount = Convert.ToInt32(this.tbQuantity.Value);
                if (this.ammount == 0)
                {
                    MessageBox.Show("Select amount biger than 0!");
                }
                else
                {
                    if (this.thisItem.InShopAmount >= this.ammount)
                    {

                        foreach (Item itemx in this.scannedItems)
                        {
                            if (thisItem.ID == itemx.ID)
                            {
                                MessageBox.Show("Item already scanned!");
                            }

                        }


                        this.thisItem.ScanedAmount = ammount;
                        this.scannedItems.Add(this.thisItem);
                        DisplayScannedItems(this.thisItem);

                    }
                }

                
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error!");
            }
            
        }

        private void DisplayScannedItems(Item x)
        {
            foreach (Item item in this.scannedItems)
            {
                if (item.ID == x.ID)
                {
                    this.lbScannedItems.Items.Add($"{x.ToString()} x{x.ScanedAmount}");
                }
            }
        }

        private void tbQuantity_ValueChanged(object sender, EventArgs e)
        {
   
        }
    }
}
