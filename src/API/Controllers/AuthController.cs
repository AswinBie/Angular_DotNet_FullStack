using System;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class AuthController: BaseApiController
{
    [HttpPost("Register")]
    public async Task<IResult> Register(RegisterRequest registerRequest)
    {
        return Results.Ok();
    }

    [HttpPost("Login")]
    public async Task<IResult> Login(LoginRequest loginRequest)
    {
        return Results.Ok();
    }
}
