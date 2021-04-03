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
            decimal initialBalance = vendingMachine.Balance;
            int inputAmount = GetInteger("Enter amount in U.S. dollars",0, new int [] {1,2,5,10});
            decimal newBalance = vendingMachine.FeedMoney(inputAmount);
            Console.WriteLine($"Your new balance is {newBalance:c}.");
            vendingMachine.AuditLog("FEED MONEY:", initialBalance, newBalance) ;
            return MenuOptionResult.WaitAfterMenuSelection;
        }

        protected override void OnAfterShow()
        {
            Console.WriteLine($"Balance: {vendingMachine.Balance:c}");
        }

        private MenuOptionResult SelectProduct()
        {
            decimal initialBalance = vendingMachine.Balance;
            Console.WriteLine();
            foreach (KeyValuePair<string, Food> kvp in vendingMachine.DictOfProducts)
            {
                // A1: Potato Crisps
                // A2: Stackers
                //Only display product if it is in stock
                if (kvp.Value.Quantity >= 1)
                {
                    Console.WriteLine($" {kvp.Value.Product}({kvp.Value.Slot}): {kvp.Value.Price:c}");
                }
            }
            Console.WriteLine();
            string selectedProduct = GetString("Please select 2-digit code");
            string messageOfProduct = vendingMachine.SelectProduct(selectedProduct.ToUpper());
            Console.WriteLine(messageOfProduct);
            Food food = vendingMachine.DictOfProducts[selectedProduct.ToUpper()];
            string chosenFood = food.Product;
            decimal newBalance = vendingMachine.Balance;
            vendingMachine.AuditLog(chosenFood, selectedProduct.ToUpper(), initialBalance, newBalance);
            return MenuOptionResult.WaitAfterMenuSelection; //Wait for user to hit enter before re-displaying menu
        }

        private MenuOptionResult FinishTransaction()
        {
            decimal initialBalance = vendingMachine.Balance;
            string change = vendingMachine.FinishTransaction();
            decimal newBalance = vendingMachine.Balance;
            Console.WriteLine(change);
            vendingMachine.AuditLog("GIVE CHANGE:", initialBalance, newBalance);
            return MenuOptionResult.ExitAfterSelection;
        }
    }
}
