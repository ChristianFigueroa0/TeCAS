using System.Threading.Tasks;

namespace TeCAS.Services
{
    public interface ITransactionCreator
    {
        /// <summary>
        /// Create transaction
        /// </summary>
        /// <param name="accountId">The id of account to attach transaction</param>
        /// <param name="amount">Amount of transaction</param>
        /// <returns>Task</returns>
        public Task Create(int accountId, double amount);
    }
}
