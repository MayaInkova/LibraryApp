using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;


public class Program
{
    // Инициализирай API URL
    private static string apiUrl = "http://localhost:8080/books"; // Задай реален URL тук

    public static async Task Main(string[] args)
    {
        // Създаване на HttpClient
        using HttpClient client = new HttpClient();

        try
        {
            // Изпращане на GET заявка
            var response = await client.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                // Четене на съдържанието на отговора
                string books = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Books in database: {books}");
            }
            else
            {
                Console.WriteLine($"Error in GET request: {response.StatusCode}");
            }

            // Създаване на нова книга
            var newBook = new { title = "Foundation", author = "Isaac Asimov" };
            string jsonString = JsonSerializer.Serialize(newBook);
            Console.WriteLine("Sending new book data: " + jsonString);

            // Създаване на POST заявка с новата книга
            StringContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var responsePost = await client.PostAsync(apiUrl, content);

            if (responsePost.IsSuccessStatusCode)
            {
                Console.WriteLine("Successfully added new book!");
            }
            else
            {
                Console.WriteLine($"Error in POST request: {responsePost.StatusCode}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }

        Console.ReadLine();
    }
}