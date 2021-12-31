using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeCAS.Data.Models
{
    /// <summary>
    /// Represent the store saving account into database 
    /// </summary>
    public class SavingAccount
    {
        /// <summary>
        /// The id of saving account
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// The number of account
        /// </summary>
        public int Number { get; set; }
        /// <summary>
        /// Current balance of the account
        /// </summary>
        public double CurrentBalance { get; set; }
        /// <summary>
        /// Collection of related transactions
        /// </summary>
        public ICollection<Transaction> Transactions { get; set; }
        /// <summary>
        /// Id of customer that this account is related
        /// </summary>
        [Column("Customer_Id")]
        public int CustomerId { get; set; }
        /// <summary>
        /// Instance of related customer
        /// </summary>
        public virtual Customer Customer { get; set; }
    }
}
