using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJMediaBazaar.Logic
{
    public class Item
    {
        //quantity is 0 when u create item
        public Item(int id, String name, String category, String brand,String model, String description
                    , double price,int roomInWebshop, int roomInShop, int roomInStorage,
                    int minimumAmountInStock, int inWebshopAmount, int inShopAmount, int inStorageAmount)
        {
            ID = id;
            Name = name;
            Category = category;
            Brand = brand; Model = model; Description = description;
            Price = price;
            RoomInWebshop = roomInWebshop; RoomInShop = roomInShop; RoomInStorage = roomInStorage;
            MinimumAmountInStock = minimumAmountInStock; InWebshopAmount = inWebshopAmount;
            InShopAmount = inShopAmount; InStorageAmount = inStorageAmount;
        }
       public int ID { get;  set; }
       public String Name { get; set; }
       public String Category { get; set; }
       public String Brand { get; set; }
       public String Model { get; set; }
       public String Description { get; set; }
       public double Price { get; set; }
       public int RoomInWebshop { get; set; }
       public int RoomInShop { get; set; }
       public int RoomInStorage { get; set; }
       public int MinimumAmountInStock { get; set; }
       public int InWebshopAmount { get; set; }
       public int InShopAmount { get; set; }
       public int InStorageAmount { get; set; }
       public byte[] Image { get; set; }
    }
}
