using Microsoft.AspNetCore.Mvc;
using RequirementsGrooming.Web.Models;
using System.Diagnostics;

namespace RequirementsGrooming.Web.Controllers;

public class HomeController : Controller
{
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
