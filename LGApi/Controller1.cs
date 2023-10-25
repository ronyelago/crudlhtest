using Microsoft.AspNetCore.Mvc;

namespace LGTest;

public class Controller1 : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}