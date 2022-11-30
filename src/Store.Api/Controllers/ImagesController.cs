using Microsoft.AspNetCore.Mvc;
using Store.Application.DTO;
using Store.Application.DTO.Image;
using Store.Application.Services.Contracts;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Store.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageService _imageService;

        public ImagesController(IImageService imageService)
        {
            _imageService = imageService;
        }

        [HttpGet("product/{id}")]
        public async Task<ActionResult<ApiResult<IEnumerable<ImageResponseDto>>>> GetAllByProductId(int id)
        {
            var images = await _imageService.GetAllByProductId(id);
            var response = ApiResult<IEnumerable<ImageResponseDto>>.Success(images);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ApiResult<CreateImageResponseDto>>> Post([FromBody] CreateImageDto createImageDto)
        {
            var imageId = await _imageService.CreateAsync(createImageDto);
            var response = ApiResult<CreateImageResponseDto>.Success(imageId);
            return Created(String.Empty, response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResult<UpdateImageResponseDto>>> Put(int id, [FromBody] UpdateImageDto updateImageDto)
        {
            var imageId = await _imageService.UpdateAsync(id, updateImageDto);
            var response = ApiResult<UpdateImageResponseDto>.Success(imageId);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResult<BaseResponseDto>>> Delete(int id)
        {
            var imageId = await _imageService.DeleteAsync(id);
            var response = ApiResult<BaseResponseDto>.Success(imageId);
            return Ok(response);
        }
    }
}
