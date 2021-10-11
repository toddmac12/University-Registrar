// using MySql.Data.MySqlClient;
// using Microsoft.VisualStudio.TestTools.UnitTesting;
// using System.Collections.Generic;
// using Registrar.Models;
// using System;

// namespace Registrar.Tests
// {

//   [TestClass]
//   public class ItemTests : IDisposable
//   {

//     public void Dispose()
//     {
//       Student.ClearAll();
//     }
//     public void ItemTest()
//     {
//       DBConfiguration.ConnectionString = "server=localhost;user id=root;password=epicodus;port=3306;database=to_do_list_test;";
//     }

//     [TestMethod]
//     public void ItemConstructor_CreatesInstanceOfItem_Item()
//     {
//       Student newItem = new Student("test");
//       Assert.AreEqual(typeof(Student), newItem.GetType());
//     }

//     [TestMethod]
//     public void GetDescription_ReturnsDescription_String()
//     {
//       //Arrange
//       string description = "Walk the dog.";

//       //Act
//       Student newItem = new Student(description);
//       string result = newItem.Description;

//       //Assert
//       Assert.AreEqual(description, result);
//     }

//     [TestMethod]
//     public void SetDescription_SetDescription_String()
//     {
//       //Arrange
//       string description = "Walk the dog.";
//       Student newItem = new Student(description);

//       //Act
//       string updatedDescription = "Do the dishes";
//       newItem.Description = updatedDescription;
//       string result = newItem.Description;

//       //Assert
//       Assert.AreEqual(updatedDescription, result);
//     }

//     [TestMethod]
//     public void GetAll_ReturnsEmptyList_ItemList()
//     {
//       // Arrange
//       List<Student> newList = new List<Student> { };

//       // Act
//       List<Student> result = Student.GetAll();

//       // Assert
//       CollectionAssert.AreEqual(newList, result);
//     }

//     [TestMethod]
//     public void GetAll_ReturnsItems_ItemList()
//     {
//       //Arrange
//       string description01 = "Walk the dog";
//       string description02 = "Wash the dishes";
//       Student newItem1 = new Student(description01);
//       newItem1.Save();
//       Student newItem2 = new Student(description02);
//       newItem2.Save();
//       List<Student> newList = new List<Student> { newItem1, newItem2 };

//       //Act
//       List<Student> result = Student.GetAll();

//       //Assert
//       CollectionAssert.AreEqual(newList, result);
//     }

//     [TestMethod]
//     public void Equals_ReturnsTrueIfDescriptionsAreTheSame_Item()
//     {
//       // Arrange, Act
//       Student firstItem = new Student("Mow the lawn");
//       Student secondItem = new Student("Mow the lawn");

//       // Assert
//       Assert.AreEqual(firstItem, secondItem);
//     }

//     [TestMethod]
//     public void Save_SavesToDatabase_ItemList()
//     {
//       //Arrange
//       Student testItem = new Student("Mow the lawn");

//       //Act
//       testItem.Save();
//       List<Student> result = Student.GetAll();
//       List<Student> testList = new List<Student>{testItem};

//       //Assert
//       CollectionAssert.AreEqual(testList, result);
//     }

//     [TestMethod]
//     public void Find_ReturnsCorrectItemFromDatabase_Item()
//     {
//       //Arrange
//       Student newItem = new Student("Mow the lawn");
//       newItem.Save();
//       Student newItem2 = new Student("Wash dishes");
//       newItem2.Save();

//       //Act
//       Student foundItem = Student.Find(newItem.Id);
//       //Assert
//       Assert.AreEqual(newItem, foundItem);
//     }
//   }
// }