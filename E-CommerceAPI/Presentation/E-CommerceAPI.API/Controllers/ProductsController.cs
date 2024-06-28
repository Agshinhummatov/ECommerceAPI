using E_CommerceAPI.Application.Consts;
using E_CommerceAPI.Application.DTOs.Product;
using E_CommerceAPI.Application.Features.Commands.Product.CreateProduct;
using E_CommerceAPI.Application.Features.Commands.Product.RemoveProduct;
using E_CommerceAPI.Application.Features.Commands.Product.UpdateProduct;
using E_CommerceAPI.Application.Features.Commands.ProductImageFile.ChangeShowcaseImage;
using E_CommerceAPI.Application.Features.Commands.ProductImageFile.RemoveProdcutImage;
using E_CommerceAPI.Application.Features.Commands.ProductImageFile.UploadProdcutImage;
using E_CommerceAPI.Application.Features.Queries.Product.GetAllProduct;
using E_CommerceAPI.Application.Features.Queries.Product.GetByIdProduct;
using E_CommerceAPI.Application.Features.Queries.Product.SearchProducts;
using E_CommerceAPI.Application.Features.Queries.ProductImageFile.GetProductImages;
using E_CommerceAPI.Application.Wrappers;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace E_CommerceAPI.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK, Type = typeof(ApiResponse<IEnumerable<ProductDTO>>))]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllProducts([FromQuery] GetAllProductsQueryRequest getAllProductQueryRequest)
        {
            try
            {
                GetAllProductsQueryResponse response = await _mediator.Send(getAllProductQueryRequest);
                return Ok(ApiResponse<IEnumerable<ProductDTO>>.Success(response.Products));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ApiResponse<string>.InternalServerError(ResponseMessages.ProductRetrievalError));
            }
        }

        [HttpGet("{Id}")]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK, Type = typeof(ApiResponse<ProductDTO>))]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetById([FromRoute] GetByIdProductQueryRequest getByIdProductQueryRequest)
        {
            try
            {
                GetByIdProductQueryResponse response = await _mediator.Send(getByIdProductQueryRequest);

                if (response == null)
                {
                    return NotFound(ApiResponse<string>.NotFound(string.Format(ResponseMessages.ProductNotFound, getByIdProductQueryRequest.Id)));
                }

                
                return Ok(response);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ApiResponse<string>.BadRequest(string.Format(ResponseMessages.InvalidArgument, ex.Message)));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ApiResponse<string>.InternalServerError(ResponseMessages.ProductRetrievalError));
            }
        }


        [HttpPost]
        [ProducesResponseType(statusCode: StatusCodes.Status201Created)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateProduct(CreateProductCommandRequest createProductCommandRequest)
        {
            try
            {
                CreateProductCommandResponse response = await _mediator.Send(createProductCommandRequest);
                return StatusCode(StatusCodes.Status201Created, ApiResponse<CreateProductCommandResponse>.Created(response));
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ApiResponse<string>.BadRequest(string.Format(ResponseMessages.InvalidArgument, ex.Message)));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ApiResponse<string>.InternalServerError(ResponseMessages.ProductCreationError));
            }
        }

        [HttpDelete("{Id}")]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RemoveProduct([FromRoute] RemoveProductCommandRequest removeProductCommandRequest)
        {
            try
            {
                RemoveProductCommandResponse response = await _mediator.Send(removeProductCommandRequest);
                return Ok(ApiResponse<RemoveProductCommandResponse>.Success(response));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ApiResponse<string>.BadRequest(string.Format(ResponseMessages.InvalidArgument, ex.Message)));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ApiResponse<string>.InternalServerError(ResponseMessages.ProductRemovalError));
            }
        }

        [HttpPut("{Id}")]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductCommandRequest updateProductCommandRequest)
        {
            try
            {
                UpdateProductCommandResponse response = await _mediator.Send(updateProductCommandRequest);
                return Ok(ApiResponse<UpdateProductCommandResponse>.Success(response));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ApiResponse<string>.BadRequest(string.Format(ResponseMessages.InvalidArgument, ex.Message)));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ApiResponse<string>.InternalServerError(ResponseMessages.ProductUpdateError));
            }
        }


        [HttpGet("search")]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK, Type = typeof(ApiResponse<IEnumerable<ProductDTO>>))]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(statusCode: StatusCodes.Status500InternalServerError, Type = typeof(ApiResponse<string>))]
        public async Task<IActionResult> SearchProducts([FromQuery] string searchTerm)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(searchTerm))
                {
                    return BadRequest(ApiResponse<string>.BadRequest(ResponseMessages.ProductSearchCannotEmpty));
                }

                var request = new SearchProductsQueryRequest { SearchTerm = searchTerm };
                var response = await _mediator.Send(request);

                if (response.Products.Any())
                {
                    return Ok(ApiResponse<IEnumerable<ProductDTO>>.Success(response.Products));
                }
                else
                {
                    return NotFound(ApiResponse<string>.NotFound(ResponseMessages.ProductSearchNotFound));
                }
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ApiResponse<string>.BadRequest(string.Format(ResponseMessages.InvalidArgument, ex.Message)));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ApiResponse<string>.InternalServerError(ResponseMessages.ProductSearchError));
            }
        }




        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<UploadProductImageCommandResponse>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<string>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiResponse<string>))]
        public async Task<IActionResult> UploadProductFile([FromForm] UploadProductImageCommandRequest uploadProductImageCommandRequest)
        {
            try
            {
                if (uploadProductImageCommandRequest.Files == null || !uploadProductImageCommandRequest.Files.Any())
                {
                    return BadRequest(ApiResponse<string>.BadRequest(ResponseMessages.NoFilesProvided));
                }

                uploadProductImageCommandRequest.Files = Request.Form.Files;
                UploadProductImageCommandResponse response = await _mediator.Send(uploadProductImageCommandRequest);
                return Ok(ApiResponse<UploadProductImageCommandResponse>.Success(response));
            }
            catch (Exception ex)
            {
                
                return StatusCode(StatusCodes.Status500InternalServerError, ApiResponse<string>.InternalServerError(ResponseMessages.UploadProductFileError));
            }
        }


        [HttpGet("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<IEnumerable<GetProductImagesQueryResponse>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<string>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiResponse<string>))]
        public async Task<IActionResult> GetProductImages([FromRoute] GetProductImagesQueryRequest getProductImagesQueryRequest)
        {
            try
            {
                List<GetProductImagesQueryResponse> response = await _mediator.Send(getProductImagesQueryRequest);
                if (response == null || !response.Any())
                {
                    return NotFound(ApiResponse<string>.NotFound(ResponseMessages.ProductImagesNotFound));
                }
                return Ok(ApiResponse<IEnumerable<GetProductImagesQueryResponse>>.Success(response));
            }
            catch (Exception ex)
            {
                
                return StatusCode(StatusCodes.Status500InternalServerError, ApiResponse<string>.InternalServerError(ResponseMessages.GetProductImagesError));
            }
        }


        [HttpDelete("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<RemoveProductImageCommandResponse>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<string>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiResponse<string>))]
        public async Task<IActionResult> DeleteProductImage([FromRoute] RemoveProductImageCommandRequest removeProductImageCommandRequest, [FromQuery] string imageId)
        {
            try
            {
                if (string.IsNullOrEmpty(imageId))
                {
                    return BadRequest(ApiResponse<string>.BadRequest(ResponseMessages.InvalidImageId));
                }

                removeProductImageCommandRequest.ImageId = imageId;
                RemoveProductImageCommandResponse response = await _mediator.Send(removeProductImageCommandRequest);
                return Ok(ApiResponse<RemoveProductImageCommandResponse>.Success(response));
            }
            catch (Exception ex)
            {
                
                return StatusCode(StatusCodes.Status500InternalServerError, ApiResponse<string>.InternalServerError(ResponseMessages.DeleteProductImageError));
            }
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<ChangeShowcaseImageCommandResponse>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<string>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiResponse<string>))]
        public async Task<IActionResult> ChangeShowcaseImage([FromQuery] ChangeShowcaseImageCommandRequest changeShowcaseImageCommandRequest)
        {
            try
            {
                ChangeShowcaseImageCommandResponse response = await _mediator.Send(changeShowcaseImageCommandRequest);
                return Ok(ApiResponse<ChangeShowcaseImageCommandResponse>.Success(response));
            }
            catch (Exception ex)
            {
                
                return StatusCode(StatusCodes.Status500InternalServerError, ApiResponse<string>.InternalServerError(ResponseMessages.ChangeShowcaseImageError));
            }
        }



    }


}
