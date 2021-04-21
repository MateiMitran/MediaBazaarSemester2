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
           // this.items = itemDAL.SelectAll();
        }
        public bool AddAnItem(int id, String name, String category, String subcategory, int price, int quantity)
        {
            return true;
        }
        public bool DeleteAnItem(int id)
        {
            return true;
        }
        public bool UpdateAnItem(int id)
        {
            return true;
        }
        public List<Item> GetItems()
        {
            return this.items;
        }
        public Item[] Items { get { return this.items.ToArray(); } }

    }
}
