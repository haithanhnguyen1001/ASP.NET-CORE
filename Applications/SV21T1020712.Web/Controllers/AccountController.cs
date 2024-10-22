using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SV21T1020712.Web.Models;

namespace SV21T1020712.Web.Controllers;
public class AccountController : Controller
{
  public IActionResult Login()
  {
    return View();
  }
  public IActionResult Logout()
  {
    return RedirectToAction("Login");
  }
  public IActionResult ChangePassword()
  {
    return View();
  }
}