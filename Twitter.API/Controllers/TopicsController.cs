using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Twitter.Business.Repositories.Interfaces;

namespace Twitter.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicsController : ControllerBase
    {
        ITopicRepository _repo { get; }

        public TopicsController(ITopicRepository repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repo.GetAll());
        }
        [HttpGet("ExistTest")]
        public async Task<IActionResult> IsExist()
        {
            return Ok(_repo.isExistAsync(t => t.Id == 2));
        }
    }   
}
