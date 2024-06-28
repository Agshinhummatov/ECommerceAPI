using E_CommerceAPI.Application.Consts;
using E_CommerceAPI.Application.Features.Commands.Order.ComplatedOrder;
using E_CommerceAPI.Application.Features.Commands.Order.CreateOrder;
using E_CommerceAPI.Application.Features.Queries.Order.GetAllOrder;
using E_CommerceAPI.Application.Features.Queries.Order.GetOrderById;
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
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<GetOrderByIdQueryResponse>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<string>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiResponse<string>))]
        public async Task<ActionResult> GetOrderById([FromRoute] GetOrderByIdQueryRequest getOrderByIdQueryRequest)
        {
            try
            {
                GetOrderByIdQueryResponse response = await _mediator.Send(getOrderByIdQueryRequest);
                if (response == null)
                {
                    return NotFound(ApiResponse<string>.NotFound(string.Format(ResponseMessages.OrderNotFound, getOrderByIdQueryRequest.Id)));
                }
                return Ok(ApiResponse<GetOrderByIdQueryResponse>.Success(response));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ApiResponse<string>.InternalServerError(ResponseMessages.OrderRetrievalError));
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<GetAllOrderQueryResponse>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiResponse<string>))]
        public async Task<ActionResult> GetAllOrders([FromQuery] GetAllOrderQueryRequest getAllOrderQueryRequest)
        {
            try
            {
                GetAllOrderQueryResponse response = await _mediator.Send(getAllOrderQueryRequest);
                return Ok(ApiResponse<GetAllOrderQueryResponse>.Success(response));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ApiResponse<string>.InternalServerError(ResponseMessages.OrderRetrievalError));
            }
        }

        [HttpPost("create-order")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ApiResponse<CreateOrderCommandResponse>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiResponse<string>))]
        public async Task<ActionResult> CreateOrder(CreateOrderCommandRequest createOrderCommandRequest)
        {
            try
            {
                CreateOrderCommandResponse response = await _mediator.Send(createOrderCommandRequest);
                return StatusCode(StatusCodes.Status201Created, ApiResponse<CreateOrderCommandResponse>.Created(response));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ApiResponse<string>.InternalServerError(ResponseMessages.OrderCreationError));
            }
        }

        [HttpPost("complete-order/{Id}")]
       
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<CompleteOrderCommandResponse>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiResponse<string>))]
        public async Task<ActionResult> CompleteOrder([FromRoute] CompleteOrderCommandRequest completeOrderCommandRequest)
        {
            try
            {
                CompleteOrderCommandResponse response = await _mediator.Send(completeOrderCommandRequest);
                return Ok(ApiResponse<CompleteOrderCommandResponse>.Success(response));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ApiResponse<string>.InternalServerError(ResponseMessages.OrderCompletionError));
            }
        }
    }
}
