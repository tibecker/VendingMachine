using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Classes;

namespace Capstone.CLI
{
    public class VendingMachine
    {
        public decimal Balance { get; set; } = 0;

        //Create a dictionary that will contain slotID (key) and food (value)
        public Dictionary<string, Food> DictOfProducts { get; set; }

        //Two constructors - the first constructor
        public VendingMachine(decimal balance)
        {
            this.Balance = balance;
        }

        public VendingMachine()
        {

        }

        public decimal FeedMoney(int inputMoney)
        {
            Balance += inputMoney;

            return Balance;
        }

        public string SelectProduct(string input)
        {
            ////check if products are available
            //foreach (KeyValuePair<string, Food> kvp in DictOfProducts)
            //{
            //    // A1: Potato Crisps
            //    // A2: Stackers
            //    //Only display product if it is in stock
            //    if (kvp.Value.Quantity >= 1)
            //    {
            //        Console.WriteLine($"{kvp.Key}: {kvp.Value.Product}");
            //    }
            //}

            ////Ask user to enter a code for item

      

            // if they have enough money for product
            // match input to Slot, which is the key in products

            if (DictOfProducts.ContainsKey(input))
            {
                Food food = DictOfProducts[input];
                if (Balance < food.Price)
                {
                    return "not enough money";
                }
                if (food.Quantity <= 0)
                {
                    return "SOLD OUT";
                }
                Balance -= food.Price;
                food.Quantity--;
                return food.Message;
            }
            return "Invalid key code";

            //foreach (KeyValuePair<string, Food> kvp in DictOfProducts)
            //{
            //    if (kvp.Key == input && Balance >= kvp.Value.Quantity)
            //    {
            //        Balance -= kvp.Value.Price;
            //        return kvp.Value.Message;
            //    }
            //}
            //return "error";
        }

        public void FinishTransaction()
        {
            //Initialize an int to store change
            int numOfNickels = 0;
            int numOfDimes = 0;
            int numOfQuarters = 0;

            //Multiply balance by 100 so the entire balance is in cents
            Balance *= 100; 

            //Balance = $2.95 --> 295 cents

            //First determine number of Tens
            if (Balance/25 >= 1)
            {
                numOfQuarters = (int)(Balance / 25);
                Balance = Balance % 25; //this leaves the remainder
            }
            if (Balance/10 >= 1)
            {
                numOfDimes = (int)(Balance / 25);
                Balance = Balance % 10;
            }
            if (Balance/5 >= 1)
            {
                numOfNickels = 1;
            }
            //Reset balance to 0, if not already
            Balance = 0;

            //Return quantity of each coin
            // Please take your change: 11 quarters, 2 dimes, 0 nickels
            Console.WriteLine($"Please take your change: {numOfQuarters} quarters, {numOfDimes} dimes, {numOfNickels} nickels");
        }

    }
}
