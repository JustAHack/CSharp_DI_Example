using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjectionExample.BusinessLogic
{
	class Cat : Pet
	{
		public override void Speak()
		{
			Console.WriteLine("Meow...purr...");
		}
	}
}
