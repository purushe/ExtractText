using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TextReader.Data.Entity
{
  [Table("Login")]
  public class Login
  {
    [Column("Email")]
    public string Email { get; set; }

    [Column("Password")]
    public string Password { get; set; }
  }
}
