using E_CommerceAPI.Application.Features.Commands.Product.CreateProduct;
using E_CommerceAPI.Application.Features.Commands.Product.RemoveProduct;
using E_CommerceAPI.Application.Features.Commands.Product.UpdateProduct;
using E_CommerceAPI.Application.Features.Queries.Product.GetAllProduct;
using E_CommerceAPI.Application.Features.Queries.Product.GetByIdProduct;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace E_CommerceAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        
        readonly IMediator _mediator;


        public ProductsController(
            IMediator mediator)
        {

            _mediator = mediator;
        }


        [HttpGet("all")]
        public async Task<IActionResult> GetAllProducts([FromQuery] GetAllProductsQueryRequest getAllProductQueryRequest)
        {
            try
            {
                GetAllProductsQueryResponse response = await _mediator.Send(getAllProductQueryRequest);
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Genel hata yönetimi
                return StatusCode(500, new { Message = "An error occurred while retrieving the products.", Details = ex.Message });
            }
        }


        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdProductQueryRequset getByIdProductQueryRequset)
        {
            try
            {
                GetByIdProductQueryResponse response = await _mediator.Send(getByIdProductQueryRequset);

                if (response == null)
                {
                    return NotFound(new { Message = $"Product '{getByIdProductQueryRequset.Id}' not found.." });
                }

                return Ok(response);
            }
            catch (ArgumentException ex)
            {
                // Geçersiz id hatası
                return BadRequest(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while retrieving the products.", Details = ex.Message });
            }
        }

        [HttpPost("createPorduct")]
        public async Task<IActionResult> CreatePorduct(CreateProductCommandRequset createProductCommandRequset)
        {
            try
            {
                CreateProductCommandResponse response = await _mediator.Send(createProductCommandRequset);
                return StatusCode((int)HttpStatusCode.Created, response);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                // Log exception (not shown)
                return StatusCode((int)HttpStatusCode.InternalServerError, new { message = "An error occurred while creating the product" });
            }
        }


        [HttpDelete("{Id}")]
        public async Task<IActionResult> RemoveProduct([FromRoute] RemoveProductCommandRequset removeProductCommandRequset)
        {
            try
            {
                RemoveProductCommandResponse response = await _mediator.Send(removeProductCommandRequset);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                // Log exception (not shown)
                return StatusCode((int)HttpStatusCode.InternalServerError, new { message = "An error occurred while removing the product" });
            }
        }


        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateProduct([FromRoute] string Id, [FromBody] UpdateProductCommandRequset updateProductCommandRequset)
        {
            if (Id != updateProductCommandRequset.Id)
            {
                return BadRequest(new { message = "Product ID in the URL and request body must match" });
            }

            try
            {
                UpdateProductCommandResponse response = await _mediator.Send(updateProductCommandRequset);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                
                return StatusCode((int)HttpStatusCode.InternalServerError, new { message = "An error occurred while updating the product" });
            }
        }


    }
}
