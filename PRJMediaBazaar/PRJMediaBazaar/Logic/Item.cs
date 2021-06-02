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
        public Item(int id, String category, String subcatgeory ,String brand,String model, String description,
                    double stock_price, double price, String restock_state,int roomInShop, int roomInStorage,
                    int minimumAmountInStock, int inShopAmount, int inStorageAmount)
        {
            ID = id;
            Category = category;
            Subcategory = subcatgeory;
            Brand = brand; Model = model; Description = description;
            Stock_Price = stock_price; 
            Price = price; Restock_State = restock_state;
             RoomInShop = roomInShop; RoomInStorage = roomInStorage;
            MinimumAmountInStock = minimumAmountInStock; 
            InShopAmount = inShopAmount; InStorageAmount = inStorageAmount;
            Image = null;
        }
       public int ID { get;  set; }
       public String Name { get { return this.Category + " " + this.Subcategory + " " + this.Brand + " " + this.Model; } }
       public String Category { get; set; }
        public String Subcategory { get; set; }
       public String Brand { get; set; }
       public String Model { get; set; }
       public String Description { get; set; }
       public double Stock_Price { get; set; }
       public double Price { get; set; }
        public String Restock_State { get; set; }
       public int RoomInShop { get; set; }
       public int RoomInStorage { get; set; }
       public int MinimumAmountInStock { get; set; }
       public int InShopAmount { get; set; }
       public int InStorageAmount { get; set; }
       public byte[] Image { get; set; }


        public override string ToString()
        {
            //return "ID : " + ID + " Name : " + Name + " Category : " + Category + " Subcategory : " + Subcategory + " Brand : " + Brand + " Model : " + Model
            //    + " Description : " + Description + " Price : " + Price + " $ " + "Room in Shop : " + RoomInShop + " Room in Storage : " + RoomInStorage
            //    + " Minimum Amount in Stock : " + MinimumAmountInStock + " Amount in Shop : " + InShopAmount + " Amount in Storage : " + InStorageAmount;


            return "ID : " + ID + " Title : " + Name + " Price : " + Price + " Stock Price : " + Stock_Price;
        }
    }
}
