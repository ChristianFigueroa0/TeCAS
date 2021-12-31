using System.ComponentModel.DataAnnotations;
using TeCAS.Data.Models;

namespace TeCAS.ViewModels
{
    /// <summary>
    /// Represent the <see cref="SavingAccount"/> model
    /// </summary>
    public class SavingAccountViewModel
    {
        /// <summary>
        /// The id of saving account
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// The id of related customer
        /// </summary>
        public int CustomerId { get; set; }
        /// <summary>
        /// The number of account
        /// </summary>
        [Display(Name = "Account number")]
        [Range(1, int.MaxValue, ErrorMessage = "The number of account is invalid")]
        public int Number { get; set; }
        /// <summary>
        /// The current balance
        /// </summary>
        [Display(Name = "Current balance")]
        [Range(1, int.MaxValue, ErrorMessage = "The balance must be greater than 0")]
        public double CurrentBalance { get; set; }
        /// <summary>
        /// Cast view model to Saving account model
        /// </summary>
        /// <returns>Instance of <see cref="SavingAccount"/></returns>
        public SavingAccount ToSavingAccountModel() =>
            new SavingAccount()
            {
                CurrentBalance = this.CurrentBalance,
                CustomerId = this.CustomerId,
                Number = this.Number
            };
    }
}
