using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TextReader.RepositoryModel.RepositoryModel;
using static TextReader.Utility.Response;

namespace TextReader.Repository.IRepository.Common
{
  public interface IEmailRepository
  {
    Task<ResponseData<EmailOptions>> SendEmailForForgotPassword(EmailOptions model);
    Task<ResponseData<EmailOptions>> SendEmailForEmailConfirmation(EmailOptions model);
  }
}
