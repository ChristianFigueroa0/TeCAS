using System.Threading.Tasks;
using TeCAS.Data.Models;

namespace TeCAS.Services
{
    public interface ISavingAccountService
    {
        /// <summary>
        /// Get saving account 
        /// </summary>
        /// <param name="accountId">Id of account</param>
        /// <returns>Instance of <see cref="SavingAccount"/></returns>
        Task<SavingAccount> GetSavingAccount(int accountId);
        /// <summary>
        /// Create a new saving account
        /// </summary>
        /// <param name="account">Saving account to save</param>
        /// <returns>Instance of <see cref="SavingAccount"/></returns>
        Task<SavingAccount> CreateSavingAccount(SavingAccount account);
    }
}
