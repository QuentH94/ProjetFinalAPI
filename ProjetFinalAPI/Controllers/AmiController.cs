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

        [HttpPost("AddFriend")]
        public IActionResult AddFriend(int friendId, int userId)
        {
            _amiService.addFriend(friendId, userId);
            return Ok();
        }

        [HttpGet]
        public ActionResult<AmiDTO> GetAll()
        {
            return Ok(_amiService.GetAllFriend());
        }

    }
}
