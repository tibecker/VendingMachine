using Capstone.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.CLI
{
     public class Gum : Food
    {
        override public string Message
        {
            get
            {
                return "Chew, Chew, Yum!";
            }
        }

        public Gum(string product, decimal price, string slot) : base(product, price, slot)
        {

        }
    }
}
