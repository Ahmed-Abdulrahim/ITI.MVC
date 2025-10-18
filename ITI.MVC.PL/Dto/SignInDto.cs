using System.ComponentModel.DataAnnotations;

namespace ITI.MVC.PL.Dto
{
    public class SignInDto
    {
        [Required(ErrorMessage = "Email is Required")]
        [EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is Required")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
