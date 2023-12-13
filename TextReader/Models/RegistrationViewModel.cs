using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace TextReader.Models
{
  public class RegistrationViewModel
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

    [Required(ErrorMessage = "Password is reqiured")]
    [Display(Name = "Password")]
    [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*[#$^+=!*()@%&]).{6,}$", ErrorMessage = "Minimum length 6 and must contain  1 Uppercase,1 lowercase, 1 special character and 1 digit")]
    public string Password { get; set; }

    [Required(ErrorMessage = "Confirm Password is reqiured")]
    [Display(Name = "Confirm Password")]
    [Compare("Password")]
    public string ConfirmPassword { get; set; }
  }
}
