using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using TeCAS.Data.Context;
using TeCAS.Data.Models;
using TeCAS.Data.Models.Enums;

namespace TeCAS.Services
{
    public class WithdrawalTransactionCreator : ITransactionCreator
    {
        /// <summary>
        /// Context to access to data base
        /// </summary>
        private readonly ApplicationContext _context;
        /// <summary>
        /// Default logger
        /// </summary>
        private readonly ILogger<WithdrawalTransactionCreator> _logger;
        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="context"></param>
        /// <param name="loggerFactory">Injected logger factory</param>
        public WithdrawalTransactionCreator(
            ApplicationContext context,
            ILoggerFactory loggerFactory
            )
        {
            _context = context;
            _logger = loggerFactory.CreateLogger<WithdrawalTransactionCreator>();
        }

        /// <summary>
        /// Create withdrawal transaction
        /// </summary>
        /// <param name="accountId">Id of account to attach transaction</param>
        /// <param name="amount">Amount of transaction</param>
        /// <returns><see cref="Task"/></returns>
        public async Task Create(int accountId, double amount)
        {
            var account = _context.SavingAccounts
                .Include(a => a.Transactions)
                .FirstOrDefault(a => a.Id == accountId);
            account.Transactions.Add(new Transaction()
            {
                BalanceBeforeTransaction = account.CurrentBalance,
                SavingAccountId = accountId,
                Amount = amount,
                Type = TransactionType.Withdrawal,
                CreationDate = DateTime.Now
            });
            account.CurrentBalance -= amount;
            await _context.SaveChangesAsync();
        }
    }
}
