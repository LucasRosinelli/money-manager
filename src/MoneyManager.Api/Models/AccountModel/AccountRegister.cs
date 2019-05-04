using System;
using System.ComponentModel.DataAnnotations;

namespace MoneyManager.Api.Models.AccountModel
{
    /// <summary>
    /// Register account model.
    /// </summary>
    public class AccountRegister
    {
        /// <summary>
        /// User owner of the account.
        /// </summary>
        [Required]
        public Guid User { get; set; }
        /// <summary>
        /// Account short name.
        /// </summary>
        [Required]
        [MaxLength(3)]
        public string ShortName { get; set; }
        /// <summary>
        /// Account long name.
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string LongName { get; set; }
        /// <summary>
        /// Account full name.
        /// </summary>
        [Required]
        [MaxLength(7)]
        public string Color { get; set; }
        /// <summary>
        /// Account icon.
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string Icon { get; set; }
    }
}