using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TextReader.RepositoryModel.RepositoryModel
{
  [Table("EmailConfirmation")]
  public class EmailConfirmationRepositoryModel
  {
    [Column("UserId")]
    public string UserId { get; set; }

    [Column("Email")]
    public string Email { get; set; }

    [Column("IsConfirmed")]
    public bool IsConfirmed { get; set; }

    [Column("EmailSent")]
    public bool EmailSent { get; set; }

    [Column("EmailVerified")]
    public bool EmailVerified { get; set; }

    [Column("Token")]
    public string Token { get; set; }
  }
}

