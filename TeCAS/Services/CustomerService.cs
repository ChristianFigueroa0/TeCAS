using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeCAS.Data.Context;
using TeCAS.Data.Models;
using TeCAS.ViewModels;

namespace TeCAS.Services
{
    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public class CustomerService : ICustomerService
    {
        /// <summary>
        /// Context to access to data base
        /// </summary>
        private readonly ApplicationContext _context;
        /// <summary>
        /// Default logger
        /// </summary>
        private readonly ILogger<CustomerService> _logger;
        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="context">Injected Context</param>
        /// <param name="loggerFactory">Injected logger factory</param>
        public CustomerService(ApplicationContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger<CustomerService>();
        }
        /// <inheritdoc>/>
        public async Task<Customer> CreateCustomer(Customer customer)
        {
            try
            {
                await _context.Customers.AddAsync(customer);
                await _context.SaveChangesAsync();
                return customer;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "An error occurred while trying to create a new customer");
                return null;
            }
        }
        /// <inheritdoc>/>
        public async Task<IEnumerable<CustomerViewModel>> GetCustomers() => await _context.Customers
            .AsNoTracking()
            .Select(c => new CustomerViewModel
            {
                Id = c.Id,
                FirstName = c.FirstName,
                LastName = c.LastName,
                NumberId = c.NumberId
            })
            .ToListAsync();

        /// <inheritdoc/>
        public async Task<CustomerViewModel> GetCustomerWithAccounts(int customerId)
        {
            var customer = await _context.Customers
                .Include(c => c.SavingAccounts)
                .FirstOrDefaultAsync(c => c.Id == customerId);
            if(customer != null)
                return new CustomerViewModel(customer);
            return null;

        }
    }
}
