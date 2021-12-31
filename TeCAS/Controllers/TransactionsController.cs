using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TeCAS.Services;

namespace TeCAS.Controllers
{
    public class TransactionsController : Controller
    {
        /// <summary>
        /// Service to handles all operation related to transactions
        /// </summary>
        private readonly ITransactionService _transationService;
        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="transationService">Injected transaction service</param>
        public TransactionsController(ITransactionService transationService)
        {
            _transationService = transationService;
        }
        /// <summary>
        /// Render main view with all transactions
        /// </summary>
        /// <param name="accountId">The id of account to display transactions</param>
        /// <returns>Main view of transactions</returns>
        [Route("[Controller]/{accountId:int}")]
        public async Task<IActionResult> Index(int accountId) => View(await _transationService.GetTransactions(accountId));
    }
}
