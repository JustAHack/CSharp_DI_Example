﻿using System;
using System.Collections.Generic;
using System.Text;
using DependencyInjectionExample.Builder;
using DependencyInjectionExample.BusinessLogic;

namespace DependencyInjectionExample.Factory
{
	class CatFactory : PetFactory
	{
		protected override IPet CreatePet(string name, int age, PetType type)
		{
			IPetBuilder bld = new CatBuilder();
			
			return bld.SetName(name)
				.SetAge(age)
				.SetType(type)
				.GetPet();
		}
	}
}
