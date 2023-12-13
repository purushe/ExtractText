using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TextReader.Areas.Admin.Models;
using TextReader.Repository.IRepository.Admin;
using TextReader.RepositoryModel.RepositoryModel;
using static TextReader.Utility.Constant;

namespace TextReader.Areas.Admin.Controllers
{
  [Area(AreaConstants.AdminArea)]
  public class AccountController : Controller
  {
    private readonly IAccountRepository accountRepository;
    public AccountController(IAccountRepository accountRepository)
    {
      this.accountRepository = accountRepository;
    }

    [HttpGet]
    [Route("Admin/Account/Login")]
    public IActionResult Login()
    {
      return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
      if (!ModelState.IsValid)
      {
        return View(model);
      }
      var EntityModel = new LoginRepositoryModel()
      {
        Email = model.Email,
        Password = model.Password,
      };
      var user = await accountRepository.LoginAsync(EntityModel);
      if (user.Status == true)
      {
        return RedirectToAction("Index", "Home", new { area = "Admin" });
      }
      else
      {
        return RedirectToAction("Login", "Account", new { area = "Admin" });
      }
    }

    [Route("Admin/Account/Logout")]
    public async Task<IActionResult> Logout()
    {
      await accountRepository.LogoutAsync();
      return RedirectToAction("Login", "Account", new { area = "Admin" });
    }

    //[HttpGet]
    //[Route("Admin/Account/Registration")]
    //public IActionResult Registration()
    //{
    //    return View();
    //}

    //[HttpPost]
    //public async Task<IActionResult> Registration(RegistrationViewModel model)
    //{
    //    if (!ModelState.IsValid)
    //    {
    //        return View(model);
    //    }
    //    var EntityModel = new RegistrationRepositoryModel()
    //    {
    //        Email = model.Email,
    //        ConfirmPassword = model.ConfirmPassword,
    //        FirstName = model.FirstName,
    //        LastName = model.LastName,
    //        MobileNumber = model.PhoneNumber,
    //        Password = model.Password,
    //        UserName = model.UserName,

    //    };
    //    var user = await accountRepository.RegisterAsync(EntityModel);
    //    if (user.Status == true)
    //    {
    //        return RedirectToAction("Login", "Account");
    //    }
    //    else
    //    {
    //        return RedirectToAction("Registration", "Account");
    //    }
    //}
  }
}
