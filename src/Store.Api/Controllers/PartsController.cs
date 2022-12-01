using Microsoft.AspNetCore.Mvc;
using Store.Application.DTO;
using Store.Application.DTO.Part;
using Store.Application.Services.Contracts;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Store.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartsController : ControllerBase
    {
        private readonly IPartService _partService;
        public PartsController(IPartService partService)
        {
            _partService = partService;
        }

        [HttpGet("Product/{id}")]
        public async Task<ActionResult<ApiResult<IEnumerable<PartResponseDto>>>> GetAllByProductId(int id)
        {
            var part = await _partService.GetAllByProductId(id);
            var response = ApiResult<IEnumerable<PartResponseDto>>.Success(part);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ApiResult<CreatePartResponseDto>>> Post([FromBody] CreatePartDto createPartDto)
        {
            var partId = await _partService.CreateAsync(createPartDto);
            var response = ApiResult<CreatePartResponseDto>.Success(partId);
            return Created(String.Empty, response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResult<UpdatePartResponseDto>>> Put(int id, [FromBody] UpdatePartDto updatePartDto)
        {
            var partId = await _partService.UpdateAsync(id, updatePartDto);
            var response = ApiResult<UpdatePartResponseDto>.Success(partId);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResult<BaseResponseDto>>> Delete(int id)
        {
            var partId = await _partService.DeleteAsync(id);
            var response = ApiResult<BaseResponseDto>.Success(partId);
            return Ok(response);
        }
    }
}
