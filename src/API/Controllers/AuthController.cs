using System;
using Application.Interface;
using Application.Models.Request;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class AuthController(IAuthenticationService authenticationService): BaseApiController
{
    [HttpPost("Register")]
    public async Task<IResult> Register(RegisterRequest registerRequest)
    {
        var response = await authenticationService.RegisterAsync(registerRequest);
        return Results.Ok(response);
    }

    [HttpPost("Login")]
    public async Task<IResult> Login(LoginRequest loginRequest)
    {
        return Results.Ok();
    }
}
