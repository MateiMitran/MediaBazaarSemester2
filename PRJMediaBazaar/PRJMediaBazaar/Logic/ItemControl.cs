using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRJMediaBazaar.Data;
using MySql.Data.MySqlClient;

namespace PRJMediaBazaar.Logic
{
    class ItemControl
    {
        private List<Item> items;
        private ItemDAL itemDAL;
        public ItemControl()
        {
            items = new List<Item>();
            itemDAL = new ItemDAL();
            LoadItems();

        }
        public void LoadItems()
        {
           this.items = itemDAL.SelectAllItems();
        }
        public void AddAnItem(String name, String category, String subcategory, String price, int quantity)
        {
            itemDAL.AddItem(name, category, subcategory, price, quantity);
            int id = itemDAL.GetIDByName(name);
            items.Add(new Item(id, name, category, subcategory, Convert.ToDouble(price), quantity));
        }
        public bool DeleteAnItem(int id)
        {
            if (itemDAL.DeleteItem(id)==true)
            {
                for (int i=0;i<items.Count;i++)
                {
                    if (items[i].ID == id)
                    {
                        items.Remove(items[i]);
                        break;
                    }
                }
                return true;
            }
            return false;
        }
        public bool UpdateAnItem(int id, String name, String category, String subcategory, String price, int quantity)
        {
            if (itemDAL.UpdateItem(id, name, category, subcategory, price, quantity)==true)
            {
                for (int i = 0; i < items.Count; i++)
                {
                    if (items[i].ID == id)
                    {
                        items[i].Name = name;
                        items[i].Category = category;
                        items[i].Subcategory = subcategory;
                        items[i].Price = Convert.ToDouble(price);
                        items[i].Quantity = quantity;
                        break;
                    }
                }
                return true;
            }
            return false;
        }
        public List<Item> GetItems()
        {
            return this.items;
        }
        public Item[] Items { get { return this.items.ToArray(); } }

        public Item GetItemByIdAndName(String idAndName)
        {
            for (int i=0;i<items.Count;i++)
            {
                if (items[i].ID + " : " + items[i].Name == idAndName)
                {
                    return items[i];
                }
            }
            return null;
        }

    }
}
