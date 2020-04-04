using Microsoft.AspNetCore.Mvc;
using ToDoListClient.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace ToDoListClient.Controllers
{
  public class ItemsController : Controller
  {
    public ActionResult Index()
    {
      List<Item> allItems = Item.GetItems();
      return View(allItems);
    }

    public ActionResult Create()
    {
      List<Category> catList = Category.GetCategories();
      ViewBag.CategoryId = new SelectList(catList, "CategoryId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Item item, int categoryId)
    {
      string jsonItem = JsonConvert.SerializeObject(item);
      var apiCallTask = ItemApiHelper.Post(jsonItem, categoryId);
      List<Item> allItems = Item.GetItems();
      return RedirectToAction("Index", allItems);
    }

    public ActionResult Details(int id)
    {
      var item = Item.GetDetails(id);
      // return RedirectToAction("Index");
      return View(item);
    }

    public ActionResult Edit(int id)
    {
      var item = Item.GetDetails(id);
      List<Category> catList = Category.GetCategories();
      ViewBag.CategoryId = new SelectList(catList, "CategoryId", "Name");
      return View(item);
    }

    [HttpPost]
    public ActionResult Edit(Item item, int CategoryId)
    {
      Item.Put(item, CategoryId);
      List<Item> allItems = Item.GetItems();
      return RedirectToAction("Index", allItems);
    }

    public ActionResult AddCategory(int id)
    {
      var item = Item.GetDetails(id);
      List<Category> catList = Category.GetCategories();
      ViewBag.CategoryId = new SelectList(catList, "CategoryId", "Name");
      return View(item);
    }

    [HttpPost]
    public ActionResult AddCategory(int itemId, int CategoryId)
    {
      Item.AddCategory(itemId, CategoryId);
      List<Item> allItems = Item.GetItems();
      return RedirectToAction("Index", allItems);
    }

    public ActionResult Delete(int id)
    {
      var item = Item.GetDetails(id);
      return View(item);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Item.Delete(id);
      List<Item> allItems = Item.GetItems();
      return RedirectToAction("Index", allItems);
    }

    // [HttpPost]
    // public ActionResult DeleteCategory(int joinId)
    // {
    //   var joinEntry = _db.CategoryItem.FirstOrDefault(entry => entry.CategoryItemId == joinId);
    //   _db.CategoryItem.Remove(joinEntry);
    //   _db.SaveChanges();
    //   return RedirectToAction("Index");
    // }
  }
}