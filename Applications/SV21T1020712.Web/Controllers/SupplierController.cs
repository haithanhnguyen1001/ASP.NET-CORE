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
  private const string SUPPLIER_SEARCH_CONDITION = "SupplierSearchCondition";
  public IActionResult Index()
  {
    PaginationSearchInput? condition = ApplicationContext.GetSessionData<PaginationSearchInput>(SUPPLIER_SEARCH_CONDITION);
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
    var data = CommonDataService.ListOfSuppliers(out rowCount, condition.Page, condition.PageSize, condition.SearchValue ?? "");

    SupplierSearchResult model = new SupplierSearchResult()
    {
      Page = condition.Page,
      PageSize = condition.PageSize,
      SearchValue = condition.SearchValue ?? "",
      RowCount = rowCount,
      Data = data
    };

    ApplicationContext.SetSessionData(SUPPLIER_SEARCH_CONDITION, condition);
    return View(model);
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
    ViewBag.Title = data.SupplierID == 0 ? "Bổ sung nhà cung cấp mới" : "Cập nhật thông tin nhà cung cấp";
    //Kiểm tra nếu dữ liệu đầu vào không hợp lệ thì tạo ra một thông báo lỗi và lưu trữ vào ModelState
    if (string.IsNullOrWhiteSpace(data.SupplierName))
      ModelState.AddModelError(nameof(data.SupplierName), "Tên nhà cung cấp không được để trống");

    if (string.IsNullOrWhiteSpace(data.ContactName))
      ModelState.AddModelError(nameof(data.ContactName), "Tên liên hệ không được để trống");

    if (string.IsNullOrWhiteSpace(data.Phone))
      ModelState.AddModelError(nameof(data.Phone), "Vui lòng nhập điện thoại của nhà cung cấp");
    if (string.IsNullOrWhiteSpace(data.Email))
      ModelState.AddModelError(nameof(data.Email), "Vui lòng nhập email của nhà cung cấp");
    if (string.IsNullOrWhiteSpace(data.Address))
      ModelState.AddModelError(nameof(data.Address), "Vui lòng nhập địa chỉ của nhà cung cấp");
    if (string.IsNullOrEmpty(data.Provice))
      ModelState.AddModelError(nameof(data.Provice), "Hãy chọn tỉnh/thành cho nhà cung cấp");
    //Dựa vào thuộc tính IsValid của ModelState để biết có tồn tại lỗi hay không?
    if (ModelState.IsValid == false)
    {
      return View("Edit", data);
    }

    try
    {
      if (data.SupplierID == 0)
      {
        int id = CommonDataService.AddSupplier(data);
        if (id <= 0)
        {
          ModelState.AddModelError(nameof(data.Email), "Email bị trùng");
          return View("Edit", data);
        }
      }
      else
      {
        bool result = CommonDataService.UpdateSupplier(data);
        if (result == false)
        {
          ModelState.AddModelError(nameof(data.Email), "Email bị trùng");
          return View("Edit", data);
        }
      }
      return RedirectToAction("Index");
    }
    catch
    {
      ModelState.AddModelError("Error", "Hệ thống tạm thời gián đoạn");
      return View("Edit");
    }
  }
}