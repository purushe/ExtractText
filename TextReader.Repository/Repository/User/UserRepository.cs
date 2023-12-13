using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using TextReader.Data.Database;
using TextReader.Data.Entity;
using TextReader.Repository.IRepository.Common;
using TextReader.Repository.IRepository.User;
using TextReader.Repository.Repository.Common;
using TextReader.RepositoryModel.RepositoryModel;
using TextReader.Utility;
using static TextReader.Utility.Constant;
using static TextReader.Utility.Response;

namespace TextReader.Repository.Repository.User
{
  public class UserRepository : IUserRepository
  {
    private readonly UserManager<ApplicationUser> userManager;
    private readonly SignInManager<ApplicationUser> signInManager;
    private readonly RoleManager<IdentityRole> roleManager;
    private readonly IMemberRepository memberRepository;
    private readonly IConfiguration configuration;
    private readonly IEmailRepository emailRepository;

    public UserRepository(
      UserManager<ApplicationUser> userManager,
      SignInManager<ApplicationUser> signInManager,
      RoleManager<IdentityRole> roleManager,
      IMemberRepository memberRepository,
      IConfiguration configuration,
      IEmailRepository emailRepository)
    {
      this.userManager = userManager;
      this.signInManager = signInManager;
      this.roleManager = roleManager;
      this.memberRepository = memberRepository;
      this.configuration = configuration;
      this.emailRepository = emailRepository;
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
        if (!await roleManager.RoleExistsAsync(Role.User))
          await roleManager.CreateAsync(new IdentityRole(Role.User));

        if (await roleManager.RoleExistsAsync(Role.User))
        {
          await userManager.AddToRoleAsync(user, Role.User);
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

    public async Task<ResponseData<ChangePasswordRepositoryModel>> ChangePasswordAsync(ChangePasswordRepositoryModel model)
    {
      var responseData = new ResponseData<ChangePasswordRepositoryModel>();
      try
      {
        var data = new ChangePassword()
        {
          ConfirmNewPassword = model.ConfirmNewPassword,
          CurrentPassword = model.CurrentPassword,
          NewPassword = model.NewPassword,
        };

        var userId = memberRepository.GetUserId();
        if (userId == null)
        {
          responseData.Status = false;
          responseData.Message = Messages.Invalid;
          return responseData;
        }

        var user = await userManager.FindByNameAsync(userId);
        if (user == null)
        {
          responseData.Status = false;
          responseData.Message = Messages.Invalid;
          return responseData;
        }

        var passwordValid = await userManager.CheckPasswordAsync(user, data.CurrentPassword);
        if (!passwordValid)
        {
          responseData.Status = false;
          responseData.Message = Messages.Invalid;
          return responseData;
        }

        var changePasswordResult = await userManager.ChangePasswordAsync(user, data.CurrentPassword, data.NewPassword);
        if (!changePasswordResult.Succeeded)
        {
          responseData.Status = false;
          responseData.Message = Messages.Failed;
          return responseData;
        }

        responseData.Status = true;
        responseData.Message = Messages.ChangePassword;
      }
      catch
      {
        responseData.Status = false;
        responseData.Message = Messages.Error;
      }

      return responseData;
    }

    public async Task<ResponseData<EmailConfirmationRepositoryModel>> ConfirmEmailAsync(EmailConfirmationRepositoryModel model)
    {
      var responseData = new ResponseData<EmailConfirmationRepositoryModel>();
      try
      {
        var data = new EmailConfirmation()
        {
          IsConfirmed = model.IsConfirmed,
          EmailVerified = model.EmailVerified,
          EmailSent = model.EmailSent,
          Email = model.Email,
          UserId = model.UserId,
          Token = model.Token,
        };

        var user = await userManager.FindByIdAsync(model.UserId);
        var token = model.Token;
        if (user != null && token != null)
        {
          var confirmResult = await userManager.ConfirmEmailAsync(user, token);
          if (confirmResult.Succeeded)
          {
            user.EmailConfirmed = true;
            responseData.Status = true;
            responseData.Message = Messages.Success;
          }
          else
          {
            responseData.Status = false;
            responseData.Message = Messages.Failed;
          }
        }
      }
      catch
      {
        responseData.Status = false;
        responseData.Message = Messages.Error;
      }
      return responseData;
    }

    public async Task<ResponseData<ApplicationUser>> GenerateEmailConfirmationTokenAsync(ApplicationUser user)
    {
      var responseData = new ResponseData<ApplicationUser>();
      try
      {
        var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
        if (token != null)
        {
          await SendEmailConfirmationEmail(user, token);
          responseData.Status = true;
          responseData.Message = Messages.Success;
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

    private async Task<ResponseData<ApplicationUser>> SendEmailConfirmationEmail(ApplicationUser user, string token)
    {
      var responseData = new ResponseData<ApplicationUser>();
      try
      {
        string appDomain = configuration.GetSection("Application:AppDomain").Value;
        string confirmationLink = configuration.GetSection("Application:EmailConfirmation").Value;

        if (string.IsNullOrEmpty(appDomain) && string.IsNullOrEmpty(confirmationLink))
        {
          EmailOptions options = new EmailOptions
          {
            ToEmails = new List<string>() { user.Email },
            PlaceHolders = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("{{UserName}}", user.FirstName),
                    new KeyValuePair<string, string>("{{Link}}", string.Format(appDomain + confirmationLink, user.Id, token))
                }
          };

          await emailRepository.SendEmailForEmailConfirmation(options);

          responseData.Status = true;
          responseData.Message = Messages.Success;
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
