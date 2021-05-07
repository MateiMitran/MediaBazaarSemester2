using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJMediaBazaar.Logic
{
    class Restock
    {
        private int id;
        private Item item;
        private bool finished;
        private int quantity;
        private double price;
        public Restock(int id, Item item, int quantity, double price)
        {
            this.id = id;
            this.item = item;
            this.quantity = quantity;
            this.price = price;
            this.finished = false;
        }
        public void Finish()
        {
            this.finished = true;
        }
        public int ID { get { return this.id; } set { this.id = value; } }
        public Item Item { get { return this.item; } set { this.item = value; } }
        public bool Finished { get { return this.finished; }set { this.finished = value; } }
        public int Quantity { get { return this.quantity; }set { this.quantity = value; } }
        public double Price { get { return this.price; } set { this.price = value; } }
    }
}
