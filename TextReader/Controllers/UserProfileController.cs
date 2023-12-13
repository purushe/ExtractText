using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TextReader.Models;
using TextReader.Repository.IRepository.User;

namespace TextReader.Controllers
{
  public class UserProfileController : Controller
  {
    private readonly IUserProfileRepository userProfileRepository;
    public UserProfileController(IUserProfileRepository userProfileRepository)
    {
      this.userProfileRepository = userProfileRepository;
    }

    [HttpGet]
    [Route("User/Profile")]
    public async Task<IActionResult> Index(string id)
    {
      var user = await userProfileRepository.GetById(id);
      if (user != null)
      {
        var EntityModel = new ProfileViewModel()
        {
          Email = user.Data.Email,
          FirstName = user.Data.FirstName,
          Id = user.Data.Id,
          LastName = user.Data.LastName,
          PhoneNumber = user.Data.MobileNumber,
          UserName = user.Data.UserName,
        };
        return View(EntityModel);
      }
      else
      {
        return RedirectToAction("Index", "Home");
      }
      
    }
  }
}
