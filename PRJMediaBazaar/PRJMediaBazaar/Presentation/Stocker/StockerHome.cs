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

namespace PRJMediaBazaar
{
     partial class StockerHome : Form
    {
        public static event  PRJMediaBazaar.Presentation.EventHandlerVoid UpdateWarehouseInfo;
        public static event PRJMediaBazaar.Presentation.EventHandlerVoid UpdateCashierInfo;
        public static event PRJMediaBazaar.Presentation.EventHandlerVoid ChangeColorLabel;

        private Employee _stocker;
        private ItemControl _itemControl;
        private Item selectedItem;
        LogIn _login;
        private List<System.Windows.Forms.Timer> timers;

        private List<Button> buttons;
        public StockerHome(LogIn login, Employee stocker, ItemControl itemControl)
        {
            InitializeComponent();
            this.lblRefill.ForeColor = Color.Gray;

            this.lbQuantity.Visible = false;
            this.tbActuallyArrived.Visible = false;
            this.btnConfirm.Visible = false;

            _login = login;
            _stocker = stocker;
            _itemControl = itemControl;
            buttons = new List<Button>();
            timers = new List<System.Windows.Forms.Timer>();

           
            this.pnlDashboard.Visible = true;
            this.pnlDashboard.BringToFront();
            CashierHome.UpdateStockerInfo += UpdateAvailableForMovingListbox; // event coming from cashier
            WRHSHome.SendRestockForCheck += LoadRestockApprovals; // event coming from WHM
           

            UpdateAvailableForMovingListbox();
            UpdateRestockRequestListbox();
            LoadAllExpectedItems();

            LoadAllWaitingItems();

            LoadRestockApprovals();

            this.pnlNavbar.BringToFront();

            this.tbActuallyArrived.Enabled = false;
            this.btnConfirm.Enabled = false;
           
           
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
            System.Windows.Forms.Timer temp = new System.Windows.Forms.Timer();
            timers.Add(temp);
            temp.Start();
        }


        private void UpdateAvailableForMovingListbox()
        {
            this.lbSpacesInShop.Items.Clear();
            foreach (Item i in _itemControl.GetItemsForMovingToShop())
            {
                this.lbSpacesInShop.Items.Add(i.MovingInfo());
            }
        }

        public void LoadRestockApprovals(Restock restock) 
        {
            //load all the 
            this.lbExpRestocks.Items.Clear();
            foreach (Item i in restock.GetItemsForRestock())
            {
                this.lbExpRestocks.Items.Add(i.ArrivedInfo());
                i.IsInChecking = true;
            }
            //MessageBox.Show("Triggered");

        }

        public void LoadAllExpectedItems() // just created
        {
            this.lbExpRestocks.Items.Clear();
            foreach (Item i in _itemControl.GetItems())
            {
                if (i.IsInChecking == true)
                {
                    this.lbExpRestocks.Items.Add(i.ArrivedInfo());
                }
            }
        }

        public void LoadAllWaitingItems()
        {
            this.lbWL.Items.Clear();
            foreach (Item i in _itemControl.GetItems())
            {
                if (i.IsInWaiting == true)
                {
                    this.lbWL.Items.Add(i.WaitingInfo());
                }
            }
        }

        public void LoadRestockApprovals()
        {
            //load all the 
            foreach (Item i in _itemControl.GetItemsForMovingToShop() /*restock.GetItemsForRestock()*/)
            {
                this.lbExpRestocks.Items.Add(i.MovingInfo());
            }

        }

        //public void UpdateRestockApprovals()
        //{
        //    this.lbWL.Items.Clear();
        //    foreach (Item i in _itemControl.GetItemsByState("stocker"))
        //    {
        //        this.lbRestocks.Items.Add(i.RestockInfo());
        //    }
        //}



        private void UpdateRestockRequestListbox()
        {
            this.lbRestocks.Items.Clear();
            foreach (Item i in _itemControl.GetItemsByState("stocker"))
            {
                this.lbRestocks.Items.Add(i.RestockInfo());
            }
        }


        private void btnMoveItems_Click(object sender, EventArgs e)
        {
            if(this.lbSpacesInShop.Items.Count > 0)
            {
                foreach (string info in this.lbSpacesInShop.Items)
                {
                    Item item = _itemControl.GetItemByMovingInfo(info);
                    _itemControl.MoveItemToShop(item);
                }
                UpdateRestockRequestListbox();
                UpdateAvailableForMovingListbox();
                UpdateCashierInfo?.Invoke();
            }
            else
            {
                MessageBox.Show("No items to move");
            }
           
        }


        private void btnSendRestocks_Click(object sender, EventArgs e)
        {
            if (this.lbRestocks.Items.Count > 0)
            {
                foreach (string info in this.lbRestocks.Items)
                {
                    Item item = _itemControl.GetItemByRestockInfo(info);
                    _itemControl.SendToManager(item);
                }
                UpdateRestockRequestListbox();
                UpdateAvailableForMovingListbox();
                UpdateWarehouseInfo?.Invoke();
                ChangeColorLabel?.Invoke();
            }
            else
            {
                MessageBox.Show("No items to send a restock");
            }
           
        }

        private void StockerHome_FormClosing(object sender, FormClosingEventArgs e)
        {
            _login.Close();
        }

        private void lbSpacesInShop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(this.lbSpacesInShop.SelectedIndex >= 0)
            {
                Item item = _itemControl.GetItemByRestockInfo(lbSpacesInShop.SelectedItem.ToString());
            }
        }

        private void lblLogOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            _login.Show();
        }

        private void pnlDashboard_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblRR_Click(object sender, EventArgs e)
        {

            this.pnlExpectedRestocks.Visible = false;
            this.pnlDashboard.Visible = true;
            this.pnlWaitingList.Visible = false;
            this.pnRR.Visible = false;

            this.lblWaitingList.ForeColor = Color.White;
            this.lblRefill.ForeColor = Color.White;
            this.lblRR.ForeColor = Color.Gray;
            this.lblexpectedRestocks.ForeColor = Color.White;


            this.pnlDashboard.BringToFront();
            this.pnlNavbar.BringToFront();
        }

        private void lblRefill_Click(object sender, EventArgs e)
        {
            this.pnlExpectedRestocks.Visible = false;
            this.pnlDashboard.Visible = false;
            this.pnlWaitingList.Visible = false;
            this.pnRR.Visible = true;

            this.lblWaitingList.ForeColor = Color.White;
            this.lblRefill.ForeColor = Color.Gray;
            this.lblRR.ForeColor = Color.White;
            this.lblexpectedRestocks.ForeColor = Color.White;


            this.pnRR.BringToFront();
            this.pnlNavbar.BringToFront();

        }

        private void lblWaitingList_Click(object sender, EventArgs e)
        {
            

            this.pnlWaitingList.Visible = true;
            this.pnlExpectedRestocks.Visible = false;
            this.pnlDashboard.Visible = false;
            this.pnRR.Visible = false;

            this.lblWaitingList.ForeColor = Color.Gray;
            this.lblRefill.ForeColor = Color.White;
            this.lblRR.ForeColor = Color.White;
            this.lblexpectedRestocks.ForeColor = Color.White;

            this.pnlWaitingList.BringToFront();
            this.pnlNavbar.BringToFront();

        }

        private void materialRaisedButton1_Click(object sender, EventArgs e) // Refill waiting item and move to shop
        {
            if (this.lbWL.SelectedItem != null)
            {
                Item i = _itemControl.GetItemByWaitingInfo(this.lbWL.SelectedItem.ToString());

                //...........................

                int newInStorage = i.InStorageAmount + i.MissingAmmount;
                i.InStorageAmount = newInStorage;
                i.MissingAmmount = 0;
                i.Missing = false;
                i.IsInWaiting = false;


                _itemControl.UpdateItemStorageQuantity(i.ID, newInStorage);

                

                UpdateAvailableForMovingListbox();
                UpdateRestockRequestListbox();
                LoadAllWaitingItems();

                StatusFunction("Quantity added to said item!", -6, -1, 900, 28, Color.Green);



                //...........................
                UpdateCashierInfo?.Invoke();
            }
            else
            {
                MessageBox.Show("No item selected");
            }



            // if(this.lbSpacesInShop.Items.Count > 0)
            //{
            //    foreach (string info in this.lbSpacesInShop.Items)
            //    {
            //        Item item = _itemControl.GetItemByMovingInfo(info);
            //        _itemControl.MoveItemToShop(item);
            //    }
            //    UpdateRestockRequestListbox();
            //    UpdateAvailableForMovingListbox();
            //    UpdateCashierInfo?.Invoke();
            //}
            //else
            //{
            //    MessageBox.Show("No items to move");
            //}
        }

        private void btnSendRestocks_Click_1(object sender, EventArgs e)
        {
            if (this.lbRestocks.Items.Count > 0)
            {
                foreach (string info in this.lbRestocks.Items)
                {
                    Item item = _itemControl.GetItemByRestockInfo(info);
                    _itemControl.SendToManager(item);
                }
                UpdateRestockRequestListbox();
                UpdateAvailableForMovingListbox();
                UpdateWarehouseInfo?.Invoke();
                ChangeColorLabel?.Invoke();
            }
            else
            {
                MessageBox.Show("No items to send a restock");
            }
        }

        private void btnQArrived_Click(object sender, EventArgs e)
        {
            if (this.lbExpRestocks.SelectedItem != null)
            {
                this.lbQuantity.Visible = false;
                this.tbActuallyArrived.Visible = false;
                this.btnConfirm.Visible = false;

                Item i = _itemControl.GetItemByExpectedInfo(this.lbExpRestocks.SelectedItem.ToString());

                int newInStorage = i.InStorageAmount + i.AmountToRestock;
                i.Restock_State = "stable";
                i.InStorageAmount = newInStorage;
                i.AmountToRestock = 0;
                _itemControl.UpdateItemStorageQuantity(i.ID, newInStorage);
                i.IsInChecking = false;
                //i.IsInWaiting = true;

                UpdateAvailableForMovingListbox();
                UpdateRestockRequestListbox();
                LoadAllExpectedItems();
                //LoadAllWaitingItems();// !!!!!!!!!!

                StatusFunction("Item restocked!", -6, -1, 900, 28, Color.Green);
            }

            else
            {
                StatusFunction("No Selected Item!", -6, -1, 900, 28, Color.Red);
            }
        }

        private void btnQNotAll_Click(object sender, EventArgs e)
        {
            if (this.lbExpRestocks.SelectedItem != null)
            {
                this.lbQuantity.Visible = true;
                this.tbActuallyArrived.Visible = true;
                this.btnConfirm.Visible = true;

                this.tbActuallyArrived.Enabled = true;
                this.btnConfirm.Enabled = true;

            }

            //if (this.lbExpRestocks.SelectedItem != null)
            //{
            //    Item i = _itemControl.GetItemByExpectedRestockInfo(this.lbExpRestocks.SelectedItem.ToString());
            //    PRJMediaBazaar.Presentation.WareHouseManager.form = new Presentation.WareHouseManager.EditRestock(item, this);
            //    form.Show();
            //}

            else
            {
                MessageBox.Show("Please selet an item");
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (this.lbExpRestocks.SelectedItem != null)
            {
                Item i = _itemControl.GetItemByExpectedInfo(this.lbExpRestocks.SelectedItem.ToString());

                int expected = i.AmountToRestock;
                int arrivedNumber = Convert.ToInt32(this.tbActuallyArrived.Text);
                
                //if (arrivedNumber >= expected)
                //{
                    int arrived = arrivedNumber;
                    int missing = expected - arrived;
                    int newInStorage = i.InStorageAmount + arrived;
                    i.InStorageAmount = newInStorage;
                    i.MissingAmmount = missing;
                    i.Missing = true;
                    i.IsInChecking = false;
                    i.IsInWaiting = true;


                    _itemControl.UpdateItemStorageQuantity(i.ID, newInStorage);

                    this.tbActuallyArrived.Enabled = false;
                    this.btnConfirm.Enabled = false;
                    

                    UpdateAvailableForMovingListbox();
                    UpdateRestockRequestListbox();
                    LoadAllExpectedItems();
                    LoadAllWaitingItems();// !!!!!!!!!!
                                          //MoveItemToWaitingList(i);

                    StatusFunction("Item sent to Waiting List!", -6, -1, 900, 28, Color.Green);
               // }
                //else
                //{
                    //MessageBox.Show("Arrived quantity cannot be bigger than expected!");
                //}

                this.tbActuallyArrived.Clear();

            }
            else
            {
                StatusFunction("Error occured!", -6, -1, 900, 28, Color.Green);
            }
            
        }

        private void MoveItemToWaitingList(Item i)
        {
            this.lbWL.Items.Add(i.WaitingInfo());
        }

        private void godTimer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < buttons.Count; i++)
            {
                if (timers[i].Enabled == true)
                {
                    timers[i].Enabled = false;
                    buttons[i].Visible = false;
                }
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void lbExpRestocks_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void lblexpectedRestocks_Click(object sender, EventArgs e)
        {
            this.pnlExpectedRestocks.Visible = true;
            this.pnlDashboard.Visible = false;
            this.pnlWaitingList.Visible = false;
            this.pnRR.Visible = false;

            this.lblWaitingList.ForeColor = Color.White;
            this.lblRefill.ForeColor = Color.White;
            this.lblRR.ForeColor = Color.White;
            this.lblexpectedRestocks.ForeColor = Color.Gray;

            this.pnlExpectedRestocks.BringToFront();
            this.pnlNavbar.BringToFront();
        }
    }
}
