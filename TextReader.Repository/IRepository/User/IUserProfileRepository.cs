using static TextReader.Utility.Response;
using System.Threading.Tasks;
using TextReader.RepositoryModel.RepositoryModel;

namespace TextReader.Repository.IRepository.User
{
  public interface IUserProfileRepository
  {
    Task<ResponseData<ProfileRepositoryModel>> GetById(string id);

  }
}
