using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Classes;

namespace Capstone.CLI
{
     public class VendingMachine
    {

        public decimal Balance { get; set; } = 0;


        public decimal FeedMoney(int input)
        {
            Balance += input;

            return Balance;
        }

        public List<string> SelectProduct()
        {
            //check if products are available
            foreach (KeyValuePair<string, Food> kvp in product )

            // if they have enough money for product
        }

        

    }
}
