using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TeCAS.Services;
using TeCAS.ViewModels;

namespace TeCAS.Controllers
{
    /// <summary>
    /// Handles requests related to customers
    /// </summary>
    public class CustomerController : Controller
    {
        /// <summary>
        /// Service to handles all operation related to customer
        /// </summary>
        private readonly ICustomerService _customerService;
        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="customerService">Injected customer service</param>
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        /// <summary>
        /// Render main view of customer
        /// </summary>
        /// <returns>View with stored customers</returns>
        public async Task<IActionResult> Index() => View(await _customerService.GetCustomers());
        /// <summary>
        /// Render partial view with form to allow created a new customer
        /// </summary>
        /// <returns>Partial view with customer form</returns>
        [HttpGet]
        [Route("[Controller]/Add")]
        public async Task<IActionResult> Add() => await Task.FromResult(PartialView("_Create"));

        /// <summary>
        /// Create a new customer
        /// </summary>
        /// <param name="model">Model with information of the customer to create</param>
        /// <returns>If success returns Partial view with row, another case return 500 status code</returns>
        [HttpPost]
        [Route("[Controller]/Add")]
        public async Task<IActionResult> Add([FromForm]CustomerViewModel model)
        {
            var customer = await _customerService.CreateCustomer(model.ToBasicCustomerModel());
            if (customer == null)
                return StatusCode(500, "The customer can not be inserted");
            return Ok(customer.Id);
        }
    }
}
