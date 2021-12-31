using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using TeCAS.Data.Context;
using TeCAS.Data.Models;

namespace TeCAS.Services
{
    public class SavingAccountService : ISavingAccountService
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
        public SavingAccountService(
            ApplicationContext context,
            ILoggerFactory loggerFactory
            )
        {
            _context = context;
            _logger = loggerFactory.CreateLogger<CustomerService>();
        }

        /// <inheritdoc>
        public async Task<SavingAccount> CreateSavingAccount(SavingAccount account)
        {
            try
            {
                await _context.SavingAccounts.AddAsync(account);
                await _context.SaveChangesAsync();
                return account;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while trying to create a new customer");
                return null;
            }
        }
        /// <inheritdoc>
        public async Task<SavingAccount> GetSavingAccount(int accountId) => await _context.SavingAccounts.FirstOrDefaultAsync(a => a.Id == accountId);
    }
}
