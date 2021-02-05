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
        [DataRow("A1", "Crunch Crunch, Yum!")]
        [DataRow("B1", "Munch Munch, Yum!")]
        [DataRow("C3", "Gulp Gulp, Yum!")]
        public void SelectProductMethod_ReturnMessage(string slot, string expectedValue)
        {
            //Arrange
            VendingMachine vendMachine = new VendingMachine();


            //Act
            string actualValue = vendMachine.SelectProduct();

            //Assert
            Assert.AreEqual(expectedValue, actualValue);


        }

    }
}
