using Capstone.Classes;
using Capstone.CLI;
using System;
using System.Collections.Generic;

namespace Capstone
{
    class Program
    {
        /****************************************************************************************
         * Notes on this Capstone solution:
         *      This solution contains both a project for the Vending Machine program (Capstone)
         *      and a project for tests (CapstoneTests). The Test project already references the
         *      Capstone project, so all you need to do is add Test Classes and Test Methods.
         *      
         *      ConsoleMenuFramework has been added via Nuget, so the project is ready to derive
         *      new menus. There is already a sample menu in the CLI folder. You can rename this 
         *      one, or create a new one to get started.
         * 
         * *************************************************************************************/
        static void Main(string[] args)
        {
            // This is the path where the vending machine items are stored. 
            string inputPath = @"../../../../vendingmachine.csv";

            // The input path is passed in to an instance of the FileIO class where a 
            // dictionary of products is created.
            FileIO file = new FileIO(inputPath);
            Dictionary<string, Food> dictionaryOfProducts = file.LoadData();

            // Create a new instance of the class 'Vending Machine'
            // and pass in the inventory
            VendingMachine vendingMachine = new VendingMachine(dictionaryOfProducts);

            // Create an instance of the Main
            MainMenu mainMenu = new MainMenu(vendingMachine);
            mainMenu.Show();
        }
    }
}
