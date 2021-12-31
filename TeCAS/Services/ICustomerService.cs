using System.Collections.Generic;
using System.Threading.Tasks;
using TeCAS.Data.Models;
using TeCAS.ViewModels;

namespace TeCAS.Services
{
    /// <summary>
    /// Define necessary methods to work with customers
    /// </summary>
    public interface ICustomerService
    {
        /// <summary>
        /// Allows get stored customers
        /// </summary>
        /// <returns>Collection with stored customer</returns>
        public Task<IEnumerable<CustomerViewModel>> GetCustomers();

        /// <summary>
        /// Allows create a new customer
        /// </summary>
        /// <param name="customer">The customer to try create</param>
        /// <returns>Instance of stored customer</returns>
        public Task<Customer> CreateCustomer(Customer customer);
        /// <summary>
        /// Allows get the customer with all saving accounts <see cref="SavingAccount"/> model
        /// </summary>
        /// <param name="customerId">The id of customer to get information</param>
        /// <returns>Instance of <see cref="CustomerViewModel"/> with saving accounts</returns>
        public Task<CustomerViewModel> GetCustomerWithAccounts(int customerId);
    }
}
