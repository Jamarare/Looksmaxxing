using System.ComponentModel.DataAnnotations;

namespace Looksmaxxing.Models.Accounts
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
