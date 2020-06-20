using System;
using DependencyInjectionExample.BusinessLogic;

namespace DependencyInjectionExample.Builder
{
	class DogBuilder : IPetBuilder
	{
		private IPet _dog;

		public DogBuilder()
		{
			Reset();
		}

		public void Reset()
		{
			_dog = new Dog();
		}

		public IPetBuilder SetName(string name)
		{
			_dog.Name = name;
			return this;
		}

		public IPetBuilder SetAge(int age)
		{
			_dog.Age = age;
			return this;
		}

		public IPetBuilder SetType(PetType type)
		{
			_dog.Type = type;
			return this;
		}

		public IPet GetPet()
		{
			IPet pet = _dog;
			Reset();
			return pet;
		}
	}
}
