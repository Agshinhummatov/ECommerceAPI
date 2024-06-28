using E_CommerceAPI.Application.Consts;
using E_CommerceAPI.Application.Features.Commands.AppUser.CreateUser;
using E_CommerceAPI.Application.Features.Commands.AppUser.UpdatePassword;
using E_CommerceAPI.Application.Wrappers;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_CommerceAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;

        }


        [HttpPost("create-user")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<CreateUserCommandResponse>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<string>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiResponse<string>))]
        public async Task<IActionResult> CreateUser(CreateUserCommandRequest createUserCommandRequest)
        {
            try
            {
                CreateUserCommandResponse response = await _mediator.Send(createUserCommandRequest);
                return Ok(ApiResponse<CreateUserCommandResponse>.Success(response));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ApiResponse<string>.BadRequest(string.Format(ResponseMessages.InvalidArgument, ex.Message)));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ApiResponse<string>.InternalServerError(ResponseMessages.UserCreationError));
            }
        }

        [HttpPost("update-password")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<UpdatePasswordCommandResponse>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<string>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiResponse<string>))]
        public async Task<IActionResult> UpdatePassword([FromBody] UpdatePasswordCommandRequest updatePasswordCommandRequest)
        {
            try
            {
                UpdatePasswordCommandResponse response = await _mediator.Send(updatePasswordCommandRequest);
                return Ok(ApiResponse<UpdatePasswordCommandResponse>.Success(response));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ApiResponse<string>.BadRequest(string.Format(ResponseMessages.InvalidArgument, ex.Message)));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ApiResponse<string>.InternalServerError(ResponseMessages.PasswordUpdateError));
            }
        }


    }
}
