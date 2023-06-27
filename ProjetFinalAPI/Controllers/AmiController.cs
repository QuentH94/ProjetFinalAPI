using DAL.DTO;
using DAL.Repositories;
using DAL.Services;
using Microsoft.AspNetCore.Mvc;
using ProjetFinalAPI.DTO;

namespace ProjetFinalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AmiController : ControllerBase
    {
        private readonly IAmiRepository _amiService;

        public AmiController(IAmiRepository amiService)
        {
            _amiService = amiService;
        }

        [HttpPost("SendFriendResquest")]
        public IActionResult SendFriendResquest(int user1, int user2, int demandeur)
        {
            _amiService.SendFriendResquest(user1, user2, demandeur);
            return Ok();
        }

        [HttpGet("Ami")]
        public ActionResult<AmiDTO> GetAllFriend()
        {
            return Ok(_amiService.GetAllFriend());
        }

        [HttpGet("Invitation")]
        public ActionResult<AmiDTO> GetAllInvitation()
        {
            return Ok(_amiService.GetAllInvitations());
        }
        [HttpPut("Accepted")]
        public IActionResult Accepted(int id)
        {
            _amiService.Accepted(id);
            _amiService.DeleteInvitation(id);
            return Ok();
        }
        [HttpPut("Refused")]
        public IActionResult Refused(int id)
        {
            _amiService.Refused(id);
            _amiService.DeleteInvitation(id);
            return Ok();
        }
        [HttpDelete("DeleteInvitation")]
        public IActionResult DeleteInvitation(int id)
        {
            _amiService.DeleteInvitation(id);
            return Ok();
        }
        [HttpDelete("DeleteFriend")]
        public IActionResult DeleteFriend(int user1, int user2)
        {
            _amiService.DeleteFriend(user1, user2);
            return Ok();
        }

    }
}
