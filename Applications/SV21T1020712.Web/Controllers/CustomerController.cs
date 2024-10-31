using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SV21T1020712.BusinessLayers;
using SV21T1020712.DomainModels;
using SV21T1020712.Web.Models;

namespace SV21T1020712.Web.Controllers;
public class CustomerController : Controller
{
  private const int PAGE_SIZE = 20;
  private const string CUSTOMER_SEARCH_CONDITION = "CustomerSearchCondition";
  // public IActionResult Index(int page = 1, string searchValue = "")
  // {
  //   int rowCount;
  //   var data = CommonDataService.ListOfCustomers(out rowCount, page, PAGE_SIZE, searchValue ?? "");
  //   int pageCount = 1;
  //   pageCount = rowCount / PAGE_SIZE;
  //   if (rowCount % PAGE_SIZE > 0)
  //   {
  //     pageCount += 1;
  //   }
  //   ViewBag.Page = page;
  //   ViewBag.RowCount = rowCount;
  //   ViewBag.PageCount = pageCount;
  //   ViewBag.SearchValue = searchValue;
  //   return View(data);
  // }

  public IActionResult Index()
  {
    PaginationSearchInput? condition = ApplicationContext.GetSessionData<PaginationSearchInput>(CUSTOMER_SEARCH_CONDITION);
    if (condition == null)
      condition = new PaginationSearchInput()
      {
        Page = 1,
        PageSize = PAGE_SIZE,
        SearchValue = ""
      };
    return View(condition);
  }

  public IActionResult Search(PaginationSearchInput condition)
  {
    int rowCount;
    var data = CommonDataService.ListOfCustomers(out rowCount, condition.Page, condition.PageSize, condition.SearchValue ?? "");
    CustomerSearchResult model = new CustomerSearchResult()
    {
      Page = condition.Page,
      PageSize = condition.PageSize,
      SearchValue = condition.SearchValue ?? "",
      RowCount = rowCount,
      Data = data
    };

    ApplicationContext.SetSessionData(CUSTOMER_SEARCH_CONDITION, condition);
    return View(model);
  }

  public IActionResult Create()
  {
    ViewBag.Title = "Bổ sung khách hàng mới";
    var data = new Customer()
    {
      CustomerID = 0,
      IsLocked = false,
    };

    return View("Edit", data);
  }

  public IActionResult Edit(int id = 0)
  {
    ViewBag.Title = "Cập nhật thông tin khách hàng";
    var data = CommonDataService.GetCustomer(id);
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
      CommonDataService.DeleteCustomer(id);
      return RedirectToAction("Index");
    }
    ViewBag.Title = "Xoá thông tin khách hàng";
    var data = CommonDataService.GetCustomer(id);
    if (data == null)
    {
      return RedirectToAction("Index");
    }
    return View(data);
  }

  [HttpPost]
  public IActionResult Save(Customer data)
  {
    if (data.CustomerID == 0)
    {
      CommonDataService.AddCustomer(data);
    }
    else
    {
      CommonDataService.UpdateCustomer(data);
    }
    return RedirectToAction("Index");
  }

}