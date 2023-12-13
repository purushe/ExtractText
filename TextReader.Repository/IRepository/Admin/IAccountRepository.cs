using System.Threading.Tasks;
using TextReader.RepositoryModel.RepositoryModel;
using static TextReader.Utility.Response;

namespace TextReader.Repository.IRepository.Admin
{
  public interface IAccountRepository
  {
    Task<ResponseData<LoginRepositoryModel>> LoginAsync(LoginRepositoryModel model);
    Task LogoutAsync();
    //Task<ResponseData<RegistrationRepositoryModel>> RegisterAsync(RegistrationRepositoryModel model);

  }
}
