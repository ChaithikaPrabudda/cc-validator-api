using cc.validator.data.core.Models;
using cc.validator.manager.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace cc.host.validator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CCController : ControllerBase
    {
        private ICCManager _manager;
        public CCController (ICCManager manager)
        {
            _manager = manager;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("Validate")]
        public IActionResult ValidateCreditCard(CreditCardRequestModel creditCardRequestModel)
        {
            try
            {
                var creditCardInfo = _manager.ValidateCreditCard(creditCardRequestModel);
                return Ok(creditCardInfo);
            }
            catch (Exception ex)
            {
                //Log error message: TODO
                return BadRequest(ex.Message);
            }
        }
    }
}
