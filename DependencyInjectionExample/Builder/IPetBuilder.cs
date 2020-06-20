using System;
using DependencyInjectionExample.BusinessLogic;

namespace DependencyInjectionExample.Builder
{
	public interface IPetBuilder
	{
		void Reset();
		IPetBuilder SetName(string name);
		IPetBuilder SetAge(int age);
		IPetBuilder SetType(PetType type);
		IPet GetPet();
	}
}