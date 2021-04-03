using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Capstone.CLI;
using Capstone.Classes;

namespace CapstoneTests
{
    [TestClass]
    public class FileIOTests
    {
        [DataTestMethod]
        [DataRow("A1|Potato Crisps|3.05|Chip", 3.05)]
        public void TestFileInput_LoadingData_ShouldReturn_CorrectPrice(string inputLine, double inputResult)
        {
            //Arrange - Create a new instance of FileIO class and a new vending machine
            FileIO fileIO = new FileIO('the.txt');
            decimal expectedResult = Convert.ToDecimal(inputResult);

            //Act
            Dictionary<string, Food> dictOfFoods = fileIO.LoadData();
            decimal actualResult = dictOfFoods["A1"].Price;


            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [DataTestMethod]
        [DataRow("A1|Potato Crisps|3.05|Chip", 5)]
        public void TestFileInput_LoadingData_ShouldReturn_CorrectQuantity(string inputLine, int expectedResult)
        {
            //Arrange - Create a new instance of FileIO class and a new vending machine
            FileIO fileIO = new FileIO('the.txt');

            //Act
            Dictionary<string, Food> dictOfFoods = fileIO.LoadData();
            int actualResult = dictOfFoods["A1"].Quantity;


            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

    }
}
