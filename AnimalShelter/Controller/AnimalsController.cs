using Microsoft.AspNetCore.Mvc;
using AnimalShelter.Models;
using System.Collections.Generic;
using System;

namespace AnimalShelter.Controllers
{
  public class AnimalsController : Controller
  {

    [HttpGet("/animals")]
    public ActionResult Index()
    {
      // Animal newAnimal = new Animal();
      List<Animal> allAnimals = Animal.GetAll();
      return View(allAnimals);
    }

    [HttpGet("/animals/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/animals")]
    public ActionResult Create(string type, string name, string sex, string breed, DateTime dateOfAdmit)
    {
      Animal myAnimal = new Animal(type, name, sex, breed, dateOfAdmit);
      myAnimal.Save();
      return RedirectToAction("Index");
    }
    [HttpGet("/animals/SortByType")]
    public ActionResult SortByType()
    {
      // Animal newAnimal = new Animal();
      List<Animal> allSortedAnimals = Animal.SortByType();
      return View(allSortedAnimals);
    }

    // [HttpGet("/animals/{animalId}")]
    // public ActionResult Show(string countryCode)
    // {
    //   Dictionary<string, object> model = new Dictionary<string, object> {};
    //   Animal selectedAnimal = Animal.GetAnimalById(animalId);
    //   List<Animal> selectedAnimals = Animal.GetAnimalsByAnimalCode(animalId);
    //   model.Add("animals", selectedAnimal);
    //   // model.Add("cities", selectedAnimals);
    //
    //   return View(model);
    // }


    // [HttpGet("/categories/{categoryId}/items/new")]
    // public ActionResult New(int categoryId)
    // {
    //    Category category = Category.Find(categoryId);
    //    return View(category);
    // }
    //
    // [HttpGet("/categories/{categoryId}/items/{itemId}")]
    // public ActionResult Show(int categoryId, int itemId)
    // {
    //   Item item = Item.Find(itemId);
    //   Dictionary<string, object> model = new Dictionary<string, object>();
    //   Category category = Category.Find(categoryId);
    //   model.Add("item", item);
    //   model.Add("category", category);
    //   return View(model);
    // }
    //
    // [HttpPost("/items/delete")]
    // public ActionResult DeleteAll()
    // {
    //   Item.ClearAll();
    //   return View();
    // }

  }
}
