using System;
using System.Collections.Generic;
using System.Data;
using DependencyInjectionExample.BusinessLogic;
using DependencyInjectionExample.Factory;
using DependencyInjectionExample.Utilities;

namespace DependencyInjectionExample.Persistence
{
	public class PetManager
	{
		protected readonly string _connectionString;
		protected List<IPet> _pets;

		public PetManager(string connectionString)
		{
			_connectionString = connectionString;
			_pets = new List<IPet>();
		}

		public List<IPet> GetPets()
		{
			using var connection = _connectionString.CreateConnection();
			var command = connection.CreateCommand();
			command.CommandText = "select * from Pet";

			var petData = command.GetDataTable().Select();
			
			foreach (var pet in petData)
			{
				_pets.Add(CreatePet(pet));
			}
			return _pets;
		}

		private IPet CreatePet(DataRow data)
		{
			IPet pet;
			switch (Enum.Parse<PetType>((string)data["Type"]))
			{
				case PetType.Dog:
					pet = new DogFactory().GetPet((string)data["Name"], Int32.Parse((string)data["Age"]), Enum.Parse<PetType>((string)data["Type"]));
					break;
				case PetType.Cat:
					pet = new CatFactory().GetPet((string)data["Name"], Int32.Parse((string)data["Age"]), Enum.Parse<PetType>((string)data["Type"]));
					break;
				default:
					pet = null;
					break;
			}
			return pet;
		}

		// Where the dependency injection ends
		public void Save(IPet pet)
		{
			using var connection = _connectionString.CreateConnection();
			connection.Open();

			var command = connection.CreateCommand();
			command.CommandText =
				"insert into Pet (Name, Age, Type) values (@name, @age, @type)";
			command.Parameters.AddWithValue("name", pet.Name);
			command.Parameters.AddWithValue("age", pet.Age);
			command.Parameters.AddWithValue("type", pet.Type);

			command.ExecuteNonQuery();
		}
	}
}
