using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TextReader.RepositoryModel.RepositoryModel
{
  public class ProfileRepositoryModel
  {
    [Column("Id")]
    public string Id { get; set; }

    [Column("First_Name")]
    public string FirstName { get; set; }

    [Column("Last_Name")]
    public string LastName { get; set; }

    [Column("Email")]
    public string Email { get; set; }

    [Column("Mobile_Number")]
    public string MobileNumber { get; set; }

    [Column("User_Name")]
    public string UserName { get; set; }
  }
}
