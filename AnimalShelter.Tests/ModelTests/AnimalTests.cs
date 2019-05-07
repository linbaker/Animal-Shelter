using Microsoft.VisualStudio.TestTools.UnitTesting;
using AnimalShelter.Models;
using System.Collections.Generic;
using System;

namespace AnimalShelter.Tests
{
  [TestClass]
  public class AnimalTest : IDisposable
  {

    public void Dispose()
    {
      Animal.ClearAll();
    }

    public AnimalTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=animalshelter_test;";
    }

    [TestMethod]
    public void Equals_ReturnsTrueIfAnimalsAreTheSame_Animal()
    {
      // Arrange, Act
      Animal firstAnimal = new Animal("bunny", "Marlo Bundo", "m", "long hair", new DateTime(2019,05,01));
      Animal secondAnimal = new Animal("bunny", "Marlo Bundo", "m", "long hair", new DateTime(2019,05,01));

      // Assert
      Assert.AreEqual(firstAnimal, secondAnimal);
    }

    [TestMethod]
    public void AnimalConstructor_CreatesInstanceOfAnimal_Animal()
    {
      Animal newAnimal = new Animal("type", "name", "m", "breed", new DateTime(2019,06,08));
      Assert.AreEqual(typeof(Animal), newAnimal.GetType());
    }

    [TestMethod]
    public void GetAll_ReturnsEmptyList_AnimalsList()
    {
      //Arrange
      List<Animal> newList = new List<Animal> { };

      //Act
      List<Animal> result = Animal.GetAll();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void Save_SavesAnimalsToDB_Animals()
    {
      Animal newAnimal = new Animal("doggo", "Howard", "m", "bull terrier", new DateTime(2019,06,08));
      newAnimal.Save();
      List<Animal> newList = Animal.GetAll();
      List<Animal> newListTwo = new List<Animal> { newAnimal };

      CollectionAssert.AreEqual(newList, newListTwo);
    }

    // [TestMethod]
    // public void Save_AssignsIdToObject_Id()
    // {
    //   Animal testAnimal = new Animal("type", "name", "m", "breed", "2019-05-01");
    //
    //   testAnimal.Save();
    //   Animal savedAnimal = Animal.GetAll()[0];
    //
    //   int result = savedAnimal.Id;
    //   int testId = testAnimal.Id;
    //
    //   Assert.AreEqual(testId, result);
    // }
    // 
    // [TestMethod]
    // public void GetAll_ReturnsItems_ItemList()
    // {
    //   //Arrange
    //   Animal animalOne = new Animal("catto", "Judy", "f", "breed", "2019-05-01");
    //   animalOne.Save();
    //   Animal animalTwo = new Animal("doggo", "Terence", "m", "breed", "2019-05-01");
    //   animalTwo.Save();
    //   List<Animal> newList = new List<Animal> { animalOne, animalTwo };
    //
    //   //Act
    //   List<Animal> result = Animal.GetAll();
    //   foreach(Animal animal in result)
    //   {
    //     Console.WriteLine(animal.Name);
    //   }
    //   //Assert
    //   CollectionAssert.AreEqual(newList, result);
    // }

    // [TestMethod]
    // public void GetId_ItemsInstantiateWithAnIdAndGetterReturns_Int()
    // {
    //   //Arrange
    //   string description = "Walk the dog.";
    //   Item newItem = new Item(description);
    //
    //   //Act
    //   int result = newItem.GetId();
    //
    //   //Assert
    //   Assert.AreEqual(1, result);
    // }

    // [TestMethod]
    // public void Find_ReturnsCorrectItem_Item()
    // {
    //   //Arrange
    //   string description01 = "Walk the dog";
    //   string description02 = "Wash the dishes";
    //   Item newItem1 = new Item(description01);
    //   Item newItem2 = new Item(description02);
    //
    //   //Act
    //   Item result = Item.Find(2);
    //
    //   //Assert
    //   Assert.AreEqual(newItem2, result);
    // }

  }
}
