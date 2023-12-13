using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using TextReader.Data.Database;
using TextReader.Repository.IRepository.User;
using TextReader.RepositoryModel.RepositoryModel;
using TextReader.Utility;
using static TextReader.Utility.Response;

namespace TextReader.Repository.Repository.User
{
  public class UserProfileRepository : IUserProfileRepository
  {
    private readonly UserManager<ApplicationUser> userManager;
    public UserProfileRepository(UserManager<ApplicationUser> userManager)
    {
      this.userManager = userManager;
    }

    public async Task<ResponseData<ProfileRepositoryModel>> GetById(string id)
    {
      var responseData = new ResponseData<ProfileRepositoryModel>();
      try
      {
        var user = await userManager.FindByIdAsync(id);
        if (user != null)
        {
          var data = new ProfileRepositoryModel()
          {
            Id = id,
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            MobileNumber = user.PhoneNumber,
            UserName = user.UserName,
          };

          responseData.Status = true;
          responseData.Message = Messages.RecordFound;
          responseData.Data = data;
        }
        else
        {
          responseData.Status = false;
          responseData.Message = Messages.NoRecordFound; // Provide a specific message if user is not found
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
