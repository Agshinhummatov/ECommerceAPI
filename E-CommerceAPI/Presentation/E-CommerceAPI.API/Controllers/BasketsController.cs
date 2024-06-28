using E_CommerceAPI.Application.Consts;
using E_CommerceAPI.Application.Features.Commands.Basket.AddItemToBasket;
using E_CommerceAPI.Application.Features.Commands.Basket.RemoveBasketItem;
using E_CommerceAPI.Application.Features.Commands.Basket.UpdateQuantity;
using E_CommerceAPI.Application.Features.Queries.Basket.GetBasketItems;
using E_CommerceAPI.Application.Wrappers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_CommerceAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class BasketsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BasketsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetBasketItems")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<GetBasketItemsQueryResponse>>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiResponse<string>))]
        public async Task<IActionResult> GetBasketItems([FromQuery] GetBasketItemsQueryRequest getBasketItemsQueryRequest)
        {
            try
            {
                List<GetBasketItemsQueryResponse> response = await _mediator.Send(getBasketItemsQueryRequest);
                return Ok(ApiResponse<List<GetBasketItemsQueryResponse>>.Success(response));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ApiResponse<string>.InternalServerError(ResponseMessages.BasketRetrievalError));
            }
        }

        [HttpPost("AddItemToBasket")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<AddItemToBasketCommandResponse>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiResponse<string>))]
        public async Task<IActionResult> AddItemToBasket(AddItemToBasketCommandRequest addItemToBasketCommandRequest)
        {
            try
            {
                AddItemToBasketCommandResponse response = await _mediator.Send(addItemToBasketCommandRequest);
                return Ok(ApiResponse<AddItemToBasketCommandResponse>.Success(response));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ApiResponse<string>.InternalServerError(ResponseMessages.BasketItemAdditionError));
            }
        }

        [HttpPut("UpdateQuantity")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<UpdateQuantityCommandResponse>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiResponse<string>))]
        public async Task<IActionResult> UpdateQuantity(UpdateQuantityCommandRequest updateQuantityCommandRequest)
        {
            try
            {
                UpdateQuantityCommandResponse response = await _mediator.Send(updateQuantityCommandRequest);
                return Ok(ApiResponse<UpdateQuantityCommandResponse>.Success(response));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ApiResponse<string>.InternalServerError(ResponseMessages.BasketItemUpdateError));
            }
        }

        [HttpDelete("RemoveBasketItem/{BasketItemId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<RemoveBasketItemCommandResponse>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiResponse<string>))]
        public async Task<IActionResult> RemoveBasketItem([FromRoute] RemoveBasketItemCommandRequest removeBasketItemCommandRequest)
        {
            try
            {
                RemoveBasketItemCommandResponse response = await _mediator.Send(removeBasketItemCommandRequest);
                return Ok(ApiResponse<RemoveBasketItemCommandResponse>.Success(response));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ApiResponse<string>.InternalServerError(ResponseMessages.BasketItemRemovalError));
            }
        }
    }

}
