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
        public IActionResult SendFriendResquest(int user1, int user2)
        {
            _amiService.SendFriendResquest(user1, user2);
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
            return Ok();
        }
        [HttpPut("Refused")]
        public IActionResult Refused(int id)
        {
            _amiService.Refused(id);
            return Ok();
        }
        [HttpPatch("AddFriend")]
        public IActionResult AddFriend(int u1, int u2)
        {
            _amiService.AddFriend(u1, u2);
            return Ok();
        }
    }
}
