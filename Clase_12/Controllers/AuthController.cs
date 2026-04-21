using Clase_12.Dtos;
using Clase_12.Options;
using Clase_12.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Clase_12.Controllers;

[ApiController]
[Route("api/auth")]
public sealed class AuthController(IConfiguration configuration, ITokenService tokenService, IOptions<JwtOptions> jwtOptions)
    : ControllerBase
{
    [HttpPost("login")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(TokenResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public ActionResult<TokenResponse> Login([FromBody] LoginRequest request)
    {
        var expectedUser = configuration["Auth:Username"];
        var expectedPass = configuration["Auth:Password"];

        if (string.IsNullOrWhiteSpace(expectedUser) || string.IsNullOrWhiteSpace(expectedPass))
        {
            return Problem(
                title: "Auth is not configured",
                detail: "Missing Auth:Username/Auth:Password in configuration.",
                statusCode: StatusCodes.Status500InternalServerError);
        }

        var userOk = string.Equals(request.Username, expectedUser, StringComparison.Ordinal);
        var passOk = string.Equals(request.Password, expectedPass, StringComparison.Ordinal);

        if (!userOk || !passOk)
        {
            return Unauthorized(new { message = "Credenciales inválidas." });
        }

        var token = tokenService.CreateToken(request.Username);
        var expiresIn = Math.Max(1, jwtOptions.Value.ExpirationMinutes) * 60;

        return Ok(new TokenResponse
        {
            AccessToken = token,
            ExpiresInSeconds = expiresIn
        });
    }
}
