using DAL.DTO;
using DAL.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ProjetFinalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagePriveController : ControllerBase
    {
        private readonly IMessagePriveRepository _messagePriveRepository;

        public MessagePriveController(IMessagePriveRepository messagePriveRepository)
        {
            _messagePriveRepository = messagePriveRepository;
        }

        [HttpGet("MessagePrive")]
        public ActionResult<MessagePriveDTO> GetAllMessagePrive()
        {
            return Ok(_messagePriveRepository.GetAllMessagePrive());
        }

        [HttpPost("AddMessagePrive")]
        public IActionResult AddMessagePrive(int expediteur,int destinataire, string message)
        {
            _messagePriveRepository.AddMessagePrive(expediteur,destinataire,message);
            return Ok();
        }

        [HttpGet("GetLastMessagePrive")]
        public ActionResult<MessagePriveDTO> GetLastMessagePrive()
        {
            return Ok(_messagePriveRepository.GetLastMessagePrive());
        }

    }
}
