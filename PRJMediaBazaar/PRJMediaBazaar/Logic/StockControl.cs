using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJMediaBazaar.Logic
{
    class StockControl
    {
        private List<Restock> restockRequests;
        private List<Item> items;
        IItemControlDTO ItemControl;
        public StockControl()
        {
            restockRequests = new List<Restock>();
            items = new List<Item>();
        }
        public void LoadRestockRequests()
        {

        }
        public void MarkRequestAsFinished(int id)
        {

        }

       // public bool UpdateInStockQuantity()
     //   {

       // }
    }
}
