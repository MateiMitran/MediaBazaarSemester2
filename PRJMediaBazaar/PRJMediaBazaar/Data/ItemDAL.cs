using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using PRJMediaBazaar.Logic;

namespace PRJMediaBazaar.Data
{
    class ItemDAL : BaseDAL
    {
        public /*List<Item>*/ void SelectAll()
        {

        } 
        public bool AddItem(int id, String name, String category, String subcategory, int price, int quantity)
        {
            CloseConnection();
            return true;
        }
        public bool DeleteItem(int id)
        {
            CloseConnection();
            return true;
        }
        public bool UpdateItem(int id)
        {
            CloseConnection();
            return true;
        }
    }
}
