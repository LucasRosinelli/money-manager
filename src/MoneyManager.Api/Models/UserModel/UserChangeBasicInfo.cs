using System.ComponentModel.DataAnnotations;

namespace MoneyManager.Api.Models.UserModel
{
    /// <summary>
    /// Change user basic info model.
    /// </summary>
    public class UserChangeBasicInfo
    {
        /// <summary>
        /// User full name.
        /// </summary>
        [Required]
        [MaxLength(250)]
        public string FullName { get; set; }
    }
}