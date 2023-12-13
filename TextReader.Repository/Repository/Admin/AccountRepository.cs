using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using TextReader.Data.Database;
using TextReader.Data.Entity;
using TextReader.Repository.IRepository.Admin;
using TextReader.RepositoryModel.RepositoryModel;
using TextReader.Utility;
using static TextReader.Utility.Constant;
using static TextReader.Utility.Response;

namespace TextReader.Repository.Repository.Admin
{
  public class AccountRepository : IAccountRepository
  {
    private readonly UserManager<ApplicationUser> userManager;
    private readonly SignInManager<ApplicationUser> signInManager;
    private readonly RoleManager<IdentityRole> roleManager;

    public AccountRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager)
    {
      this.userManager = userManager;
      this.signInManager = signInManager;
      this.roleManager = roleManager;
    }

    public async Task<ResponseData<LoginRepositoryModel>> LoginAsync(LoginRepositoryModel model)
    {
      var responseData = new ResponseData<LoginRepositoryModel>();
      try
      {
        var data = new Login()
        {
          Email = model.Email,
          Password = model.Password,
        };
        var user = await userManager.FindByEmailAsync(data.Email);
        if (user == null)
        {
          responseData.Status = false;
          responseData.Message = Messages.Invalid;
          return responseData;
        }

        if (!await userManager.CheckPasswordAsync(user, data.Password))
        {
          responseData.Status = false;
          responseData.Message = Messages.Invalid;
          return responseData;
        }

        var signInResult = await signInManager.PasswordSignInAsync(user, data.Password, false, true);
        if (signInResult.Succeeded)
        {
          var userRoles = await userManager.GetRolesAsync(user);
          var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Email),
                };

          foreach (var userRole in userRoles)
          {
            authClaims.Add(new Claim(ClaimTypes.Role, userRole));
          }
          responseData.Status = true;
          responseData.Message = Messages.Login;
        }
        else if (signInResult.IsLockedOut)
        {
          responseData.Status = false;
          responseData.Message = Messages.Lockout;
        }
        else
        {
          responseData.Status = false;
          responseData.Message = Messages.Failed;
        }


      }
      catch
      {
        responseData.Status = false;
        responseData.Message = Messages.Error;
      }
      return responseData;
    }

    public async Task LogoutAsync()
    {
      await signInManager.SignOutAsync();
    }

    public async Task<ResponseData<RegistrationRepositoryModel>> RegisterAsync(RegistrationRepositoryModel model)
    {
      var responseData = new ResponseData<RegistrationRepositoryModel>();
      try
      {
        var data = new Registration()
        {
          FirstName = model.FirstName,
          LastName = model.LastName,
          Email = model.Email,
          UserName = model.UserName,
          Password = model.Password,
          ConfirmPassword = model.ConfirmPassword,
          MobileNumber = model.MobileNumber,

        };
        var userExists = await userManager.FindByEmailAsync(data.Email);
        if (userExists != null)
        {
          responseData.Status = false;
          responseData.Message = Messages.AlreadyExist;
          return responseData;
        }
        ApplicationUser user = new ApplicationUser()
        {
          Email = data.Email,
          SecurityStamp = Guid.NewGuid().ToString(),
          UserName = data.UserName,
          FirstName = data.FirstName,
          LastName = data.LastName,
          PhoneNumberConfirmed = true,
          PhoneNumber = data.MobileNumber,

        };
        var result = await userManager.CreateAsync(user, data.Password);
        if (!result.Succeeded)
        {
          responseData.Status = false;
          responseData.Message = Messages.Failed;
          return responseData;
        }
        if (!await roleManager.RoleExistsAsync(Role.Admin))
          await roleManager.CreateAsync(new IdentityRole(Role.Admin));

        if (await roleManager.RoleExistsAsync(Role.Admin))
        {
          await userManager.AddToRoleAsync(user, Role.Admin);
        }
        if (result.Succeeded)
        {
          responseData.Status = true;
          responseData.Message = Messages.Register;
        }
        else
        {
          responseData.Status = false;
          responseData.Message = Messages.Failed;
        }
      }
      catch
      {
        responseData.Status = false;
        responseData.Message = Messages.Error;
      }
      return responseData;
    }
  }
}
