using System;
using System.ComponentModel.DataAnnotations;

namespace MoneyManager.Api.Models.EntryModel
{
    /// <summary>
    /// Register entry (income or expense) model.
    /// </summary>
    public class EntryRegister
    {
        /// <summary>
        /// Account of the entry.
        /// </summary>
        [Required]
        public Guid Account { get; set; }
        /// <summary>
        /// Entry description.
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string Description { get; set; }
        /// <summary>
        /// Entry date.
        /// </summary>
        [Required]
        public DateTime Date { get; set; }
        /// <summary>
        /// Entry value.
        /// </summary>
        [Required]
        public float Value { get; set; }
    }
}