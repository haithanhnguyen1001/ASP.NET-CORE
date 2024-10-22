using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SV21T1020712.Web.Models;

namespace SV21T1020712.Web.Controllers;
public class ProductController : Controller
{
  public IActionResult Index()
  {
    return View();
  }
  public IActionResult Create()
  {
    ViewBag.Title = "Bổ sung thông tin mặt hàng";
    return View("Edit");
  }
  public IActionResult Edit(int id = 0)
  {
    ViewBag.Title = "Chỉnh sửa thông tin mặt hàng";
    return View();
  }
  public IActionResult Delete(int id = 0)
  {
    ViewBag.Title = "Xoá thông tin mặt hàng";
    return View();
  }
  public IActionResult Photo(int id = 0, string method = "", int photoId = 0)
  {
    switch (method)
    {
      case "add":
        ViewBag.Title = "Bổ sung ảnh cho mặt hàng";
        return View();
      case "edit":
        ViewBag.Title = "Thay đổi ảnh của mặt hàng  ";
        return View();
      case "delete":
        return RedirectToAction("Edit", new { id = id });
      default:
        return RedirectToAction("Index");
    }
  }
  public IActionResult Attribute(int id = 0, string method = "", int attributeId = 0)
  {
    switch (method)
    {
      case "add":
        ViewBag.Title = "Bổ sung thuộc tính cho mặt hàng";
        return View();
      case "edit":
        ViewBag.Title = "Thay đổi thuộc tính của mặt hàng  ";
        return View();
      case "delete":
        return RedirectToAction("Edit", new { id = id });
      default:
        return RedirectToAction("Index");
    }
  }
}