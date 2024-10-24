using System.Diagnostics;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using SV21T1020712.BusinessLayers;
using SV21T1020712.DomainModels;
using SV21T1020712.Web.Models;

namespace SV21T1020712.Web.Controllers;
public class SupplierController : Controller
{
  public const int PAGE_SIZE = 10;
  public IActionResult Index(int page = 1, string searchValue = "")
  {
    int rowCount;
    var data = CommonDataService.ListOfSuppliers(out rowCount, page, PAGE_SIZE, searchValue ?? "");
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
    ViewBag.Title = "Bổ sung thông tin nhà cung cấp";
    var data = new Supplier()
    {
      SupplierID = 0
    };
    return View("Edit", data);
  }
  public IActionResult Edit(int id = 0)
  {
    ViewBag.Title = "Chỉnh sửa thông tin nhà cung cấp";
    var data = CommonDataService.GetSupplier(id);
    if (data == null)
    {
      return RedirectToAction("Index");
    }
    return View(data);
  }
  public IActionResult Delete(int id = 0)
  {
    ViewBag.Title = "Xoá thông tin nhà cung cấp";
    if (Request.Method == "POST")
    {
      CommonDataService.DeleteSupplier(id);
      return RedirectToAction("Index");

    }
    var data = CommonDataService.GetSupplier(id);
    if (data == null)
    {
      return RedirectToAction("Index");
    }
    return View(data);
  }
  [HttpPost]
  public IActionResult Save(Supplier data)
  {
    if (data.SupplierID == 0)
    {
      CommonDataService.AddSupplier(data);
    }
    else
    {
      CommonDataService.UpdateSupplier(data);
    }
    return RedirectToAction("Index");
  }


}