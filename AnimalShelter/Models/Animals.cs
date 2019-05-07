using System.Collections.Generic;
using MySql.Data.MySqlClient;
using AnimalShelter;

namespace AnimalShelter.Models
{
  public class Animals
  {
    public string Type { get; set; }
    public string Name  { get; set; }
    public string Sex { get; set; }
    public string Breed { get; set; }
    public datetime DateOfAdmittance { get; set; }

    public Animal(string type, string name, string sex, string breed, datetime dateOfAdmittance)
    {
      Type = type;
      Name = name;
      Sex = sex;
      Breed = breed;
      DateOfAdmittance = dateOfAdmittance;
    }
  }
}
