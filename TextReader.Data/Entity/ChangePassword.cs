using System.ComponentModel.DataAnnotations.Schema;

namespace TextReader.Data.Entity
{
  [Table("ChangePassword")]
  public class ChangePassword
  {
    [Column("CurrentPassword")]
    public string CurrentPassword { get; set; }

    [Column("NewPassword")]
    public string NewPassword { get; set; }

    [Column("ConfirmNewPassword")]
    public string ConfirmNewPassword { get; set; }
  }
}
