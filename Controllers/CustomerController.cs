using System;
using HelpSpace.Models;
using HelpSpace.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HelpSpace.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CustomerController :ControllerBase
	{
        private ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
		{
            _customerService = customerService;
        }

        [AllowAnonymous]
        [HttpPost("/prod/create")]
        public IActionResult CreateCustomerProd(CreateNFTRequest createNFTRequest)
        {

            string result = _customerService.CreateCustomerProd(createNFTRequest).Result;

            return Ok(new { result = result });
        }

        [AllowAnonymous]
        [HttpPost("/dev/create")]
        public IActionResult CreateCustomerDev(CreateNFTRequest createNFTRequest)
        {

            string result = _customerService.CreateCustomerDev(createNFTRequest).Result;

            return Ok(new { result = result });
        }
    }
}
