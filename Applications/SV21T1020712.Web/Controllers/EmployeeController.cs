
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
    var data = new Employee()
    {
      EmployeeID = 0,
      IsWorking = true,
      Photo = "nophoto.png"
    };
    return View("Edit", data);
  }
  public IActionResult Edit(int id = 0)
  {
    ViewBag.Title = "Chỉnh sửa thông tin nhân viên";
    var data = CommonDataService.GetEmployee(id);
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
      CommonDataService.DeleteEmployee(id);
      return RedirectToAction("Index");
    }
    ViewBag.Title = "Xoá thông tin nhân viên";
    var data = CommonDataService.GetEmployee(id);
    if (data == null)
    {
      return RedirectToAction("Index");
    }
    return View(data);
  }

  [HttpPost]
  public IActionResult Save(Employee data, string _BirthDate, IFormFile? _Photo)
  {
    //Xử lí cho ngày sinh
    DateTime? d = _BirthDate.ToDateTime();
    if (d.HasValue)
      data.BirthDate = d.Value;
    //Xử lí với ảnh
    if (_Photo != null)
    {
      string fileName = $"{DateTime.Now.Ticks}-{_Photo.FileName}";
      string filePath = Path.Combine(ApplicationContext.WebRootPath, @"images/employees", fileName);
      using (var stream = new FileStream(filePath, FileMode.Create))
      {
        _Photo.CopyTo(stream);
      }
      data.Photo = fileName;
    }
    if (data.EmployeeID == 0)
    {
      CommonDataService.AddEmployee(data);
    }
    else
    {
      CommonDataService.UpdateEmployee(data);
    }
    return RedirectToAction("Index");
  }

}