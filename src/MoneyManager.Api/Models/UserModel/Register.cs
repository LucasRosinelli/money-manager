using System.ComponentModel.DataAnnotations;

namespace MoneyManager.Api.Models.UserModel
{
    /// <summary>
    /// Register user model.
    /// </summary>
    public class Register
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
        /// <summary>
        /// User full name.
        /// </summary>
        [Required]
        [MaxLength(250)]
        public string FullName { get; set; }
    }
}