using System;
using System.Collections.Generic;
using System.Linq;
using People.Models;
using SQLite;
using System.Threading.Tasks;

namespace People
{
	public class PersonRepository
	{
		public string StatusMessage { get; set; }

		private SQLiteAsyncConnection conn;

		public PersonRepository(string dbPath)
		{
			//  Establish new db connection
			conn = new SQLiteAsyncConnection(dbPath);

			// Create db table to store Person data
			//  Use Wait() to make this a blocking call to ensure
			//  table is created before constructor completes
			conn.CreateTableAsync<Person>().Wait();
				
		}

		public async Task AddNewPersonAsync(string name)
		{

			try
			{
				//basic validation to ensure a name was entered
				if (string.IsNullOrEmpty(name))
					throw new Exception("Valid name required");

				//  Insert a new person into the Person table
				var result = await conn.InsertAsync(new Person { Name = name });

				StatusMessage = string.Format("{0} record(s) added [Name: {1})", result, name);
			}
			catch (Exception ex)
			{
				StatusMessage = string.Format("Failed to add {0}. Error: {1}", name, ex.Message);
			}

		}

		public async Task<List<Person>> GetAllPeopleAsync()
		{
			//  Return list of all Persons
			return await conn.Table<Person>().ToListAsync();

		}
	}
}