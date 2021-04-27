using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJMediaBazaar.Logic
{
    public class Item
    {
        public Item(int id, String name, String category, String subcategory, double price, int quantity)
        {
            ID = id;
            Name = name;
            Category = category;
            Subcategory = subcategory;
            Price = price;
            Quantity = quantity;
        }
        public void SetSpecification(Specification spec)
        {
            Specifications.Add(spec);
        }
       public int ID { get;  set; }
       public String Name { get; set; }
       public String Category { get; set; }
       public String Subcategory { get; set; }
       public double Price { get;  set; }
       public int Quantity { get;  set; }
       public List<Specification> Specifications { get;  set; }
       public double TotalPrice { get { return this.Price * this.Quantity; } }
    }
}
