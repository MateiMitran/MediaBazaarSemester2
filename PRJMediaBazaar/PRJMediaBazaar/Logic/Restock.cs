using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJMediaBazaar.Logic
{
    class Restock
    {
        public static List<Item> itemsToRestock;

        public Restock(List<Item> items)
        {
            itemsToRestock = new List<Item>();
            if(items != null)
            {
                itemsToRestock = items;
            }
        }

        public void AddItemForRestock(Item item)
        {
            itemsToRestock.Add(item);
        }

        public Item[] GetItemsForRestock()
        {
            return itemsToRestock.ToArray();
        }

        public double GetTotalCost()
        {
            double value = 0;

            foreach(Item i in itemsToRestock)
            {
                value += i.AmountToRestock * i.Stock_Price;
            }
            return value;
        }
    }
}
