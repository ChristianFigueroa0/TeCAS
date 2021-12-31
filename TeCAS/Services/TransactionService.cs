using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeCAS.Data.Context;
using TeCAS.Data.Models.Enums;
using TeCAS.ViewModels;

namespace TeCAS.Services
{
    public class TransactionService : ITransactionService
    {
        /// <summary>
        /// Context to access to data base
        /// </summary>
        private readonly ApplicationContext _context;
        /// <summary>
        /// Factory of transaction creator
        /// </summary>
        private readonly TransactionCreatorFactory _transactionCreatorFactory;
        /// <summary>
        /// Default logger
        /// </summary>
        private readonly ILogger<TransactionService> _logger;
        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="transactionCreatorFactory">Injected transaction creator factory</param>
        /// <param name="loggerFactory">Injected logger factory</param>
        /// <param name="context">Injected Context</param>
        public TransactionService(
            TransactionCreatorFactory transactionCreatorFactory,
            ILoggerFactory loggerFactory,
            ApplicationContext context
            )
        {
            _transactionCreatorFactory = transactionCreatorFactory;
            _logger = loggerFactory.CreateLogger<TransactionService>();
            _context = context;
        }
        /// <inheritdoc/>
        public async Task<IEnumerable<TransactionViewModel>> GetTransactions(int accountId) => 
            await _context.Transactions
            .Where(t => t.SavingAccountId == accountId)
            .Select(t => new TransactionViewModel()
            {
                Amount = t.Amount,
                BalanceBeforeTransaction = t.BalanceBeforeTransaction,
                CreationDate = t.CreationDate,
                Type = t.Type
            })
            .ToListAsync();

        /// <inheritdoc/>
        public async Task<bool> AddTransaction(int accountId, TransactionType type, double amount)
        {
            try
            {
                var transactionCreator = _transactionCreatorFactory.Create(type);
                await transactionCreator.Create(accountId, amount);
                return await Task.FromResult(true);
            }
            catch(NotImplementedException ex)
            {
                _logger.LogError(ex, "The transaction type is not supported");
                return await Task.FromResult(false);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "An error occurred while trying to create transaction");
                return await Task.FromResult(false);
            }
        }
    }
}
