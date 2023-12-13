namespace TextReader.Repository.Helper
{

  public static class Constants
  {
    public const string AdminRole = "Admin";
  }


  public class EmailDetails
  {
    public const string SubjectForForgotPassword = "Reset Password - Legal 4 Creatives";
    #region emailtemplate path
    public const string EmailTemplateForgotPassword = @"\Admin\emailTemplateAdmin\ForgotPasswordEmailTemplate.html";
    #endregion
  }
}
