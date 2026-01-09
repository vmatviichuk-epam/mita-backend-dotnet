using Microsoft.AspNetCore.Mvc;
using Mita.Models;

namespace Mita.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly ILogger<AuthController> _logger;

    public AuthController(ILogger<AuthController> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Login endpoint - returns mock JWT token.
    /// TODO: Implement real authentication with database lookup and JWT generation
    /// </summary>
    [HttpPost("login")]
    public ActionResult<LoginResponse> Login([FromBody] LoginRequest request)
    {
        _logger.LogInformation("Login attempt for user: {Username}", request.Username);
        // Validate request
        if (string.IsNullOrWhiteSpace(request.Username) || string.IsNullOrWhiteSpace(request.Password))
        {
            return BadRequest(new ErrorResponse
            {
                Error = new ErrorDetail
                {
                    Code = "VALIDATION_ERROR",
                    Message = "Username and password are required"
                }
            });
        }

        // Mock response - always returns success for any credentials
        // TODO: Replace with real authentication logic
        var user = new UserDto
        {
            Id = 1,
            Username = request.Username
        };

        var response = new LoginResponse
        {
            Token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxIiwidXNlcm5hbWUiOiJ0ZXN0dXNlciJ9.MOCK",
            User = user
        };

        return Ok(response);
    }

    // TODO: Implement registration endpoint
    // [HttpPost("register")]

    // TODO: Implement logout endpoint
    // [HttpPost("logout")]
}
