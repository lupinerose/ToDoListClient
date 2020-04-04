using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ToDoListClient.Models
{
  public class Category
    {
        public Category()
        {
            this.Items = new HashSet<CategoryItem>();
        }

        public int CategoryId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<CategoryItem> Items { get; set; }

        public static List<Category> GetCategories()
        {
            var apiCallTask = CategoryApiHelper.GetAll();
            var result = apiCallTask.Result;

            JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
            List<Category> categoryList = JsonConvert.DeserializeObject<List<Category>>(jsonResponse.ToString());

            return categoryList;
        }

        public static void Post(Category cat)
        {
            string jsonItem = JsonConvert.SerializeObject(cat);
            var apiCallTask = CategoryApiHelper.Post(jsonItem);
        }

        public static Category GetDetails(int id)
        {
            var apiCallTask = CategoryApiHelper.Get(id);
            var result = apiCallTask.Result;

            JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
            Category category = JsonConvert.DeserializeObject<Category>(jsonResponse.ToString());

            return category;
        }

        public static void Put(Category category, int categoryId)
        {
            string jsonCategory = JsonConvert.SerializeObject(category);
            var apiCallTask = CategoryApiHelper.Put(jsonCategory, categoryId);
        }

        public static void Delete(int id)
        {
            var apiCallTask = CategoryApiHelper.Delete(id);
        }
    }
}