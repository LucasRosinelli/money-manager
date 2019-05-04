using System.ComponentModel.DataAnnotations;

namespace MoneyManager.Api.Models.UserModel
{
    /// <summary>
    /// Change user authentication info model.
    /// </summary>
    public class UserChangeAuthInfo
    {
        /// <summary>
        /// User login.
        /// </summary>
        [Required]
        [MaxLength(120)]
        public string Login { get; set; }
        /// <summary>
        /// User password.
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Password { get; set; }
    }
}