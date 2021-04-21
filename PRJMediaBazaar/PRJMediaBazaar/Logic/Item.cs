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
       public int ID { get; private set; }
       public String Name { get; private set; }
       public String Category { get; private set; }
       public String Subcategory { get; private set; }
       public double Price { get; private set; }
       public int Quantity { get; private set; }
       public List<Specification> Specifications { get; private set; }
       public double TotalPrice { get { return this.Price * this.Quantity; } }
    }
}
