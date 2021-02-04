using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Capstone.Classes;

namespace Capstone.CLI
{
    class FileIO
    {
        public void LoadData()
        {
            //The file path where the data is stored
            string inputPath = @"../../../../vendingmachine.csv";

            //Create a dictionary that will contain slotID and an instance of the class Food
            Dictionary<string, Food> product = new Dictionary<string, Food>() { };

            using (StreamReader reader = new StreamReader(inputPath))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();

                    //Create an array to temporarily store values
                    string[] tempArray = line.Split("|");
                    // i.e. tempArray = ["A1","Potato Crisps", "3.05", "Chip"]

                    string tempString = tempArray[2];

                    //Convert price from string into double
                    decimal productPrice = Convert.ToDecimal(tempString);


                    //Create conditionals that will create a new instance of the product

                    if (tempArray[3] == "Chip")
                    {
                        Food food = new Chip(tempArray[1], productPrice, tempArray[0]);
                        product.Add(tempArray[0], food);
                    }
                    else if (tempArray[3] == "Beverage")
                    {
                        Food food = new Beverage(tempArray[1], productPrice, tempArray[0]);
                        product.Add(tempArray[0], food);
                    }
                    else if (tempArray[3] == "Candy")
                    {
                        Food food = new Candy(tempArray[1], productPrice, tempArray[0]);
                        product.Add(tempArray[0], food);
                    }
                    else if (tempArray[3] == "Gum")
                    {
                        Food food = new Gum(tempArray[1], productPrice, tempArray[0]);
                        product.Add(tempArray[0], food);
                    }


                }
            }
        }
     }
}