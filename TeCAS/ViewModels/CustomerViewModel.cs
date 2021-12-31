using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using TeCAS.Data.Models;

namespace TeCAS.ViewModels
{
    /// <summary>
    /// Customer view model with only necessary properties <see cref="Data.Models.Customer"/>
    /// </summary>
    public class CustomerViewModel
    {
        /// <summary>
        /// The id of customer
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// The number id of customer
        /// </summary>
        [Display(Name = "Identification number")]
        [Required]
        public int NumberId { get; set; }
        /// <summary>
        /// The full name of customer
        /// </summary>
        [Display(Name = "First name")]
        [Required]
        public string FirstName { get; set; }
        /// <summary>
        /// The full name of customer
        /// </summary>
        [Display(Name = "Last name")]
        [Required]
        public string LastName { get; set; }
        /// <summary>
        /// Collection of related saving accounts
        /// </summary>
        public IEnumerable<SavingAccountViewModel> SavingAccounts = new List<SavingAccountViewModel>();
        /// <summary>
        /// The full name of customer
        /// </summary>
        [Display(Name = "Full name")]
        public string FullName => $"{FirstName} {LastName}";
        /// <summary>
        /// Empty constructor
        /// </summary>
        public CustomerViewModel() { }
        /// <summary>
        /// Constructor with a customer
        /// </summary>
        /// <param name="customer">Instance of <see cref="Customer"/></param>
        public CustomerViewModel(Customer customer)
        {
            this.FirstName = customer.FirstName;
            this.LastName = customer.LastName;
            this.NumberId = customer.NumberId;
            this.Id = customer.Id;
            this.SavingAccounts = customer.SavingAccounts?.Select(a => new SavingAccountViewModel() { 
                Id = a.Id,
                CurrentBalance = a.CurrentBalance,
                Number = a.Number
            });
        }
        /// <summary>
        /// Cast this model to <see cref="Customer"/>
        /// </summary>
        /// <returns>Instance of <see cref="Customer"/></returns>
        public Customer ToBasicCustomerModel() => new Customer
        {
            FirstName = this.FirstName,
            LastName = this.LastName,
            NumberId = this.NumberId
        };
    }
}
