using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TextReader.Data.Database;
using TextReader.Repository.Helper;
using TextReader.Repository.IRepository.Admin;
using TextReader.RepositoryModel.RepositoryModel;
using TextReader.Utility;
using static TextReader.Utility.Response;

namespace TextReader.Repository.Repository.Admin
{
  public class UserAccountRepository : IUserAccountRepository
  {
    private readonly UserManager<ApplicationUser> userManager;
    public UserAccountRepository(UserManager<ApplicationUser> userManager)
    {
      this.userManager = userManager;
    }
    public ResponseData<DataTableList<RegistrationRepositoryModel>> GetList(DTParameters dtParam)
    {
      var response = new ResponseData<DataTableList<RegistrationRepositoryModel>>();
      try
      {
        var Entity = new List<RegistrationRepositoryModel>();

        var _data = userManager.Users.ToList();

        if (_data.Count() > 0)
        {
          foreach (var item in _data)
          {
            var newitem = new RegistrationRepositoryModel()
            {
              Email = item.Email,
              FirstName = item.FirstName,
              LastName = item.LastName,
              MobileNumber = item.PhoneNumber,
              UserName = item.UserName,
              Id = item.Id,
            };
            Entity.Add(newitem);
          }
        }

        if (dtParam.Columns != null)
        {
          var FirstName = dtParam.Columns.FirstOrDefault(x => x.Name == nameof(RegistrationRepositoryModel.FirstName))?.Search?.Value;
          var LastName = dtParam.Columns.FirstOrDefault(x => x.Name == nameof(RegistrationRepositoryModel.LastName))?.Search?.Value;
          var Email = dtParam.Columns.FirstOrDefault(x => x.Name == nameof(RegistrationRepositoryModel.Email))?.Search?.Value;
          var MobileNumber = dtParam.Columns.FirstOrDefault(x => x.Name == nameof(RegistrationRepositoryModel.MobileNumber))?.Search?.Value;
          var UserName = dtParam.Columns.FirstOrDefault(x => x.Name == nameof(RegistrationRepositoryModel.UserName))?.Search?.Value;
          if (!string.IsNullOrEmpty(FirstName))
            Entity = Entity.Where(r => r.FirstName.Contains(FirstName)).ToList();
          if (!string.IsNullOrEmpty(LastName))
            Entity = Entity.Where(r => r.LastName.Contains(LastName)).ToList();
          if (!string.IsNullOrEmpty(Email))
            Entity = Entity.Where(r => r.Email.Contains(Email)).ToList();
          if (!string.IsNullOrEmpty(MobileNumber))
            Entity = Entity.Where(r => r.MobileNumber.Contains(MobileNumber)).ToList();
          if (!string.IsNullOrEmpty(UserName))
            Entity = Entity.Where(r => r.UserName.Contains(UserName)).ToList();
        }

        //for Searching
        int searchCount = Entity.Count();
        var querySelector = Entity.Select(x => new RegistrationRepositoryModel
        {
          UserName = x.UserName,
          MobileNumber = x.MobileNumber,
          Email = x.Email,
          LastName = x.LastName,
          FirstName = x.FirstName,
        }).AsQueryable(); // Convert to IQueryable<CategoryRepositoryModel>

        //for Sorting
        querySelector = FieldSortingUtility.EntitySortByDatatableParam(querySelector, dtParam, FieldSortingUtility.UserSort);

        //for Pagination
        var result = querySelector.GetPaged(dtParam.PageIndex == 0 ? 1 : dtParam.PageIndex + 1, dtParam.Length);
        response.Data = new DataTableList<RegistrationRepositoryModel>()
        {
          draw = dtParam.Draw,
          recordsFiltered = result.RowCount,
          recordsTotal = result.RowCount,
          data = result.Results.AsEnumerable()
        };
        response.Status = true;
        response.Message = Messages.CatAdd;
      }
      catch
      {
        response.Status = false;
        response.Message = Messages.Error;
      }
      return response;
    }
  }
}
