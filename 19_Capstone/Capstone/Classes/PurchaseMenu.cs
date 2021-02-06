using Capstone.CLI;
using MenuFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class PurchaseMenu : ConsoleMenu
    {
        private VendingMachine vendingMachine;



        public PurchaseMenu(VendingMachine aVendingMachine)
        {
            this.vendingMachine = aVendingMachine;

            AddOption("Feed Money", FeedMoney);
            AddOption("Select Product", SelectProduct);
            AddOption("Finish Transaction", FinishTransaction);

        }

        private MenuOptionResult FeedMoney()
        {
            int inputAmount = GetInteger("Enter amount in dollars",0, new int [] { 1,2,5,10});
            decimal newBalance = vendingMachine.FeedMoney(inputAmount);
            Console.WriteLine($"Your new balance is {newBalance:c}.");
            return MenuOptionResult.WaitAfterMenuSelection;
        }

        protected override void OnAfterShow()
        {
            Console.WriteLine($"Balance: {vendingMachine.Balance:c}");
        }

        private MenuOptionResult SelectProduct()
        {
            foreach (KeyValuePair<string, Food> kvp in vendingMachine.DictOfProducts)
            {
                // A1: Potato Crisps
                // A2: Stackers
                //Only display product if it is in stock
                if (kvp.Value.Quantity >= 1)
                {
                    Console.WriteLine($"{kvp.Key}: {kvp.Value.Product}");
                }
            }
            string selectedProduct = GetString("Please select 2-digit code");
            string messageOfProduct = vendingMachine.SelectProduct(selectedProduct);
            Console.WriteLine(messageOfProduct);
            return MenuOptionResult.WaitAfterMenuSelection; //Wait for user to hit enter before re-displaying menu
        }

        private MenuOptionResult FinishTransaction()
        {
            string change = vendingMachine.FinishTransaction();
            Console.WriteLine(change);
            return MenuOptionResult.ExitAfterSelection;
        }
    }
}
