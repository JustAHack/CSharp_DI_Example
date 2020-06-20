using System;
using System.Collections.Generic;
using System.Text;
using DependencyInjectionExample.BusinessLogic;
using DependencyInjectionExample.Factory;
using DependencyInjectionExample.Persistence;
using DependencyInjectionExample.Utilities;

namespace DependencyInjectionExample
{
	public class Menu
	{
		private readonly Pets _pets;

		public Menu(string connectionString)
		{
			_pets = new Pets(connectionString);
		}

		public void Run()
		{
			while (true)
			{
				Console.Write(
@"Dependency Injection Example
================================
1. Display Pets
2. Add a Pet
3. Quit

Enter an option: ");

				var input = Console.ReadLine();
				Console.WriteLine();

				if (!int.TryParse(input, out var option) || !option.IsInRange(1, 3))
				{
					Console.WriteLine("Invalid input.");
					Console.WriteLine();
					continue;
				}

				switch (option)
				{
					case 1:
						DisplayPets();
						break;
					case 2:
						SavePet();
						break;
					case 3:
						Console.WriteLine("Good bye!");
						return;
					default:
						throw new InvalidOperationException();
				}
			}
		}

		private void SavePet()
		{
			IPet pet;

			Console.WriteLine("Please enter your pets name:");
			var name = Console.ReadLine();
			Console.WriteLine();

			Console.WriteLine("Please enter your pets age:");
			var age = Console.ReadLine();
			Console.WriteLine();

			if (!int.TryParse(age, result: out var option) || !option.IsInRange(1, 20))
			{
				Console.WriteLine("Invalid input.");
				Console.WriteLine();
				return;
			}

			Console.WriteLine("Please enter what type of pet it is (0 for dog, 1 for cat):");
			var type = Console.ReadLine();
			Console.WriteLine();

			if (!int.TryParse(type, result: out option) || !option.IsInRange(0, 1))
			{
				Console.WriteLine("Invalid input.");
				Console.WriteLine();
				return;
			}

			// A problem I have is there is now two places where I am deciding to create a pet. Is this wrong? It feels wrong. 
			// I both decide here (when passing to the PetManager) and within the PetManager if I get pets from the database.
			// Would it be better to just pass the parameters themselves instead of creating an object then passing it?
			// I have been struggling a little bit with the Factory Method and where to put the switch statement, because I feel its needed
			// to determine which type of pet to create. Ultimately I feel that I want to go down the path of Dependency injection however
			// with the example I have shown here, it requires adjustment or a better understanding of the factory method.
			switch (Enum.Parse<PetType>(type))
			{
				case PetType.Dog:
					pet = new DogFactory().GetPet(name, Int32.Parse(age), Enum.Parse<PetType>(type.ToString()));
					break;
				case PetType.Cat:
					pet = new CatFactory().GetPet(name, Int32.Parse(age), Enum.Parse<PetType>(type.ToString()));
					break;
				default:
					pet = null;
					break;
			}

			// Our dependency injection begins here.
			_pets.SavePet(pet);
			// Update pets list after saving a new pet.
			_pets.GetPets();
		}

		private void DisplayPets()
		{
			_pets.DisplayPets();
		}
	}
}