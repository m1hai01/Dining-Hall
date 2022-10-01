using Dining_Hall.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dining_Hall.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DinigHallController : ControllerBase
    {
     

        private readonly ILogger<DinigHallController> _logger;

        public DinigHallController(ILogger<DinigHallController> logger)
        {
            _logger = logger;
        }

        //freastra la care putem sa ne adresam
        [HttpPost("Distribution")]
        public void Distribution([FromBody] ReturnOrder order)
        {

        }

    }
}