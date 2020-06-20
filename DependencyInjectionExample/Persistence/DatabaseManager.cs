using System.IO;
using DependencyInjectionExample.Utilities;

namespace DependencyInjectionExample.Persistence
{
	public static class DatabaseManager
	{
		public static void CreateTables(string connectionString)
		{
			using var connection = connectionString.CreateConnection();
			connection.Open();

			var command = connection.CreateCommand();
			command.CommandText = File.ReadAllText("Sql/CreateTables.sql");
			command.ExecuteNonQuery();
		}

		public static void InsertDummyData(string connectionString)
		{
			using var connection = connectionString.CreateConnection();
			connection.Open();

			var command = connection.CreateCommand();
			command.CommandText = File.ReadAllText("Sql/InsertDataIntoPets.sql");
			command.ExecuteNonQuery();
		}
	}
}
