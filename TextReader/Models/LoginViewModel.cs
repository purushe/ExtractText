using System.ComponentModel.DataAnnotations;

namespace TextReader.Models
{
  public class LoginViewModel
  {
    [Required(ErrorMessage = "Email is required *")]
    [Display(Name = "Email")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Password is required *")]
    [Display(Name = "Password")]
    [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*[#$^+=!*()@%&]).{6,}$", ErrorMessage = "Minimum length 6 and must contain  1 Uppercase,1 lowercase, 1 special character and 1 digit")]
    public string Password { get; set; }
  }
}
