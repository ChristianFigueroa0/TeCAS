using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TeCAS.Data.Models.Enums;

namespace TeCAS.Data.Models
{
    /// <summary>
    /// Represent the store transaction into database
    /// </summary>
    public class Transaction
    {
        /// <summary>
        /// The id of transaction
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Amount of transaction
        /// </summary>
        public double Amount { get; set; }
        /// <summary>
        /// The saving before transaction
        /// </summary>
        [Column("Balance_Before_Transaction")]
        public double BalanceBeforeTransaction { get; set; }
        /// <summary>
        /// Id of related saving account
        /// </summary>
        [Column("Saving_Account_Id")]
        public int SavingAccountId { get; set; }
        /// <summary>
        /// The date it transaction was created
        /// </summary>
        public DateTime CreationDate { get; set; }
        /// <summary>
        /// Define the type of transaction
        /// </summary>
        public TransactionType Type { get; set; }


    }
}
