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
        public bool AddItem(String name, String category, String subcategory, String price, int quantity, byte[] image)
        {
            String sql = "INSERT INTO items(name,category,subcategory,price,quantity) " +
                        "VALUES(@name,@category,@subcategory,@price,@quantity);";
            String[] parameters = new String[] { name, category, subcategory, price, quantity.ToString() };
            if (executeNonQuery(sql,parameters)!=null)
            {
                CloseConnection();
                AddItemImage(image);

                return true;
            }
            else
            {
                CloseConnection();
                return false;
            }
        }

        private void AddItemImage(byte[] image)
        {
            int id = LastItemId();
            MySqlConnection conn = null;

            try
            {
                conn = new MySqlConnection(@"server=studmysql01.fhict.local;database=dbi460221;uid=dbi460221;password=lol;AllowUserVariables=true");
                String sql = "INSERT INTO items_images(item_id,image) " +
                        "VALUES(@id,@image);";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.Add("@image", MySqlDbType.Blob).Value = image;
                conn.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    conn.Close();
                }

            }
            catch (MySqlException ex)
            {
             
            }

            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }

        }

        public int LastItemId()
        {
            string sql = "SELECT MAX(id) FROM items";
            int id =Convert.ToInt32(executeScalar(sql, null));
            CloseConnection();
            return id;
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
