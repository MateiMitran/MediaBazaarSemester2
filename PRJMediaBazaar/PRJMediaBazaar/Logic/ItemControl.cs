using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRJMediaBazaar.Data;
using MySql.Data.MySqlClient;


namespace PRJMediaBazaar.Logic
{
    class ItemControl //: IItemControlDTO
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
        public void AddAnItem(String name, String category, String subcategory ,String brand, String model, String description
                    , double price, int roomInShop, int roomInStorage,
                    int minimumAmountInStock, byte[] image)
        {
            itemDAL.AddItem(name, category,subcategory ,brand,model,description, price.ToString(),
                roomInShop,roomInStorage,minimumAmountInStock,image);
            int id = itemDAL.LastItemId();
            Item temp = new Item(id, name, category,subcategory ,brand, model, description, price,
                roomInShop, roomInStorage, minimumAmountInStock,0, 0);
            temp.Image = image;
            items.Add(temp);
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
        public bool UpdateAnItem(int id, String name, String category, String subcategory ,String brand, String model, String description
                    , double price, int roomInShop, int roomInStorage,
                    int minimumAmountInStock, byte[] image)
        {
            if (itemDAL.UpdateItem(name, category, subcategory, brand, model, description, price.ToString(), 
                roomInShop, roomInStorage, minimumAmountInStock,image, id) ==true)
            {
                for (int i = 0; i < items.Count; i++)
                {
                    if (items[i].ID == id)
                    {
                        items[i].Name = name;
                        items[i].Category = category;
                        items[i].Subcategory = subcategory;
                        items[i].Brand = brand;
                        items[i].Model = model;
                        items[i].Description = description;
                        items[i].Price = price;
                        items[i].RoomInShop = roomInShop;
                        items[i].RoomInStorage = roomInStorage;
                        items[i].MinimumAmountInStock = minimumAmountInStock;

                        return true;
                    }
                }
                return false;
                
            }
            return false;
        }
        public bool UpdateItemImage(int itemID, byte[] image)
        {
            if (itemDAL.UpdateItemImage(itemID, image) == true)
            {
                for (int i = 0; i < items.Count; i++)
                {
                    if (items[i].ID == itemID)
                    {
                        items[i].Image = image;
                        return true;
                    }
                }
                return false;
            }
            else
                return false;
        }
        public List<String> GetCategories()
        {
            return itemDAL.GetCategories();
        }

        public List<Item> GetItems()
        {
            return this.items;
        }
        public Item[] Items { get { return this.items.ToArray(); } }

        public byte[] GetItemImage(int itemID)
        {
            return this.itemDAL.GetItemImage(itemID);
        }
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
        public List<String> GetBrands(String subcategory)
        {
            return itemDAL.GetBrandsBySubcategory(subcategory);
        }
        public List<String> GetModels(String brand)
        {
            return itemDAL.GetModelsByBrand(brand);
        }

        public List<String> GetSubcategories(String category)
        {
            return itemDAL.GetSubcategoriesByCategory(category);
        }

    }
}
