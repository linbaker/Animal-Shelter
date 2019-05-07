using System.Collections.Generic;
using MySql.Data.MySqlClient;
using AnimalShelter;
using System;

namespace AnimalShelter.Models
{
  public class Animal
  {
    public string Type { get; set; }
    public string Name  { get; set; }
    public string Sex { get; set; }
    public string Breed { get; set; }
    public DateTime DateOfAdmit { get; set; }
    public int Id { get; set; }

    public Animal (string type, string name, string sex, string breed, DateTime dateOfAdmit, int id = 0)
    {
      Type = type;
      Name = name;
      Sex = sex;
      Breed = breed;
      DateOfAdmit = dateOfAdmit;
      Id = id;
    }

    public static void ClearAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM animals;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public override bool Equals(System.Object otherAnimal)
    {
      if (!(otherAnimal is Animal))
      {
        return false;
      }
      else
      {
        Animal newAnimal = (Animal) otherAnimal;
        bool descriptionEquality = (this.Name == newAnimal.Name);
        return (descriptionEquality);
      }
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO `animals` (`type`, `name`, `sex`, `breed`, `dateOfAdmit`) VALUES (@Animaltype, @AnimalName, @AnimalSex, @AnimalBreed, @AnimalDateOfAdmit);";
      MySqlParameter type = new MySqlParameter();
      type.ParameterName = "@AnimalType";
      type.Value = this.Type;

      MySqlParameter name = new MySqlParameter();
      name.ParameterName = "@AnimalName";
      name.Value = this.Name;

      MySqlParameter sex = new MySqlParameter();
      sex.ParameterName = "@AnimalSex";
      sex.Value = this.Sex;

      MySqlParameter breed = new MySqlParameter();
      breed.ParameterName = "@AnimalBreed";
      breed.Value = this.Breed;

      MySqlParameter dateOfAdmit = new MySqlParameter();
      dateOfAdmit.ParameterName = "@AnimalDateOfAdmit";
      dateOfAdmit.Value = this.DateOfAdmit;


      cmd.Parameters.Add(type);
      cmd.Parameters.Add(name);
      cmd.Parameters.Add(sex);
      cmd.Parameters.Add(breed);
      cmd.Parameters.Add(dateOfAdmit);
      cmd.ExecuteNonQuery();
      // more logic will go here
      Id = (int) cmd.LastInsertedId;
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public static List<Animal> GetAll()
    {
      List<Animal> allAnimals = new List<Animal> {};


      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM animals;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;

      while (rdr.Read())
      {
        string type = rdr.GetString(0);
        string name = rdr.GetString(1);
        string sex = rdr.GetString(2);
        string breed = rdr.GetString(3);
        DateTime dateOfAdmit = rdr.GetDateTime(4);
        int id = rdr.GetInt32(5);


        Animal newAnimal = new Animal(type, name, sex, breed, dateOfAdmit, id);
        allAnimals.Add(newAnimal);
      }

      conn.Close();

      if (conn != null)
      {
        conn.Dispose();
      }

      return allAnimals;

    }
    public static List<Animal> SortByType()
    {
      List<Animal> allAnimals = new List<Animal> {};


      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM animals ORDER BY type ASC;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;

      while (rdr.Read())
      {
        string type = rdr.GetString(0);
        string name = rdr.GetString(1);
        string sex = rdr.GetString(2);
        string breed = rdr.GetString(3);
        DateTime dateOfAdmit = rdr.GetDateTime(4);
        int id = rdr.GetInt32(5);


        Animal newAnimal = new Animal(type, name, sex, breed, dateOfAdmit, id);
        allAnimals.Add(newAnimal);
      }

      conn.Close();

      if (conn != null)
      {
        conn.Dispose();
      }

      return allAnimals;

    }
  }
}
