using DAL.DTO;
using DAL.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ProjetFinalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageGlobalRepository _messageGlobalService;

        public MessageController(IMessageGlobalRepository messageGlobalService)
        {
            _messageGlobalService = messageGlobalService;
        }
        [HttpGet("MessageGlobal")]
        public ActionResult<MessageGlobalDTO> GetAllMessage()
        {
            return Ok(_messageGlobalService.GetAllMessage());  
        }
        [HttpPost("AddMessageGlobal")]
        public IActionResult AddMessageGlobal(int expediteur, string message)
        {
            _messageGlobalService.AddMessageGlobal(expediteur,message);
            return Ok();
        }
    }
}
