﻿using System;
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
        private List<Item> scannedItems;
        private List<Item> allItems;
        private int ok = 1;

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
                ok = 1;
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
                                ok = 0;
                            }

                        }
                        if (ok==1)
                        {
                            this.thisItem.ScanedAmount = ammount;
                            this.scannedItems.Add(this.thisItem);
                            DisplayScannedItems();
                        }
                        else
                        {
                            this.thisItem.ScanedAmount += ammount;
                            DisplayScannedItems();
                        }
                    }
                    else
                        MessageBox.Show("Amount selected must be smaller than in shop amount!");
                }

                
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error!");
            }
            
        }

        private void DisplayScannedItems()
        {
            double price=0;
            this.lbScannedItems.Items.Clear();
            foreach (Item item in this.scannedItems)
            {
               this.lbScannedItems.Items.Add($"{item.ToString()} x{item.ScanedAmount}");
                price += item.ScanedAmount * item.Price;
            }
            this.lblTotalPrice.Text = "Total Price: " + price.ToString() + '$';
        }

        private void tbQuantity_ValueChanged(object sender, EventArgs e)
        {
   
        }
    }
}
