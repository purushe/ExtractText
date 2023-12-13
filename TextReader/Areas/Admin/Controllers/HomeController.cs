using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using static TextReader.Utility.Constant;

namespace TextReader.Areas.Admin.Controllers
{
  [Area(AreaConstants.AdminArea)]
  [Authorize(Roles = "Admin")]
  public class HomeController : Controller
  {

    [HttpGet]
    [Route("/Admin/Home/Index")]
    public IActionResult Index()
    {
      return View();
    }
  }
}
