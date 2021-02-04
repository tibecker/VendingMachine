using Capstone.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.CLI
{
    public class Beverage : Food
    {
        override public string Message
        {
            get
            {
                return "Glug, Glug, Yum!";
            }
        }

        public Beverage(string product, decimal price, string slot): base(product, price, slot)
        {

        }
    }
}
