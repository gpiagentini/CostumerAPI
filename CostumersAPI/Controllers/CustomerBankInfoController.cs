using AppServices.Interfaces;
using DomainModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomersAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerBankInfoController : ControllerBase
    {
        private readonly ICustomerBankInfoAppService _customerBankInfoAppService;
        private readonly ILogger<CustomerBankInfoController> _logger;
        public CustomerBankInfoController(ICustomerBankInfoAppService customerBankInfoAppService,
            ILogger<CustomerBankInfoController> logger)
        {
            _customerBankInfoAppService = customerBankInfoAppService ?? throw new ArgumentNullException(nameof(customerBankInfoAppService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet("/customer/{id}", Name = "CustomerBankInfo")]
        [ProducesResponseType(typeof(CustomerBankInfo), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public IActionResult GetByCustomerId(int id)
        {
            var customerBankInfo = _customerBankInfoAppService.GetByCustomerId(id);
            return customerBankInfo != null ? Ok(customerBankInfo) : NoContent();
        }

        [HttpGet(Name = "CustomersBankInfos")]
        [ProducesResponseType(typeof(CustomerBankInfo), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public IActionResult GetAll()
        {
            try
            {
                var customerBankInfoResponse = _customerBankInfoAppService.GetAll();
                return customerBankInfoResponse.Any() ? Ok(customerBankInfoResponse) : NoContent();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "An error ocurred while trying to get all Customers Bank info.");
                return Problem("Não foi possível completar a solicitação");
            }


        }
    }
}
