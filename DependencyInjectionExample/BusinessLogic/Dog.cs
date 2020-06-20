using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjectionExample.BusinessLogic
{
	class Dog : Pet
	{
		public override void Speak()
		{
			Console.WriteLine("Woof woof!");
		}
	}
}
