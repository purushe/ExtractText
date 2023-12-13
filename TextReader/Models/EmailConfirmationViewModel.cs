using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TextReader.Models
{
  public class EmailConfirmationViewModel
  {
    [Display(Name = "UserId")]

    public string UserId { get; set; }

    [Display(Name = "Email")]
    [EmailAddress]
    public string Email { get; set; }

    [Display(Name = "IsConfirmed")]
    public bool IsConfirmed { get; set; }

    [Display(Name = "EmailSent")]

    public bool EmailSent { get; set; }

    [Display(Name = "EmailVerified")]
    public bool EmailVerified { get; set; }

    [Display(Name = "Token")]
    public string Token { get; set; }
  }
}
