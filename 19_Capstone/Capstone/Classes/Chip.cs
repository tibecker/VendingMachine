using Capstone.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.CLI
{
    public class Chip : Food
    {
        override public string Message
        {
            get
            {
                return "Crunch, Crunch, Yum!";
            }
        }

        public Chip(string product, int quantity, double price, string slot) : base(product, quantity, price, slot)
        {

        }

    }
}
