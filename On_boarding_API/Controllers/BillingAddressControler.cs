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
    public class BillingAddressControler : ControllerBase
    {

        private readonly IBillingAddressRepository billingRepository;

        public BillingAddressControler(IBillingAddressRepository billingAddressRepository)
        {
            this.billingRepository = billingAddressRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetBillingAdress()
        {
            try
            {
                return Ok(await billingRepository.GetBillingAddresses());
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retreving data from the database \n " + e);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<BillingAddress>> GetBillingAddressById(int billingAddressId)
        {
            try
            {
                var result = await billingRepository.GetBillingAdress(billingAddressId);

                if(result == null)
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
        public async Task<ActionResult<BillingAddress>> CreateBillingAddress(BillingAddress billingAddress)
        {
            try
            {
                if (billingAddress == null)
                {
                    return BadRequest();
                }

                var createBillingAddress = await billingRepository.AddBillingAddress(billingAddress);

                return CreatedAtAction(nameof(GetBillingAddressById), new { id = createBillingAddress.BillingID });
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                   "Error retreving data from the database \n " + e);
            }
        } 

    }
}
