using System;
using TeCAS.Data.Models.Enums;

namespace TeCAS.ViewModels
{
    /// <summary>
    /// View model used to display all transaction
    /// </summary>
    public class TransactionViewModel
    {
        /// <summary>
        /// Date that transaction was created
        /// </summary>
        public DateTime CreationDate { get; set; }
        /// <summary>
        /// Balance before transaction
        /// </summary>
        public double BalanceBeforeTransaction { get; set; }
        /// <summary>
        /// The type of transaction
        /// </summary>
        public TransactionType Type { get; set; }
        /// <summary>
        /// Amount of transaction
        /// </summary>
        public double Amount { get; set; }
        /// <summary>
        /// The current balance on time of the transaction was created
        /// </summary>
        public double Balance { get { return Type == TransactionType.Deposit ? BalanceBeforeTransaction + Amount : BalanceBeforeTransaction - Amount; } }
    }
}
