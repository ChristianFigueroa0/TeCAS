using System.ComponentModel.DataAnnotations;
using TeCAS.Data.Models.Enums;

namespace TeCAS.ViewModels
{
    /// <summary>
    /// View model with necessary properties to create a new transaction
    /// </summary>
    public class AddTransactionViewModel
    {
        /// <summary>
        /// The id of account
        /// </summary>
        public int AccountId { get; set; }
        /// <summary>
        /// Amount of transaction
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessage = "The amount must be greater than 0")]
        public double Amount { get; set; }
        /// <summary>
        /// Type of transaction
        /// </summary>
        public TransactionType Type { get; set; }
    }
}
