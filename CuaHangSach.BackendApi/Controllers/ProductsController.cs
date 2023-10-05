using CuaHangSach.Application.Catalog.Products;
using CuaHangSach.ViewModels.Catalog.ProductImages;
using CuaHangSach.ViewModels.Catalog.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CuaHangSach.BackendApi.Controllers
{
    //api/product
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductsController : ControllerBase
    {
 
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
           
            _productService = productService;

        }




        //http : //localhost:port/product?pageIndex=1&pageSize=10&CategoryId=
        [HttpGet("{languageId}")] // Day la alias

        public async Task<IActionResult> GetPaging(string languageId, [FromQuery] GetPublicProductPagingRequest request)
        {
            var products = await _productService.GetAllByCategoryId(languageId, request); 
            return Ok(products);
        }

        //http : //localhost:port/product/{id}
        [HttpGet("{productId}/{languageId}")]
        public async Task<IActionResult> GetbyId(int productId, string languageId)
        {
            var product = await _productService.GetById(productId, languageId);
            if (product == null)
                return BadRequest("Cannot find product");

            return Ok(product);
        }


        [HttpPost]

        public async Task<IActionResult> Create([FromForm] ProductCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var productId = await _productService.Create(request);
            if (productId == 0)
                return BadRequest();

            var product = await _productService.GetById(productId, request.LanguageId);

            return CreatedAtAction(nameof(GetbyId), new { id = productId }, productId);
        }

        [HttpPut]

        public async Task<IActionResult> Update([FromForm] ProductUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var affectedResult = await _productService.Update(request);
            if (affectedResult == 0)
            { return BadRequest(); }


            return Ok();
        }

        [HttpDelete("{productId}")]

        public async Task<IActionResult> Delete(int productId)
        {
            var affectedResult = await _productService.Delete(productId);
            if (affectedResult == 0)
            { return BadRequest(); }


            return Ok();
        }

        [HttpPatch("{productId}/{newPrice}")] //HTTP patch : update 1 phan

        public async Task<IActionResult> UpdatePrice(int productId, decimal newPrice)
        {
            var isSucessful = await _productService.UpadatePrice(productId, newPrice);

            if (isSucessful)
                return Ok();
            return BadRequest();
        }

        //Images
        [HttpPost("{productId}/images")]

        public async Task<IActionResult> CreateImage(int productId,[FromForm] ProductImageCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var imageId = await _productService.AddImages(productId,request);
            if (imageId == 0)
            { return BadRequest(); }

            var image = await _productService.GetImageById(imageId);
            return CreatedAtAction(nameof(GetImageById), new {id = productId},image );
        }

        [HttpGet("{productId}/images/{imageId}")]
        public async Task<IActionResult> GetImageById(int productId, int imageId)
        {
            var image = await _productService.GetImageById(imageId);
            if (image == null)
                return BadRequest("Cannot find product");

            return Ok(image);
        }

        [HttpPut("{productId}/images/{imageId}")]

        public async Task<IActionResult> UpdateImage(int imageId, [FromForm] ProductImageUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _productService.UpdateImages(imageId, request);
            if (result == 0)
            { return BadRequest(); }

            
            return Ok();
        }
        [HttpDelete("{productId}/images/{imageId}")]

        public async Task<IActionResult> RemoveImage(int imageId)
        {
            var affectedResult = await _productService.RemoveImages(imageId);
            if (affectedResult == 0)
            { return BadRequest(); }


            return Ok();
        }
    }
}
