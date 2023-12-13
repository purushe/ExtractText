using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TextReader.RepositoryModel.RepositoryModel
{
  [Table("ChangePassword")]
  public class ChangePasswordRepositoryModel
  {
    [Column("CurrentPassword")]
    public string CurrentPassword { get; set; }

    [Column("NewPassword")]
    public string NewPassword { get; set; }

    [Column("ConfirmNewPassword")]
    public string ConfirmNewPassword { get; set; }
  }
}
