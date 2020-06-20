using System;
using System.Collections.Generic;
using System.Text;
using DependencyInjectionExample.Persistence;

namespace DependencyInjectionExample.BusinessLogic
{
	class Pets
	{
		private readonly string _connectionString;
		private readonly PetManager _petManager;
		private IList<IPet> _pets;

		public Pets(string connectionString)
		{
			_connectionString = connectionString;
			_petManager = new PetManager(_connectionString);
			GetPets();
		}

		public void GetPets()
		{
			_pets = _petManager.GetPets();
		}

		public void DisplayPets()
		{
			foreach (var x in _pets)
			{
				Console.WriteLine(x.ToString());
			}
		}

		// Continued dependency injection
		public void SavePet(IPet pet)
		{
			_petManager.Save(pet);
		}
	}
}
