using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Threading.Tasks;
using TeCAS.Data.Models.Enums;
using TeCAS.Services;
using TeCAS.ViewModels;

namespace TeCAS.Controllers
{
    public class SavingAccountController : Controller
    {
        /// <summary>
        /// Service to handles all operation related to customer
        /// </summary>
        private readonly ICustomerService _customerService;
        /// <summary>
        /// Service to handles all operation related to saving account
        /// </summary>
        private readonly ISavingAccountService _savingAccountService;
        /// <summary>
        /// Service to handles all operation related to transactions
        /// </summary>
        private readonly ITransactionService _transationService;
        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="customerService">Injected customer service</param>
        /// <param name="savingAccountService">Injected saving account service</param>
        /// <param name="transationService">Injected transaction service</param>
        public SavingAccountController(
            ICustomerService customerService,
            ISavingAccountService savingAccountService,
            ITransactionService transationService
            )
        {
            _customerService = customerService;
            _savingAccountService = savingAccountService;
            _transationService = transationService;
        }
        /// <summary>
        /// Main view of saving accounts
        /// </summary>
        /// <param name="customerId">The id of customer to get accounts</param>
        /// <returns>Main view with all saving accounts of customer</returns>
        [Route("[Controller]/{customerId:int}")]
        public async Task<IActionResult> Index(int customerId) =>
            View(await _customerService.GetCustomerWithAccounts(customerId));
        /// <summary>
        /// Render partial view with form to create account
        /// </summary>
        /// <param name="customerId">The id of customer</param>
        /// <returns>Partial view with form</returns>
        [HttpGet]
        [Route("[Controller]/{customerId:int}/add")]
        public async Task<IActionResult> Add(int customerId) => 
            await Task.FromResult(PartialView("_Create", new SavingAccountViewModel() {  CustomerId = customerId }));
        /// <summary>
        /// Add a new saving account
        /// </summary>
        /// <param name="model">Model with necessary information to create an account</param>
        /// <returns>Partial view with created account</returns>
        [HttpPost]
        [Route("[Controller]/add")]
        public async Task<IActionResult> Add([FromForm]SavingAccountViewModel model)
        {
            var savingAccount = await _savingAccountService.CreateSavingAccount(model.ToSavingAccountModel());
            if(savingAccount == null)
                    return StatusCode(500, "The saving account can not be inserted");
            model.Id = savingAccount.Id;
            return PartialView("_Account", model);
        }
        /// <summary>
        /// Render partial view with form to create transaction
        /// </summary>
        /// <param name="accountId">The id of account to attach transaction</param>
        /// <returns>Partial view with form</returns>
        [HttpGet]
        [Route("[Controller]/{accountId:int}/transaction/{type}/add")]
        public async Task<IActionResult> AddTransaction(int accountId, TransactionType type) =>
            await Task.FromResult(PartialView("_CreateTransaction", new AddTransactionViewModel() { AccountId = accountId, Type = type }));
        /// <summary>
        /// Create a new transaction
        /// </summary>
        /// <param name="model">Model with information to create transaction</param>
        /// <returns>Ok response if transaction was create, error code another case</returns>
        [HttpPost]
        [Route("[Controller]/transaction/add")]
        public async Task<IActionResult> AddTransaction([FromForm] AddTransactionViewModel model)
        {
            var success = await _transationService.AddTransaction(model.AccountId, model.Type, model.Amount);
            if (!success)
                return StatusCode(500, "The transaction can not be created");

            var account = await _savingAccountService.GetSavingAccount(model.AccountId);
            return Ok(account.CurrentBalance.ToString("C2", new CultureInfo("es-MX")));
        }
    }
}
