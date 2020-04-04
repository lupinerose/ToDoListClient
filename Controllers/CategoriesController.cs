using Microsoft.AspNetCore.Mvc;
using ToDoListClient.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ToDoListClient.Controllers
{
  public class CategoriesController : Controller
  {
    public ActionResult Index()
    {
      List<Category> catList = Category.GetCategories();
      return View(catList);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Category category)
    {
      Category.Post(category);
      List<Category> catList = Category.GetCategories();
      return RedirectToAction("Index", catList);
    }

    public ActionResult Details(int id)
    {
      var cat = Category.GetDetails(id);
      return View(cat);
    }

    public ActionResult Edit(int id)
    {
      var cat = Category.GetDetails(id);
      return View(cat);
    }

    [HttpPost]
    public ActionResult Edit(Category category, int categoryId)
    {
      Category.Put(category, categoryId);
      List<Category> catList = Category.GetCategories();
      return RedirectToAction("Index", catList);
    }

    public ActionResult Delete(int id)
    {
      var cat = Category.GetDetails(id);
      return View(cat);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Category.Delete(id);
      List<Category> catList = Category.GetCategories();
      return RedirectToAction("Index", catList);
    }
  }
}