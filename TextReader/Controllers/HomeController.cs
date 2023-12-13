using Microsoft.AspNetCore.Mvc;

namespace TextReader.Controllers
{
  public class HomeController : Controller
  {
    [HttpGet]
    public IActionResult Index()
    {
      return View();
    }
  }
}
