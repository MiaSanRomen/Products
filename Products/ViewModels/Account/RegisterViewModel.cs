using System.ComponentModel.DataAnnotations;

namespace Products.ViewModels.Account
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Логин")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Почта")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтвердить пароль")]
        public string PasswordConfirm { get; set; }
    }
}
