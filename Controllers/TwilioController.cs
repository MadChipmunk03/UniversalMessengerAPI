using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;
using UniversalMessengerAPI.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UniversalMessengerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TwilioController : ControllerBase
    {
        TwilioService TS = new TwilioService("+14849469045");

        [HttpGet("all")]
        public List<string> Get()
        {
            return TS.GetRecipients();
        }

        //POST api/<TwilioController>
        [HttpPost("newRecipient")]
        public IActionResult Post(string recipient)
        {
            if(!TS.IsValid(recipient)) 
                return BadRequest("Není telefonní číslo");

            TS.AddRecipient(recipient);
            return Ok();
        }

        [HttpPost("sendMessages")]
        public void SendMessages(string message)
        {
            TS.SendMessages(message);
        }
    }
}
