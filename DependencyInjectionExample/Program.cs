using System;
using DependencyInjectionExample.BusinessLogic;
using DependencyInjectionExample.Factory;
using DependencyInjectionExample.Persistence;
using Microsoft.Extensions.Configuration;

namespace DependencyInjectionExample
{
	class Program
	{
		static void Main(string[] args)
		{
			var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
			var connectionString = configuration["ConnectionString"];

			// Would it be a good idea to have a Facade do this type of thing? like running scripts
			// My confusion with the facade class only occurs due to not being sure if we can  
			// make calls to our own scripts etc, or if facades is strictly for 3rd party systems
			// and or systems that do not belong to the application we are creating

			// WARNING!!! READ ME!!
			// The CreateTable will drop any table named Pet then create a table named Pet
			DatabaseManager.CreateTables(connectionString);
			DatabaseManager.InsertDummyData(connectionString);
			new Menu(connectionString).Run();
		}
	}
}
