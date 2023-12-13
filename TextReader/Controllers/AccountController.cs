using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Threading.Tasks;
using TextReader.Models;
using TextReader.Repository.IRepository.User;
using TextReader.RepositoryModel.RepositoryModel;

namespace TextReader.Controllers
{
  public class AccountController : Controller
  {
    private readonly IUserRepository accountRepository;
    public AccountController(IUserRepository accountRepository)
    {
      this.accountRepository = accountRepository;
    }

    [HttpGet]
    [Route("Account/Login")]
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
        return RedirectToAction("Index", "Home");
      }
      else
      {
        return RedirectToAction("Login", "Account");
      }
    }

    [Route("Account/Logout")]
    public async Task<IActionResult> Logout()
    {
      await accountRepository.LogoutAsync();
      return RedirectToAction("Login", "Account");
    }

    [HttpGet]
    [Route("Account/Registration")]
    public IActionResult Registration()
    {
      return View();
    }

    [HttpPost]
    public async Task<IActionResult> Registration(RegistrationViewModel model)
    {
      if (!ModelState.IsValid)
      {
        return View(model);
      }
      var EntityModel = new RegistrationRepositoryModel()
      {
        Email = model.Email,
        ConfirmPassword = model.ConfirmPassword,
        FirstName = model.FirstName,
        LastName = model.LastName,
        MobileNumber = model.PhoneNumber,
        Password = model.Password,
        UserName = model.UserName,

      };
      var user = await accountRepository.RegisterAsync(EntityModel);
      if (user.Status == true)
      {
        return RedirectToAction("Login", "Account");
      }
      else
      {
        return RedirectToAction("Registration", "Account");
      }
    }

    [HttpGet]
    [Route("Account/ChangePassword")]
    public IActionResult ChangePassword()
    {
      return View();
    }

    [HttpPost]
    public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
    {
      if (!ModelState.IsValid)
      {
        return View(model);
      }

      var EntityModel = new ChangePasswordRepositoryModel()
      {
        ConfirmNewPassword = model.ConfirmNewPassword,
        CurrentPassword = model.CurrentPassword,
        NewPassword = model.NewPassword,
      };
      var Password = await accountRepository.ChangePasswordAsync(EntityModel);
      if (Password.Status == true)
      {
        return RedirectToAction("Index", "Home");
      }
      else
      {
        return RedirectToAction("ChangePassword", "Account");
      }

    }

    //[HttpGet("confirm-email")]
    //public async Task<IActionResult> ConfirmEmail(EmailConfirmationViewModel model)
    //{
    //  var EntityModel = new EmailConfirmationRepositoryModel()
    //  {
    //    Token = model.Token,
    //    UserId = model.UserId,
    //    Email = model.Email,
    //    EmailSent = model.EmailSent,
    //    EmailVerified = model.EmailVerified,
    //    IsConfirmed = model.IsConfirmed,
    //  };

    //  if (EntityModel != null)
    //  {
    //    model.Token = model.Token.Replace(' ', '+');
    //    var result = await accountRepository.ConfirmEmailAsync(EntityModel);
    //    if (result.)
    //    {
    //      model.EmailVerified = true;
    //    }
    //  }

    //  return View(model);
    //}

    //[HttpPost("confirm-email")]
    //public async Task<IActionResult> ConfirmEmail(EmailConfirmRepositoryModel model)
    //{

    //  var user = await accountRepository.GetUserByEmailAsync(model.Email);
    //  if (user != null)
    //  {
    //    if (user.EmailConfirmed)
    //    {
    //      model.EmailVerified = true;
    //      return View(model);
    //    }

    //    await userService.GenerateEmailConfirmationTokenAsync(user);
    //    model.EmailSent = true;
    //    ModelState.Clear();
    //  }
    //  else
    //  {
    //    ModelState.AddModelError("", "Something went wrong.");
    //  }
    //  return View(model);
    //}
  }
}
