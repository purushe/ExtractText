using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
namespace TextReader.Models
{
  public class ProfileViewModel
  {
    public string Id { get; set; }

    [Required(ErrorMessage = "First Name is reqiured")]
    [Display(Name = "First Name")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Last Name is reqiured")]
    [Display(Name = "Last Name")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "Email is reqiured")]
    [Display(Name = "Email")]
    [Remote("FindByEmail", "Account", ErrorMessage = "This is Already Exist")]
    [EmailAddress]
    public string Email { get; set; }

    [Required(ErrorMessage = "PhoneNumber is reqiured")]
    [Display(Name = "PhoneNumber")]
    public string PhoneNumber { get; set; }

    [Required(ErrorMessage = "UserName is reqiured")]
    [Display(Name = "UserName")]
    public string UserName { get; set; }
  }
}
