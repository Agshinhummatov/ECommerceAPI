using E_CommerceAPI.Application.Consts;
using E_CommerceAPI.Application.Features.Commands.AppUser.GoogleLogin;
using E_CommerceAPI.Application.Features.Commands.AppUser.LoginUser;
using E_CommerceAPI.Application.Features.Commands.AppUser.PasswordReset;
using E_CommerceAPI.Application.Features.Commands.AppUser.RefreshTokenLogin;
using E_CommerceAPI.Application.Features.Commands.AppUser.VerifyResetToken;
using E_CommerceAPI.Application.Wrappers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace E_CommerceAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        readonly IMediator _mediator;
        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<LoginUserCommandResponse>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<string>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiResponse<string>))]
        public async Task<IActionResult> Login(LoginUserCommandRequest loginUserCommandRequest)
        {
            try
            {
                LoginUserCommandResponse response = await _mediator.Send(loginUserCommandRequest);
                return Ok(ApiResponse<LoginUserCommandResponse>.Success(response));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ApiResponse<string>.BadRequest(string.Format(ResponseMessages.InvalidArgument, ex.Message)));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ApiResponse<string>.InternalServerError(ResponseMessages.LoginError));
            }
        }

        [HttpGet("refresh-token-login")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<RefreshTokenLoginCommandResponse>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<string>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiResponse<string>))]
        public async Task<IActionResult> RefreshTokenLogin([FromForm] RefreshTokenLoginCommandRequest refreshTokenLoginCommandRequest)
        {
            try
            {
                RefreshTokenLoginCommandResponse response = await _mediator.Send(refreshTokenLoginCommandRequest);
                return Ok(ApiResponse<RefreshTokenLoginCommandResponse>.Success(response));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ApiResponse<string>.BadRequest(string.Format(ResponseMessages.InvalidArgument, ex.Message)));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ApiResponse<string>.InternalServerError(ResponseMessages.RefreshTokenLoginError));
            }
        }

        [HttpPost("google-login")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<GoogleLoginCommandResponse>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<string>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiResponse<string>))]
        public async Task<IActionResult> GoogleLogin(GoogleLoginCommandRequest googleLoginCommandRequest)
        {
            try
            {
                GoogleLoginCommandResponse response = await _mediator.Send(googleLoginCommandRequest);
                return Ok(ApiResponse<GoogleLoginCommandResponse>.Success(response));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ApiResponse<string>.BadRequest(string.Format(ResponseMessages.InvalidArgument, ex.Message)));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ApiResponse<string>.InternalServerError(ResponseMessages.GoogleLoginError));
            }
        }

        [HttpPost("password-reset")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<PasswordResetCommandResponse>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<string>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiResponse<string>))]
        public async Task<IActionResult> PasswordReset([FromBody] PasswordResetCommandRequest passwordResetCommandRequest)
        {
            try
            {
                PasswordResetCommandResponse response = await _mediator.Send(passwordResetCommandRequest);
                return Ok(ApiResponse<PasswordResetCommandResponse>.Success(response));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ApiResponse<string>.BadRequest(string.Format(ResponseMessages.InvalidArgument, ex.Message)));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ApiResponse<string>.InternalServerError(ResponseMessages.PasswordResetError));
            }
        }

        [HttpPost("verify-reset-token")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<VerifyResetTokenCommandResponse>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<string>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiResponse<string>))]
        public async Task<IActionResult> VerifyResetToken([FromBody] VerifyResetTokenCommandRequest verifyResetTokenCommandRequest)
        {
            try
            {
                VerifyResetTokenCommandResponse response = await _mediator.Send(verifyResetTokenCommandRequest);
                return Ok(ApiResponse<VerifyResetTokenCommandResponse>.Success(response));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ApiResponse<string>.BadRequest(string.Format(ResponseMessages.InvalidArgument, ex.Message)));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ApiResponse<string>.InternalServerError(ResponseMessages.VerifyResetTokenError));
            }
        }


    }
}
