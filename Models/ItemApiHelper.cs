using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;
using System.ComponentModel;


namespace ToDoListClient.Models
{
    public class ItemApiHelper
    {
        public static async Task<string> GetAll()
      {
        RestClient client = new RestClient("http://localhost:5000/api");
        RestRequest request = new RestRequest($"items", Method.GET);
        var response = await client.ExecuteTaskAsync(request);
        return response.Content;
      }

      public static async Task<string> Get(int id)
      {
        RestClient client = new RestClient("http://localhost:5000/api");
        RestRequest request = new RestRequest($"items/{id}", Method.GET);
        var response = await client.ExecuteTaskAsync(request);
        // foreach(PropertyDescriptor descriptor in
        // TypeDescriptor.GetProperties(response))
        // {
            
        //     string name=descriptor.Name; 
        //     object value=descriptor.GetValue(response);
        //     System.Console.WriteLine("{0}={1}",name,value);
        // }
        return response.Content;
      }

      public static async Task Post(string newItem, int categoryId)
      {
        RestClient client = new RestClient("http://localhost:5000/api");
        RestRequest request = new RestRequest($"items?categoryId={categoryId}", Method.POST);
        request.AddHeader("Content-Type", "application/json");
        request.AddJsonBody(newItem);
        var response = await client.ExecuteTaskAsync(request);
      }

      public static async Task Put(int id, string newItem, int categoryId)
      {
        RestClient client = new RestClient("http://localhost:5000/api");
        RestRequest request = new RestRequest($"items/{id}?categoryId={categoryId}", Method.PUT);
        request.AddHeader("Content-Type", "application/json");
        request.AddJsonBody(newItem);
        var response = await client.ExecuteTaskAsync(request);
      }

      public static async Task Delete(int id)
      {
        RestClient client = new RestClient("http://localhost:5000/api");
        RestRequest request = new RestRequest($"items/{id}", Method.DELETE);
        request.AddHeader("Content-Type", "application/json");
        var response = await client.ExecuteTaskAsync(request);
      }

      public static async Task AddCategory(int itemId, int categoryId)
      {
        RestClient client = new RestClient("http://localhost:5000/api");
        RestRequest request = new RestRequest($"items/{itemId}/add_category/{categoryId}", Method.POST);
        request.AddHeader("Content-Type", "application/json");
        var response = await client.ExecuteTaskAsync(request);
      }
    }
}