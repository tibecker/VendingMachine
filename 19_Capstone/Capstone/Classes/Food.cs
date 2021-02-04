using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    abstract public class Food
    {
        public string Product { get; }
        public int Quantity { get; set; }
        public double Price { get; }
        public string Slot { get; }
        virtual public string Message { get; }

        public Food(string product, int quantity, double price, string slot)
        {
            this.Product = product;
            this.Quantity = quantity;
            this.Price = price;
            this.Slot = slot;
        }

    }
}
