using System.Collections.Generic;
using DependencyInjectionExample.BusinessLogic;

namespace DependencyInjectionExample.Factory
{
	public abstract class PetFactory
	{
		public IPet GetPet(string name, int age, PetType type)
		{
			IPet pet = CreatePet(name, age, type);
			return pet;
		}

		protected abstract IPet CreatePet(string name, int age, PetType type);
	}
}
