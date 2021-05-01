﻿using System;
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
                String brand = reader[3].ToString();
                String model = reader[4].ToString();
                String description = reader[5].ToString();
                double price = Convert.ToDouble(reader[6]);
                int quantity = Convert.ToInt32(reader[7]);
                int roomInWebshop = Convert.ToInt32(reader[8]);
                int roomInShop = Convert.ToInt32(reader[9]);
                int roomInStorage = Convert.ToInt32(reader[10]);
                int minimumAmountInStock = Convert.ToInt32(reader[11]);
                int inWebshopAmount = Convert.ToInt32(reader[12]);
                int inShopAmount = Convert.ToInt32(reader[13]);
                int inStorageAmount = Convert.ToInt32(reader[14]);

                Item item = new Item(id, name, category, brand, model, description, price, quantity, roomInWebshop, roomInShop,
                                     roomInStorage, minimumAmountInStock, inWebshopAmount, inShopAmount, inStorageAmount);
                item.Image = GetItemImage(id);
                items.Add(item);
            }
            CloseConnection();
           
            return items;
        } 
        public bool AddItem(String name, String category, String brand, String model, String description
                    , String price, int quantity, int roomInWebshop, int roomInShop, int roomInStorage,
                    int minimumAmountInStock, int inWebshopAmount, int inShopAmount, int inStorageAmount, byte[] image)
        {
            String sql = "INSERT INTO items(name,category,brand,model,description,price,quantity,roomInWebshop,roomInStorage,minimumAmountInStock,inWebshopAmount,inShopAmount,inStorageAmount) " +
                        "VALUES(@name,@category,@brand,@model,@description,@price,@quantity,@roomInWebshop,@roomInStorage,@minimumAmountInStock,@inWebshopAmount,@inShopAmount,@inStorageAmount);";
            String[] parameters = new String[] { name, category, brand,model,description,price, quantity.ToString(), 
                                                roomInWebshop.ToString(),roomInShop.ToString(),roomInStorage.ToString(),
                                                minimumAmountInStock.ToString(),inWebshopAmount.ToString(),inShopAmount.ToString(),
                                                inStorageAmount.ToString()};
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
        public byte[] GetItemImage(int itemID)
        {
            String sql = "SELECT image FROM items_images WHERE item_id = @itemID;";
            String[] parameters = new String[] { itemID.ToString() };
            byte[] image = (byte[])executeScalar(sql, parameters);
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
        public bool UpdateItem(String name, String category, String brand, String model, String description
                    , String price, int quantity, int roomInWebshop, int roomInShop, int roomInStorage,
                    int minimumAmountInStock, int inWebshopAmount, int inShopAmount, int inStorageAmount)
        {
            String sql = "UPDATE items SET name = @name, category = @category, brand = @brand, model=@model, description = @description,price = @price, quantity = @quantity, " +
                         "roomInWebshop=@roomInWebshop, roomInShop = @roomInShop, roomInStorage = @roomInStorage, minimumAmountInStock = @minimumAmountInStock, " +
                         "inWebshopAmount = @inWebshopAmount, inShopAmout = @inShopAmount, inStorageAmount = @inStorageAmount WHERE id = @id;";
            String[] parameters = new String[] { name, category, brand,model,description,price, quantity.ToString(),
                                                roomInWebshop.ToString(),roomInShop.ToString(),roomInStorage.ToString(),
                                                minimumAmountInStock.ToString(),inWebshopAmount.ToString(),inShopAmount.ToString(),
                                                inStorageAmount.ToString() };
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
        public bool UpdateItemImage(int itemID, byte[] image)
        {
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(@"server=studmysql01.fhict.local;database=dbi460221;uid=dbi460221;password=lol;AllowUserVariables=true");
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
    }
}
