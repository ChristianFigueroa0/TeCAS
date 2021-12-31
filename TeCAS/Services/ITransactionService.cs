using System.Collections.Generic;
using System.Threading.Tasks;
using TeCAS.Data.Models.Enums;
using TeCAS.ViewModels;

namespace TeCAS.Services
{
    public interface ITransactionService
    {
        /// <summary>
        /// Allow get all transactions
        /// </summary>
        /// <param name="accountId">The id of account to get transaction</param>
        /// <returns>Collection with <see cref="TransactionViewModel"/></returns>
        public Task<IEnumerable<TransactionViewModel>> GetTransactions(int accountId);
        /// <summary>
        /// Add a new transaction
        /// </summary>
        /// <param name="accountId">The id of account to attach transaction</param>
        /// <param name="type">Type of transaction</param>
        /// <param name="amount">Amount of transaction</param>
        /// <returns>True if transaction was created successful, false another case</returns>
        public Task<bool> AddTransaction(int accountId, TransactionType type, double amount);
    }
}
