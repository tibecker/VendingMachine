using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Capstone.CLI;
using Capstone.Classes;

namespace CapstoneTests
{
    [TestClass]
    public class VendingMachineTests
    {
        [DataTestMethod]
        [DataRow(10, 10.00)]
        public void FeedMoneyMethod_ReturnBalance(int inputAmount, double inputResult)
        {
            //Arrange - Create new object called 'vendingMachine', which is an instance of the class VendingMachine
            VendingMachine vendingMachine = new VendingMachine();
            decimal expectedResult = Convert.ToDecimal(inputResult);

            //Act
            decimal actualResult = vendingMachine.FeedMoney(inputAmount);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [DataTestMethod]
        [DataRow(10, 15.00)]
        public void FeedMoneyMethod_ReturnBalanceWithInitialBalance(int inputAmount, double inputResult)
        {
            //Arrange - Create new object called 'vendingMachine', which is an instance of the class VendingMachine
            VendingMachine vendingMachine = new VendingMachine(5);
            decimal expectedResult = Convert.ToDecimal(inputResult);

            //Act
            decimal actualResult = vendingMachine.FeedMoney(inputAmount);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [DataTestMethod]
        [DataRow("A1", "Not enough money")]
        [DataRow("E4", "Invalid key code")]
        [DataRow("C3", "SOLD OUT")]

        //Passing cases for chip, candy, drink, gum
        [DataRow("A2", "Crunch Crunch, Yum!")]
        [DataRow("C1", "Glug Glug, Yum!")]
        [DataRow("B3", "Munch Munch, Yum!")]
        [DataRow("D1", "Chew Chew, Yum!")]

        public void SelectProduct_ReturnMessage(string slotID, string expectedResult)
        {
            //Arrange - Create new object called 'vendingMachine', which is an instance of the class VendingMachine
            FileIO fileIO = new FileIO();
            Dictionary<string, Food> dictionaryOfProducts = fileIO.LoadData();
            VendingMachine vendingMachine = new VendingMachine(1.50M);
            vendingMachine.DictOfProducts = dictionaryOfProducts;

            vendingMachine.DictOfProducts["C3"].Quantity = 0;

            //Act
            string actualResult = vendingMachine.SelectProduct(slotID);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [DataTestMethod]
        [DataRow(10, "Please take your change: 40 quarters, 0 dimes, 0 nickels")]
        [DataRow(0, "Please take your change: 0 quarters, 0 dimes, 0 nickels")]
        [DataRow(10.20, "Please take your change: 40 quarters, 2 dimes, 0 nickels")]
        [DataRow(10.15, "Please take your change: 40 quarters, 1 dimes, 1 nickels")]
        public void FinishTransaction_ReturnNumOfEachCoin(double balance, string expectedResult)
        {
            //Arrange - Create new object called 'vendingMachine', which is an instance of the class VendingMachine
            VendingMachine vendingMachine = new VendingMachine();
            vendingMachine.Balance = Convert.ToDecimal(balance);

            //Act
            string actualResult = vendingMachine.FinishTransaction();

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

    }
}
