using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using TextReader.Data.Database;
using TextReader.RepositoryModel.RepositoryModel;
using static TextReader.Utility.Response;

namespace TextReader.Repository.IRepository.User
{
  public interface IUserRepository
  {
    Task<ResponseData<LoginRepositoryModel>> LoginAsync(LoginRepositoryModel model);
    Task LogoutAsync();
    Task<ResponseData<RegistrationRepositoryModel>> RegisterAsync(RegistrationRepositoryModel model);
    Task<ResponseData<ChangePasswordRepositoryModel>> ChangePasswordAsync(ChangePasswordRepositoryModel model);
    Task<ResponseData<EmailConfirmationRepositoryModel>> ConfirmEmailAsync(EmailConfirmationRepositoryModel model);
    Task<ResponseData<ApplicationUser>>GenerateEmailConfirmationTokenAsync(ApplicationUser user);



  }
}
