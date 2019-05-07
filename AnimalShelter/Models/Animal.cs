using System.Collections.Generic;
using MySql.Data.MySqlClient;
using AnimalShelter;

namespace AnimalShelter.Models
{
  public class Animal
  {
    public string Type { get; set; }
    public string Name  { get; set; }
    public string Sex { get; set; }
    public string Breed { get; set; }
    public string DateOfAdmittance { get; set; }
    public int Id { get; set; }

    public Animal (string type, string name, string sex, string breed, string dateOfAdmittance, int id = 0)
    {
      Type = type;
      Name = name;
      Sex = sex;
      Breed = breed;
      DateOfAdmittance = dateOfAdmittance;
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

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO items (type, name, sex, breed, dateOfAdmittance) VALUES (@Animaltype, @AnimalName, @AnimalSex, @AnimalBreed, @AnimalDateOfAdmittance);";
      MySqlParameter type = new MySqlParameter();
      type.ParameterName = "@AnimalType";
      type.Value = this.Type;
      cmd.Parameters.Add(type);
     cmd.ExecuteNonQuery();

      MySqlParameter name = new MySqlParameter();
      name.ParameterName = "@AnimalName";
      name.Value = this.Name;
      cmd.Parameters.Add(name);
     cmd.ExecuteNonQuery();

      MySqlParameter sex = new MySqlParameter();
      sex.ParameterName = "@AnimalSex";
      sex.Value = this.Sex;
      cmd.Parameters.Add(sex);
     cmd.ExecuteNonQuery();

      MySqlParameter breed = new MySqlParameter();
      breed.ParameterName = "@AnimalBreed";
      breed.Value = this.Breed;
      cmd.Parameters.Add(breed);
     cmd.ExecuteNonQuery();

      MySqlParameter dateOfAdmittance = new MySqlParameter();
      dateOfAdmittance.ParameterName = "@AnimalDateOfAdmittance";
      dateOfAdmittance.Value = this.DateOfAdmittance;
      cmd.Parameters.Add(dateOfAdmittance);
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


      // MySqlConnection conn = DB.Connection();
      // conn.Open();
      // MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      // cmd.CommandText = @"SELECT * FROM animals;";
      // MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      //
      // while (rdr.Read())
      // {
      //   string type = rdr.GetString(0);
      //   string name = rdr.GetString(1);
      //   string sex = rdr.GetString(2);
      //   string breed = rdr.GetString(3);
      //   string dateOfAdmittance = rdr.GetString(4);
      //
      //   if(!rdr.IsDBNull(13))
      //   {
      //     capitalId = rdr.GetInt32(13);
      //   }

      // if(!rdr.IsDBNull(12))
      // {
      //   if(rdr.GetString(12) == "")
      //   {
      //     headOfState = "The Lordess Almighty Reese Lee and her court jester minion Dustin";
      //   }
      // else
      // {
      //   headOfState = rdr.GetString(12);
      // }

      //     Country newCountry = new Country(countryName, countryCode, population, capitalId, headOfState);
      //     allCountries.Add(newCountry);
      //   }
      //
      //   conn.Close();
      //
      //   if (conn != null)
      //   {
      //     conn.Dispose();
      //   }
      //
      return allAnimals;

    }
  }
}
