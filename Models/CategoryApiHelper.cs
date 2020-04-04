using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;

namespace ToDoListClient.Models
{
    public class CategoryApiHelper
    {
        public static async Task<string> GetAll()
        {
        RestClient client = new RestClient("http://localhost:5000/api");
        RestRequest request = new RestRequest($"categories", Method.GET);
        var response = await client.ExecuteTaskAsync(request);
        return response.Content;
        }

        public static async Task<string> Get(int id)
        {
        RestClient client = new RestClient("http://localhost:5000/api");
        RestRequest request = new RestRequest($"categories/{id}", Method.GET);
        var response = await client.ExecuteTaskAsync(request);
        return response.Content;
        }

        public static async Task Post(string newCategory)
        {
        RestClient client = new RestClient("http://localhost:5000/api");
        RestRequest request = new RestRequest($"Categories", Method.POST);
        request.AddHeader("Content-Type", "application/json");
        request.AddJsonBody(newCategory);
        var response = await client.ExecuteTaskAsync(request);
        }

        public static async Task Put(string newCategory, int id)
        {
        RestClient client = new RestClient("http://localhost:5000/api");
        RestRequest request = new RestRequest($"Categories/{id}", Method.PUT);
        request.AddHeader("Content-Type", "application/json");
        request.AddJsonBody(newCategory);
        var response = await client.ExecuteTaskAsync(request);
        }

        public static async Task Delete(int id)
        {
        RestClient client = new RestClient("http://localhost:5000/api");
        RestRequest request = new RestRequest($"categories/{id}", Method.DELETE);
        request.AddHeader("Content-Type", "application/json");
        var response = await client.ExecuteTaskAsync(request);
        }
    }
}