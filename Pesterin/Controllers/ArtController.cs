using Microsoft.AspNetCore.Mvc;
using Pesterin.Responses;
using Pesterin.Services.Impls;
using Pesterin.Services.Interface;
using Pesterin.Services.Models.Accounts;
using Pesterin.Services.Models.Arts;

namespace Pesterin.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArtController : ControllerBase
    {
        private readonly IArtService _artService;
        public ArtController(IArtService artService)
        {
            _artService = artService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateArtViewModel model)
        {
            return Ok(new ResponseResult<CreateArtViewModel>
            {
                IsSuccess = true,
                Error = null,
                Value = await _artService.Create(model)
            });
        }
    }
}
