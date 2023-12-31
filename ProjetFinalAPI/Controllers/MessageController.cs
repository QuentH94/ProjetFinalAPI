﻿using DAL.DTO;
using DAL.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace ProjetFinalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageGlobalRepository _messageGlobalRepository;
        private readonly IHubContext<SignalRHub> _messageHubContext;

        public MessageController(IMessageGlobalRepository messageGlobalRepository, IHubContext<SignalRHub> messageHubContext)
        {
            _messageGlobalRepository = messageGlobalRepository;
            _messageHubContext = messageHubContext;
        }

        [HttpGet("MessageGlobal")]
        public ActionResult<MessageGlobalDTO> GetAllMessage()
        {
            return Ok(_messageGlobalRepository.GetAllMessage());
        }

        [HttpPost("AddMessageGlobal")]
        public IActionResult AddMessageGlobal(int expediteur, string message)
        {
            _messageGlobalRepository.AddMessageGlobal(expediteur, message);

            // Envoyer le message à tous les clients via SignalR
            //_messageHubContext.Clients.All.SendAsync("ReceiveMessage");

            return Ok();
        }
        [HttpGet("GetLastMessageGlobal")]
        public ActionResult<MessageGlobalDTO> GetLastMessageGlobal()
        {
            return Ok(_messageGlobalRepository.GetLastMessageGlobal());
        }
    }
}
