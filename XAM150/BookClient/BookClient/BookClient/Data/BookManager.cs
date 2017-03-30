using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.IO;
namespace BookClient.Data
{
    public class BookManager
    {
		//  Base address of the service
		const string Url = "http://xam150.azurewebsites.net/api/books/";

		//  To hold the token that will be required to pass with all requests
		private string authorizationKey;

		//  Get a list of books
        public async Task<IEnumerable<Book>> GetAll()
        {
			//  Get the HttpClient
			HttpClient httpClient = await GetClient();

			//  Make the call and wait for the result
			string result = await httpClient.GetStringAsync(Url);

			//  Returns an array of books.  So, we convert the JSON to that
			IEnumerable<Book> json = JsonConvert.DeserializeObject<IEnumerable<Book>>(result);

			return json;

        }

		//  Add a new book to our collection
		public async Task<Book> Add(string title, string author, string genre)
		{
			//  First create the Book object
			Book newBook = new Book()
			{
				Title = title,
				Authors = new List<string>(new[] { author }),
				Genre = genre,
				ISBN = string.Empty,
				PublishDate = DateTime.Now.Date,
			};

			//  Get the HttpClient
			HttpClient httpClient = await GetClient();

			//  Convert the Book object to JSON
			string bookJson = JsonConvert.SerializeObject(newBook);
			//  Populate the content of the HttpClient with the JSON and set some encoding
			HttpContent content = new StringContent(bookJson, Encoding.UTF8, "application/json");

			//  Post the request and wait for the response
			HttpResponseMessage result = await httpClient.PostAsync(Url, content);

			//  Take the response content and read it as a string
			string responseContent = await result.Content.ReadAsStringAsync();

			//  Convert the response string back to a book object
			Book addedBook = JsonConvert.DeserializeObject<Book>(responseContent);

			//  Return the new book.
			return addedBook;

			//  Another way to do this as per the instructions
			/*
			Book book = new Book() {
		        Title = title,
		        Authors = new List<string>(new[] { author }),
		        ISBN = string.Empty,
		        Genre = genre,
		        PublishDate = DateTime.Now.Date,
		    };

		    HttpClient client = await GetClient();
		    var response = await client.PostAsync(Url, 
		        new StringContent(
		            JsonConvert.SerializeObject(book), 
		            Encoding.UTF8, "application/json"));

		    return JsonConvert.DeserializeObject<Book>(
		        await response.Content.ReadAsStringAsync());  
			  
			 */

		}

		//  Updated book.
        public async Task Update(Book book)
        {
			//  Get the HttpClient
			HttpClient httpClient = await GetClient();

			//  Serialize the book
			string bookJson = JsonConvert.SerializeObject(book);

			//  Setup the content for sending
			HttpContent content = new StringContent(bookJson, Encoding.UTF8, "application/json");

			//  Make the call.  Including Url and content
			//  Note that the methid returns a Task.  When doing this you do not
			//  need to specify the 'return' keyword'
			await httpClient.PutAsync(Url + book.ISBN, content);

		}

		//  Deleted book.
        public async Task Delete(string isbn)
        {
			//  Get the client like usual
			HttpClient httpClient = await GetClient();

			//  Mwke the call and return the result.
			await httpClient.DeleteAsync(Url + isbn);

		}

		//  Set up the Http Client.  Also retrieve the authorizationKey if it is
		//  not already set
		private async Task<HttpClient> GetClient()
		{
			//  New HttpClient
			HttpClient httpClient = new HttpClient();

			//  Do authorization code yet?  Then get it
			if (string.IsNullOrEmpty(authorizationKey))
			{
				authorizationKey = await httpClient.GetStringAsync(Url + "login");
				authorizationKey = JsonConvert.DeserializeObject<string>(authorizationKey);
			}

			//  Set defaults to make sure that all subsequent calls are sent with this
			//  information
			httpClient.DefaultRequestHeaders.Add("Authorization", authorizationKey);
			httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

			return httpClient;
		}
    }
}

