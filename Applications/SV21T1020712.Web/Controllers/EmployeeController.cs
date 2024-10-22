
using Microsoft.AspNetCore.Mvc;
using SV21T1020712.BusinessLayers;
using SV21T1020712.DomainModels;

namespace SV21T1020712.Web.Controllers;
public class EmployeeController : Controller
{
  public const int PAGE_SIZE = 9;
  public IActionResult Index(int page = 1, string searchValue = "")
  {
    int rowCount;
    var data = CommonDataService.ListOfEmployees(out rowCount, page, PAGE_SIZE, searchValue ?? "");
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
    ViewBag.Title = "Bổ sung thông tin nhân viên";
    return View();
  }
  public IActionResult Edit(int id = 0)
  {
    ViewBag.Title = "Chỉnh sửa thông tin nhân viên";
    return View();
  }
  public IActionResult Delete(int id = 0)
  {
    ViewBag.Title = "Xoá thông tin nhân viên";
    return View();
  }
}