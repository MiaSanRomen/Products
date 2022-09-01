using System.ComponentModel.DataAnnotations;

namespace Products.ViewModels.Account
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Логин")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }
    }
}
