using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Capstone.Classes;

namespace Capstone.CLI
{
    public class VendingMachine
    {
        public decimal Balance { get; set; } = 0M;

        //Create a dictionary that will contain slotID (key) and food (value)
        public Dictionary<string, Food> DictOfProducts { get; set; }

        //Create a file to write result to
        string outPath = @"../../../../Log.txt";

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
            if (DictOfProducts.ContainsKey(input))
            {
                Food food = DictOfProducts[input];
                if (Balance < food.Price)
                {
                    return "Not enough money";
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
        }

        public string FinishTransaction()
        {
            //Initialize an int to store change
            int numOfNickels = 0;
            int numOfDimes = 0;
            int numOfQuarters = 0;

            //Multiply balance by 100 so the entire balance is in cents
            Balance *= 100;

            //Balance = $2.95 --> 295 cents

            //First determine number of Tens
            if (Balance / 25 >= 1)
            {
                numOfQuarters = (int)(Balance / 25);
                Balance = Balance % 25; //this leaves the remainder
            }
            if (Balance / 10 >= 1)
            {
                numOfDimes = (int)(Balance / 10);
                Balance = Balance % 10;
            }
            if (Balance / 5 >= 1)
            {
                numOfNickels = 1;
            }
            //Reset balance to 0, if not already
            Balance = 0;

            //Return quantity of each coin
            // Please take your change: 11 quarters, 2 dimes, 0 nickels
            return ($"Please take your change: {numOfQuarters} quarters, {numOfDimes} dimes, {numOfNickels} nickels");
        }


            //Generate Audit Log
            // Date and time and action 
            public void AuditLog(string action, decimal initialBalance, decimal finalBalance)
            {
            
                string newLine = "";
                using (StreamWriter writer = new StreamWriter(outPath, true))
                {
                    writer.WriteLine($"{DateTime.Now} {action} {initialBalance:c} {finalBalance:c}");
                
                }
            }
        public void AuditLog(string one, string two, decimal initialBalance, decimal finalBalance)
        {

            string newLine = "";
            using (StreamWriter writer = new StreamWriter(outPath, true))
            {
                writer.WriteLine($"{DateTime.Now} {one} {two} {initialBalance:c} {finalBalance:c}");

            }
        }
    }
}
