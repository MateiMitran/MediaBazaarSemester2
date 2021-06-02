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
                String category = reader[1].ToString();
                String subcategory = reader[2].ToString();
                String brand = reader[3].ToString();
                String model = reader[4].ToString();
                String description = reader[5].ToString();
                double stock_price = double.Parse(reader[6].ToString(), System.Globalization.CultureInfo.InvariantCulture);
                double price = double.Parse(reader[7].ToString(), System.Globalization.CultureInfo.InvariantCulture);
                String restock_state = reader[8].ToString();
                int roomInShop = Convert.ToInt32(reader[9]);
                int roomInStorage = Convert.ToInt32(reader[10]);
                int minimumAmountInStock = Convert.ToInt32(reader[11]);
                int inShopAmount = Convert.ToInt32(reader[12]);
                int inStorageAmount = Convert.ToInt32(reader[13]);

                Item item = new Item(id, category, subcategory ,brand, model, description, stock_price, price, restock_state, roomInShop,
                                     roomInStorage, minimumAmountInStock, inShopAmount, inStorageAmount);
              //  item.Image = GetItemImage(id);
                items.Add(item);
            }
            CloseConnection();
           
            return items;
        } 
        public bool AddItem(String category,String subcategory ,String brand, String model, String description, String stock_price
                    , String price, String restock_state,int roomInShop, int roomInStorage,
                    int minimumAmountInStock, byte[] image)
        {
            String sql = 
                "INSERT INTO items(category,subcategory,brand,model,description,stock_price,price,restock_state" +
                    "roomInShop,roomInStorage,minimumAmountInStock,inShopAmount,inStorageAmount) " +
                "VALUES(@category,@subcategory,@brand,@model,@description,@stock_price,@price,@restock_state," +
                    "@roomInShop,@roomInStorage,@minimumAmountInStock,@inShopAmount,@inStorageAmount);";

            String[] parameters = new String[] {
                category,
                subcategory,
                brand,
                model,
                description,
                stock_price,
                price,
                restock_state,
                roomInShop.ToString(),
                roomInStorage.ToString(),
                minimumAmountInStock.ToString(),
                0.ToString(),
                0.ToString(),
                0.ToString()};

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
                //conn = new MySqlConnection("datasource = 127.0.0.1; port = 3306; username = root; password =; database = dbi460221;");
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
        public byte[] GetItemImage(int itemID)
        {
            String sql = "SELECT image FROM items_images WHERE item_id = @itemID;";
            String[] parameters = new String[] { itemID.ToString() };
            byte[] image = (byte[])executeScalar(sql, parameters);
            CloseConnection();
            return image;
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
        public bool UpdateItem(String category,String subcategory ,String brand, String model, String description, String stock_price
                    , String price, String restock_state,int roomInShop, int roomInStorage,
                    int minimumAmountInStock, byte[] image, int id)
        {
            String sql = "UPDATE items SET category = @category,subcategory = @subcategory ,brand = @brand, model=@model, description = @description, stock_price=@stock_price , price = @price, restock_state=@restock_state , " +
                         "roomInShop = @roomInShop, roomInStorage = @roomInStorage, minimumAmountInStock = @minimumAmountInStock " +
                         "WHERE id = @id;";
            String[] parameters = new String[] { category, subcategory ,brand,model,description,stock_price,price.ToString(),restock_state,
                                                roomInShop.ToString(),roomInStorage.ToString(),
                                                minimumAmountInStock.ToString(), id.ToString() };
            if (executeNonQuery(sql,parameters)!=null)
            {
                CloseConnection();
                UpdateItemImage(id, image);
                return true;
            }
            else
            {
                CloseConnection();
                return false;
            }
        }
        public bool UpdateItemImage(int itemID, byte[] image)
        {
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(@"server=studmysql01.fhict.local;database=dbi460221;uid=dbi460221;password=lol;AllowUserVariables=true");
                //conn = new MySqlConnection("datasource = 127.0.0.1; port = 3306; username = root; password =; database = dbi460221;");
                String sql = "UPDATE items_images SET image = @image WHERE item_id = @itemID";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@itemID", itemID);
                cmd.Parameters.Add("@image", MySqlDbType.Blob).Value = image;
                conn.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    conn.Close();
                    return true;
                }
                else
                {
                    conn.Close();
                    return false;
                }
            }
            catch(MySqlException ex)
            {
                return false;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
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

        public List<String> GetCategories()
        {
            string sql = null;
            MySqlDataReader dr = null;
            try
            {
                List<String> categories = new List<String>();
                 sql = "SELECT DISTINCT category FROM items;";
                 dr = executeReader(sql, null);
                while (dr.Read())
                {
                    categories.Add(dr[0].ToString());
                }
                return categories;
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();

                }
                CloseConnection();
            }
           
        }

        public List<String> GetSubcategoriesByCategory(String category)
        {
            string sql = null;
            MySqlDataReader dr = null;
            try
            {
                List<String> subcategories = new List<String>();
                sql = "SELECT DISTINCT subcategory FROM items  WHERE category = @category;";
                String[] parameters = new String[] { category };
                dr = executeReader(sql, parameters);
                while (dr.Read())
                {
                    subcategories.Add(dr[0].ToString());
                }
                return subcategories;
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();

                }
                CloseConnection();
            }

        }

        public List<String> GetBrandsBySubcategory(String subcategory)
        {
            string sql = null;
            MySqlDataReader dr = null;
            try
            {
                List<String> brands = new List<String>();
                 sql = "SELECT DISTINCT brand FROM items WHERE subcategory = @subcategory;";
                String[] parameters = new String[] { subcategory };
                 dr = executeReader(sql, parameters);
                while (dr.Read())
                {
                    brands.Add(dr[0].ToString());
                }
                return brands;
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();

                }
                CloseConnection();
            }


            
        }

        public List<String> GetModelsByBrand(String brand)
        {
            string sql = null;
            MySqlDataReader dr = null;
            try
            {
                List<String> models = new List<String>();
                 sql = "SELECT DISTINCT model FROM items WHERE brand = @brand;";
                String[] parameters = new String[] { brand };
                 dr = executeReader(sql, parameters);
                while (dr.Read())
                {
                    models.Add(dr[0].ToString());
                }

                return models;
            }

            finally
            {
                if (dr != null)
                {
                    dr.Close();

                }
                CloseConnection();
            }
   
        }
    }
}
