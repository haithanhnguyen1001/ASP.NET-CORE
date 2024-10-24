using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SV21T1020712.BusinessLayers;
using SV21T1020712.DomainModels;
using SV21T1020712.Web.Models;

namespace SV21T1020712.Web.Controllers;
public class CategoryController : Controller
{
  public const int PAGE_SIZE = 10;
  public IActionResult Index(int page = 1, string searchValue = "")
  {
    int rowCount;
    var data = CommonDataService.ListOfCategories(out rowCount, page, PAGE_SIZE, searchValue ?? "");
    int pageCount = rowCount / PAGE_SIZE;
    if (rowCount % PAGE_SIZE > 0)
    {
      pageCount += 1;
    }
    ViewBag.Page = page;
    ViewBag.RowCount = rowCount;
    ViewBag.PageCount = pageCount;
    ViewBag.SearchValue = searchValue;
    return View(data);

  }
  public IActionResult Create()
  {
    ViewBag.Title = "Bổ sung thông tin loại hàng";
    var data = new Category()
    {
      CategoryID = 0
    };
    return View("Edit", data);
  }
  public IActionResult Edit(int id = 0)
  {
    ViewBag.Title = "Chỉnh sửa thông tin loại hàng";
    var data = CommonDataService.GetCategory(id);
    if (data == null)
    {
      return RedirectToAction("Index");
    }
    return View(data);
  }
  public IActionResult Delete(int id = 0)
  {
    ViewBag.Title = "Xoá thông tin loại hàng";
    if (Request.Method == "POST")
    {
      CommonDataService.DeleteCategory(id);
      return RedirectToAction("Index");
    }
    var data = CommonDataService.GetCategory(id);
    if (data == null)
    {
      return RedirectToAction("Index");
    }
    return View(data);
  }

  [HttpPost]
  public IActionResult Save(Category data)
  {
    if (data.CategoryID == 0)
    {
      CommonDataService.AddCategory(data);
    }
    else
    {
      CommonDataService.UpdateCategory(data);
    }
    return RedirectToAction("Index");
  }

}