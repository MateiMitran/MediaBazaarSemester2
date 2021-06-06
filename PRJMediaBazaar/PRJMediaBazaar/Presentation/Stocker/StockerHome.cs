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
     partial class StockerHome : Form
    {
        public static event  PRJMediaBazaar.Presentation.EventHandlerVoid UpdateWarehouseInfo;
        public static event PRJMediaBazaar.Presentation.EventHandlerVoid UpdateCashierInfo;

        private Employee _stocker;
        private ItemControl _itemControl;
        LogIn _login;
        public StockerHome(LogIn login, Employee stocker, ItemControl itemControl)
        {
            InitializeComponent();
            _login = login;
            _stocker = stocker;
            _itemControl = itemControl;
          
            this.pnlDashboard.Visible = true;
            this.pnlDashboard.BringToFront();
            CashierHome.UpdateStockerInfo += UpdateAvailableForMovingListbox;
            UpdateAvailableForMovingListbox();
            UpdateRestockRequestListbox();
           
        }

        private void UpdateAvailableForMovingListbox()
        {
            this.lbSpacesInShop.Items.Clear();
            foreach (Item i in _itemControl.GetItemsForMovingToShop())
            {
                this.lbSpacesInShop.Items.Add(i.MovingInfo());
            }
        }

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
            if(this.lbSpacesInShop.Items.Count >= 2)
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
                MessageBox.Show("There must be at least 2 items in order to move them");
            }
           
        }


        private void btnSendRestocks_Click(object sender, EventArgs e)
        {
            if (this.lbRestocks.Items.Count > 3)
            {
                foreach (string info in this.lbRestocks.Items)
                {
                    Item item = _itemControl.GetItemByRestockInfo(info);
                    _itemControl.SendToManager(item);
                }
                UpdateRestockRequestListbox();
                UpdateAvailableForMovingListbox();
                UpdateWarehouseInfo?.Invoke();
            }
            else
            {
                MessageBox.Show("There must be at least 3 items in order to send the restock request");
            }
           
        }

        private void StockerHome_FormClosing(object sender, FormClosingEventArgs e)
        {
            _login.Close();
        }
      

    }
}
