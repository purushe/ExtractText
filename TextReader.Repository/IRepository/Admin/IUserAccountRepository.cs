using System;
using System.Collections.Generic;
using System.Text;
using static TextReader.Utility.Response;
using TextReader.Repository.Helper;
using TextReader.Utility;
using TextReader.RepositoryModel.RepositoryModel;

namespace TextReader.Repository.IRepository.Admin
{
  public interface IUserAccountRepository
  {
    ResponseData<DataTableList<RegistrationRepositoryModel>> GetList(DTParameters dtParam);
  }
}
