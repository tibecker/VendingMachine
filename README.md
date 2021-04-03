# VendingMachine
This repository includes code for a vending machine simulator that I created with Clayton Cross using C# as part of the .NET Framework.

Description

The purpose of this application is to simulate a vending machine as a way to practice fundamental C# and OOP principles. Users are able to see a list of all items in the vending machine, make purchases, and an audit log is generated for all transactions. 

How it works

This application uses StreamReader to pull in vending machine items that are stored on a csv file. These items are saved to a dictionary, where the key is the slot location and the value is a food object. We created an abstract Food class which is extended to the subclasses of Candy, Chip, Drink, and Gum. When the csv file is parsed, a new object is created for each item corresponding to one the subclasses. 

A new vending machine object is then created. During the instantion of that class, a dictionary of items is passed in. The vending machine class uses encapsulation to bundle together all of the properties and classes of a vending machine. Here, there are methods to feed money, select a product, finish a transaction, and a method for generating an audit log. 

For the menu, we pulled in the ConsoleMenuFramework(1.5.0) package. We then invoked the methods that we had created in the vending machine class. When a user selects a product, a message is displayed to the user that is unique for each type of food. We were able to use polymorphism, as each subclass implemented the property. 
