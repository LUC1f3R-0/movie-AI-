using Microsoft.AspNetCore.Mvc;
using movie_AI_BE.Models;
using movie_AI_BE.Requests;

namespace movie_AI_BE.Controller;

[ApiController]
[Route("api/auth")]
public sealed class AuthController : ControllerBase
{
    [HttpPost("login")]
    public async Task Login([FromBody] LoginRequest request, CancellationToken ct)
    {
        var input = new LoginInput(request.Email, request.Password);

        Console.WriteLine(input.Email);
        Console.WriteLine(input.Password);
        return;
    }
}