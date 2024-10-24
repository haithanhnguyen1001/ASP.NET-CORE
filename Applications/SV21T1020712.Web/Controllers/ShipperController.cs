using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SV21T1020712.BusinessLayers;
using SV21T1020712.DomainModels;
using SV21T1020712.Web.Models;

namespace SV21T1020712.Web.Controllers;
public class ShipperController : Controller
{
  public const int PAGE_SIZE = 2;
  public IActionResult Index(int page = 1, string searchValue = "")
  {
    int rowCount;
    var data = CommonDataService.ListOfShippers(out rowCount, page, PAGE_SIZE, searchValue ?? "");
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
    ViewBag.Title = "Bổ sung thông tin người giao hàng";
    var data = new Shipper()
    {
      ShipperID = 0
    };
    return View("Edit", data);
  }
  public IActionResult Edit(int id = 0)
  {
    ViewBag.Title = "Chỉnh sửa thông tin người giao hàng";
    var data = CommonDataService.GetShipper(id);
    if (data == null)
    {
      return RedirectToAction("Index");
    }
    return View(data);
  }
  public IActionResult Delete(int id = 0)
  {
    if (Request.Method == "POST")
    {
      CommonDataService.DeleteShipper(id);
      return RedirectToAction("Index");
    }
    ViewBag.Title = "Xoá thông tin người giao hàng";
    var data = CommonDataService.GetShipper(id);
    if (data == null)
    {
      return RedirectToAction("Index");
    }
    return View(data);
  }
  [HttpPost]
  public IActionResult Save(Shipper data)
  {
    if (data.ShipperID == 0)
    {
      CommonDataService.AddShipper(data);
    }
    else
    {
      CommonDataService.UpdateShipper(data);
    }
    return RedirectToAction("Index");
  }
}