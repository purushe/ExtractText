using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TextReader.Repository.IRepository.Common;
using TextReader.RepositoryModel.RepositoryModel;
using static TextReader.Utility.Response;
using System.IO;
using TextReader.Utility;

namespace TextReader.Repository.Repository.Common
{
  public class EmailRepository : IEmailRepository
  {
    private const string templatePath = @"EmailTemplate/{0}.html";
    private readonly SMTPConfigModel _smtpConfig;
    public EmailRepository(IOptions<SMTPConfigModel> smtpConfig)
    {
      try
      {
        _smtpConfig = smtpConfig.Value;
      }
      catch
      {
        throw;
      }
    }

    public async Task<ResponseData<EmailOptions>> SendEmailForEmailConfirmation(EmailOptions model)
    {
      var responseData = new ResponseData<EmailOptions>();
      try
      {
        model.Subject = UpdatePlaceHolders("Hello {{UserName}}, Confirm your email id.", model.PlaceHolders);

        model.Body = UpdatePlaceHolders(GetEmailBody("ConfirmEmail"), model.PlaceHolders);

        if (model.Body != null && model.Subject != null)
        {
          await SendEmail(model);
        }
      }
      catch
      {
        responseData.Status = false;
        responseData.Message = Messages.Error;
      }
      return responseData;

    }

    public Task<ResponseData<EmailOptions>> SendEmailForForgotPassword(EmailOptions model)
    {
      throw new NotImplementedException();
    }

    private async Task SendEmail(EmailOptions model)
    {
      try
      {
        MailMessage mail = new MailMessage()
        {
          Subject = model.Subject,
          Body = model.Body,
          From = new MailAddress(_smtpConfig.SenderAddress, _smtpConfig.SenderDisplayName),

          IsBodyHtml = _smtpConfig.IsBodyHTML,

        };

        foreach (var toEmail in model.ToEmails)
        {
          mail.To.Add(new MailAddress(toEmail));
          mail.ReplyToList.Add(new MailAddress(toEmail));
          mail.ReplyTo = new MailAddress(toEmail);
        }

        NetworkCredential networkCredential = new NetworkCredential(_smtpConfig.UserName, _smtpConfig.Password);

        SmtpClient smtpClient = new SmtpClient
        {
          Host = _smtpConfig.Host,
          Port = _smtpConfig.Port,
          EnableSsl = _smtpConfig.EnableSSL,
          UseDefaultCredentials = _smtpConfig.UseDefaultCredentials,
          Credentials = networkCredential,
        };
        mail.BodyEncoding = Encoding.Default;
        mail.HeadersEncoding = Encoding.Default;
        await smtpClient.SendMailAsync(mail);
      }
      catch
      {
        throw;
      }

    }

    private string GetEmailBody(string v)
    {
      try
      {
        var body = File.ReadAllText(string.Format(templatePath, v));
        return body;
      }
      catch
      {
        throw;
      }
    }

    private string UpdatePlaceHolders(string v, List<KeyValuePair<string, string>> placeHolders)
    {
      try
      {
        if (!string.IsNullOrEmpty(v) && placeHolders != null)
        {
          foreach (var placeholder in placeHolders)
          {
            if (v.Contains(placeholder.Key))
            {
              v = v.Replace(placeholder.Key, placeholder.Value);
            }
          }
        }
        return v;
      }
      catch
      {
        throw;
      }
    }
  }
}
