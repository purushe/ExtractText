using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TextReader.Repository.IRepository.Admin;
using TextReader.Utility;
using static TextReader.Utility.Constant;

namespace TextReader.Areas.Admin.Controllers
{
  [Area(AreaConstants.AdminArea)]
  [Authorize(Roles = "Admin")]
  public class UserController : Controller
  {
    private readonly IUserAccountRepository userAccountRepository;
    public UserController(IUserAccountRepository userAccountRepository)
    {
      this.userAccountRepository = userAccountRepository;
    }

    [HttpGet]
    [Route("Admin/User/Index")]
    public IActionResult Index()
    {
      return View();
    }

    [HttpPost]
    [Route("Admin/User/GetList")]
    public IActionResult GetList(DTParameters param)
    {
      var result = userAccountRepository.GetList(param);
      return result.Status ? Json(result.Data) : Json(result);
    }
  }
}
