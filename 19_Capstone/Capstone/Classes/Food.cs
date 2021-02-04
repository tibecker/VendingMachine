using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    abstract public class Food
    {
        public string Product { get; }
        public int Quantity { get; set; } = 5;
        public decimal Price { get; }
        public string Slot { get; }
        virtual public string Message { get; }

        public Food(string product, decimal price, string slot)
        {
            this.Product = product;
            this.Price = price;
            this.Slot = slot;
        }

    }
}
