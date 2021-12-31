using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeCAS.Data.Models
{
    /// <summary>
    /// Represent the store customer into database
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// The id of customer
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// The first name of customer
        /// </summary>
        [Column("First_Name")]
        public string FirstName { get; set; }
        /// <summary>
        /// The last name of customer
        /// </summary>
        [Column("Last_Name")]
        public string LastName { get; set; }
        /// <summary>
        /// The number id of customer
        /// </summary>
        [Column("Number_Id")]
        public int NumberId { get; set; }
        /// <summary>
        /// Collection of related saving accounts
        /// </summary>
        public ICollection<SavingAccount> SavingAccounts { get; set; }
        /// <summary>
        /// The full name of customer
        /// </summary>
        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";
    }
}
