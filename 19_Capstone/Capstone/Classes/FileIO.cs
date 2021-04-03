using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Capstone.Classes;

namespace Capstone.CLI
{
    // The purpose of this class is to import the values from a CSV and
    // populate those values into a dictionary that contains all of the
    // products inside of the vending machine.

    public class FileIO
    {
        public Dictionary<string, Food> LoadData(string inputPath)
        {
            // Initialize dictionary of products to store all of the items in the vending machine.
            Dictionary<string, Food> dictOfProducts = new Dictionary<string, Food>() { };

            // Use streamreader to read the CSV file line-by-line
            using (StreamReader reader = new StreamReader(inputPath))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();

                    // Create an array to temporarily store values, using '|' to delimit values
                    // i.e. tempArray = ["A1","Potato Crisps", "3.05", "Chip"]
                    string[] tempArray = line.Split("|");
                   
                    // Convert the price from a string to a decimal
                    string priceAsString = tempArray[2];
                    decimal productPrice = Convert.ToDecimal(priceAsString);


                    // Use Polymorphism to create different implementations of the class 'Food'
                    // Add each item to the dictionary

                    if (tempArray[3] == "Chip")
                    {
                        Food food = new Chip(tempArray[1], productPrice, tempArray[0]);
                        dictOfProducts.Add(tempArray[0], food);
                    }
                    else if (tempArray[3] == "Drink")
                    {
                        Food food = new Drink(tempArray[1], productPrice, tempArray[0]);
                        dictOfProducts.Add(tempArray[0], food);
                    }
                    else if (tempArray[3] == "Candy")
                    {
                        Food food = new Candy(tempArray[1], productPrice, tempArray[0]);
                        dictOfProducts.Add(tempArray[0], food);
                    }
                    else if (tempArray[3] == "Gum")
                    {
                        Food food = new Gum(tempArray[1], productPrice, tempArray[0]);
                        dictOfProducts.Add(tempArray[0], food);
                    }
                }
            }
            return dictOfProducts;
        }
     }
}