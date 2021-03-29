using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using On_boarding_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace On_boarding_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillingAddressController : ControllerBase
    {
        private readonly IBillingAddressRepository billingAddressRepository;

        public BillingAddressController(IBillingAddressRepository billingAddressRepository)
        {
            this.billingAddressRepository = billingAddressRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetBillingAddresses()
        {
            try
            {
               return Ok(await billingAddressRepository.GetBillingAddresses());
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retreving data from the database \n " + e);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<BillingAddress>> GetBillingAddress(int id)
        {
            try
            {
                var result = await billingAddressRepository.GetBillingAdress(id);

                if (result == null)
                {
                    return NotFound();
                }

                return result;
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retreving data from the database \n " + e);
            }
        }

        [HttpPost]
        public async Task<ActionResult<BillingAddress>> CreaterBillingAddress(BillingAddress billingAddress)
        {
            try
            {
                if (billingAddress == null)
                {
                    return BadRequest();
                }

                var createBillingAddress = await billingAddressRepository.AddBillingAddress(billingAddress);

                return CreatedAtAction(nameof(GetBillingAddress), new { id = createBillingAddress.BillingID }, createBillingAddress);
               
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retreving data from the database \n " + e);
            }
        }
    }
}
