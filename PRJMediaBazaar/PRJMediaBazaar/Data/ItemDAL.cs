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
        public List<Item> SelectAllItems()
        {
            List<Item> items = new List<Item>();
            MySqlDataReader reader = executeReader("SELECT * FROM items;", null);
            while (reader.Read())
            {
                int id = Convert.ToInt32(reader[0]);
                String name = reader[1].ToString();
                String category = reader[2].ToString();
                String subcategory = reader[3].ToString();
                double price = Convert.ToDouble(reader[4]);
                int quantity = Convert.ToInt32(reader[5]);
                Item item = new Item(id, name, category, subcategory, price, quantity);
                items.Add(item);
            }
            CloseConnection();
           
            return items;
        } 
        public List<Specification> LoadSpecs(int itemId) // load specs by id of product
        {
            List<Specification> specs = new List<Specification>();
            MySqlDataReader dr = executeReader("SELECT name,title,information FROM specifications WHERE itemID = @itemId;", null);
            while (dr.Read())
            {
                String name = dr[0].ToString();
                Specification temp = new Specification(name);
                temp.AddSpecification(dr[1].ToString(), dr[2].ToString());
                specs.Add(temp);
            }
            CloseConnection();
            return specs;
            
        }
        public bool AddItem(String name, String category, String subcategory, String price, int quantity)
        {
            String sql = "INSERT INTO items(name,category,subcategory,price,quantity) " +
                        "VALUES(@id,@name,@category,@subcategory,@price,@quantity);";
            String[] parameters = new String[] { name, category, subcategory, price, quantity.ToString() };
            if (executeNonQuery(sql,parameters)!=null)
            {
                CloseConnection();
                return true;
            }
            else
            {
                CloseConnection();
                return false;
            }
        }
        public bool DeleteItem(int id)
        {
            String sql = "DELETE FROM items WHERE id = @id;";
            String[] parameters = new String[] { id.ToString() };
            if (executeNonQuery(sql,parameters)!=null)
            {
                CloseConnection();
                return true;
            }
            else
            {
                CloseConnection();
                return false;
            }
        }
        public bool UpdateItem(int id,String name, String category, String subcategory, String price, int quantity)
        {
            String sql = "UPDATE items SET name = @name, category = @category, subcategory = @subcategory, price = @price, quantity = @quantity WHERE id = @id;";
            String[] parameters = new String[] { id.ToString(), name, category, subcategory, price, quantity.ToString() };
            if (executeNonQuery(sql,parameters)!=null)
            {
                CloseConnection();
                return true;
            }
            else
            {
                CloseConnection();
                return false;
            }
        }
        public int GetIDByName(String name)
        {
            String sql = "SELECT id FROM items WHERE name = @name;";
            String[] parameters = new String[] { name };
            int id = Convert.ToInt32(executeScalar(sql, parameters));
            CloseConnection();
            return id;
        }
    }
}
