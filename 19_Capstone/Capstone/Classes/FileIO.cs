using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Capstone.Classes;

namespace Capstone.CLI
{
    public class FileIO
    {
        public Dictionary<string, Food> LoadData()
        {
            //The file path where the data is stored
            string inputPath = @"../../../../vendingmachine.csv";


            //Create dictionary
            Dictionary<string, Food> dictOfProducts = new Dictionary<string, Food>() { };

            //Read file line by line
            using (StreamReader reader = new StreamReader(inputPath))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();

                    //Create an array to temporarily store values
                    string[] tempArray = line.Split("|");
                    // i.e. tempArray = ["A1","Potato Crisps", "3.05", "Chip"]

                    string tempString = tempArray[2];

                    //Convert price from string into decimal
                    decimal productPrice = Convert.ToDecimal(tempString);


                    //Create conditionals that will create a new instance of the product

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