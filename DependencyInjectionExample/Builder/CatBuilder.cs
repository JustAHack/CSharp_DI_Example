using DependencyInjectionExample.BusinessLogic;

namespace DependencyInjectionExample.Builder
{
	class CatBuilder : IPetBuilder
	{
		private IPet _cat;

		public CatBuilder()
		{
			Reset();
		}

		public void Reset()
		{
			_cat = new Cat();
		}

		public IPetBuilder SetName(string name)
		{
			_cat.Name = name;
			return this;
		}

		public IPetBuilder SetAge(int age)
		{
			_cat.Age = age;
			return this;
		}

		public IPetBuilder SetType(PetType type)
		{
			_cat.Type = type;
			return this;
		}

		public IPet GetPet()
		{
			IPet pet = _cat;
			Reset();
			return pet;
		}
	}
}
