using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SV21T1020712.Web.Models;

namespace SV21T1020712.Web.Controllers;
public class OrderController : Controller
{
  public IActionResult Index()
  {
    return View();
  }
  public IActionResult Create()
  {
    return View();
  }
  public IActionResult Details(int id = 0)
  {
    return View();
  }
  public IActionResult EditDetail(int id = 0, int productId = 0)
  {
    return View();
  }
  public IActionResult Shipping(int id = 0)
  {
    return View();
  }
}