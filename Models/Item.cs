using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel;

namespace ToDoListClient.Models
{
    public class Item
    {
        // public Item()
        // {
        //     this.Categories = new HashSet<CategoryItem>();
        // }

        public int ItemId { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        public List<CategoryItem> Categories { get;} = new List<CategoryItem>();

        public static List<Item> GetItems()
        {
        var apiCallTask = ItemApiHelper.GetAll();
        var result = apiCallTask.Result;

        JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
        List<Item> itemList = JsonConvert.DeserializeObject<List<Item>>(jsonResponse.ToString());

        return itemList;
        }

        public static Item GetDetails(int id)
        {
        var apiCallTask = ItemApiHelper.Get(id);
        var result = apiCallTask.Result;

        JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
        // foreach(PropertyDescriptor descriptor in TypeDescriptor.GetProperties(jsonResponse))
        // {
            
        //     string name=descriptor.Name; 
        //     object value=descriptor.GetValue(jsonResponse);
        //     System.Console.WriteLine("{0}={1}",name,value);
        // }

        Item item = JsonConvert.DeserializeObject<Item>(jsonResponse.ToString());

        return item;
        }

        public static void Post(Item item, int categoryId)
        {
        string jsonItem = JsonConvert.SerializeObject(item);
        var apiCallTask = ItemApiHelper.Post(jsonItem, categoryId);
        }

        public static void Put(Item item, int categoryId)
        {
        string jsonItem = JsonConvert.SerializeObject(item);
        var apiCallTask = ItemApiHelper.Put(item.ItemId, jsonItem, categoryId);
        }

        public static void Delete(int id)
        {
        var apiCallTask = ItemApiHelper.Delete(id);
        }

        public static void AddCategory(int itemId, int categoryId)
        {
        var apiCallTask = ItemApiHelper.AddCategory(itemId, categoryId);
        }
    }
}