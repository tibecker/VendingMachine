using Capstone.Classes;
using MenuFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.CLI
{
    public class MainMenu : ConsoleMenu
    {
        /*******************************************************************************
         * Private data:
         * Usually, a menu has to hold a reference to some type of "business objects",
         * on which all of the actions requested by the user are performed. A common 
         * technique would be to declare those private fields here, and then pass them
         * in through the constructor of the menu.
         * ****************************************************************************/

        // NOTE: This constructor could be changed to accept arguments needed by the menu

        private VendingMachine vendingMachine;
        public MainMenu(VendingMachine aVendingMachine)
        {
            vendingMachine = aVendingMachine;
            //In constructor add all of the options and the name of the method to execute
            // Add Sample menu options
            AddOption("Display Vending Machine Items", DisplayItems);
            AddOption("Purchase", Purchase);
            AddOption("Quit", Close);

            Configure(cfg =>
           {
               cfg.ItemForegroundColor = ConsoleColor.White;
              // cfg.MenuSelectionMode = MenuSelectionMode.KeyString; // KeyString: User types a key, Arrow: User selects with arrow
               cfg.KeyStringTextSeparator = ": ";
               cfg.Title = "Main Menu";
           });
        }

        private MenuOptionResult Purchase()
        {
            PurchaseMenu purchaseMenu = new PurchaseMenu(vendingMachine);
            purchaseMenu.Show();
            return MenuOptionResult.WaitAfterMenuSelection;
        }


        private MenuOptionResult DisplayItems()
        {
            foreach(KeyValuePair<string, Food> kvp in vendingMachine.DictOfProducts)
            {
                Console.WriteLine($"Item: {kvp.Value.Product}, Amount:{kvp.Value.Quantity}");
            }
            return MenuOptionResult.WaitAfterMenuSelection;
        }
    }
}
