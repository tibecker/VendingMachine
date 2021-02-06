using Capstone.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.CLI
{
    public class Drink : Food
    {
        override public string Message
        {
            get
            {
                return "Glug Glug, Yum!";
            }
        }

        public Drink(string product, decimal price, string slot): base(product, price, slot)
        {

        }
    }
}
