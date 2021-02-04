using Capstone.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.CLI
{
     public class Candy : Food
    {
        override public string Message
        {
            get
            {
                return "Munch, Munch, Yum!";
            }
        }

        public Candy(string product, decimal price, string slot) : base(product, price, slot)
        {

        }

    }
}
