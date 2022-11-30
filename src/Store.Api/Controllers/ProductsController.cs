using Microsoft.AspNetCore.Mvc;
using Store.Application.DTO;
using Store.Application.DTO.Product;
using Store.Application.Services.Contracts;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Store.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResult<IEnumerable<ProductResponseDto>>>> Get()
        {
            var products = await _productService.GetAllAsync();
            var response = ApiResult<IEnumerable<ProductResponseDto>>.Success(products);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResult<ProductResponseDto>>> Get(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            var response = ApiResult<ProductResponseDto>.Success(product);
            return Ok(response);
        }

        // POST api/<ProductsController>
        [HttpPost]
        public async Task<ActionResult<ApiResult<CreateProductResponseDto>>> Post([FromBody] CreateProductDto createProductDto)
        {
            var productId = await _productService.CreateAsync(createProductDto);
            var response = ApiResult<CreateProductResponseDto>.Success(productId);
            return Created(String.Empty, response);
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResult<UpdateProductResponseDto>>> Put(int id, [FromBody] UpdateProductDto updateProductDto)
        {
            var affectedProduct = await _productService.UpdateAsync(id, updateProductDto);
            var response = ApiResult<UpdateProductResponseDto>.Success(affectedProduct);
            return Ok(response);
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResult<BaseResponseDto>>> Delete(int id)
        {
            var affectedProduct = await _productService.DeleteAsync(id);
            var response = ApiResult<BaseResponseDto>.Success(affectedProduct);
            return Ok(response);
        }
    }
}
