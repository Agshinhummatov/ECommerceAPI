using E_CommerceAPI.Application.Features.Commands.Product.CreateProduct;
using E_CommerceAPI.Application.Features.Queries.Product.GetAllProduct;
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
        readonly IConfiguration _configuration;
        readonly IMediator _mediator;


        public ProductsController(
            IMediator mediator)
        {

            _mediator = mediator;
        }


        [HttpGet("all")]
        public async Task<IActionResult> GetAllProducts([FromQuery] GetAllProductsQueryRequest getAllProductQueryRequest)
        {
            GetAllProductsQueryResponse response = await _mediator.Send(getAllProductQueryRequest);

            return Ok(response);
        }


        [HttpPost]
    
        public async Task<IActionResult> Post(CreateProductCommandRequset createProductCommandRequset)
        {
            CreateProductCommandResponse responce = await _mediator.Send(createProductCommandRequset);

            return StatusCode((int)HttpStatusCode.Created);
        }


    }
}
