using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJMediaBazaar.Logic
{
    class StockControl
    {
        private List<Restock> restocks;
        private List<Item> items;
        // private RestockDAL restockDAL;
        public StockControl()
        {
            restocks = new List<Restock>();
            items = new List<Item>();
        }
        public void LoadRestockRequests()
        {

        }
        public void MarkRequestAsFinished(int id)
        {

        }
    }
}
