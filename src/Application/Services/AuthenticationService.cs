using System;
using Application.Interface;
using Application.Models.Request;
using Domain.Entities;
using Domain.Interface;

namespace Application.Services;

public class AuthenticationService(IUnitOfWork unitOfWork, IUserRepository userRepository) : IAuthenticationService
{
    public async Task<string> RegisterAsync(RegisterRequest registerRequest)
    {
        if(registerRequest == null)
        {
            throw new ArgumentNullException(nameof(registerRequest));
        }

        var existingUser = await userRepository.GetUserByEmailAsync(registerRequest.Email);
        if(existingUser != null)
        {
            // return "User with the same email already exists.";
            throw new Exception("User with the same email already exists.");
        }

        var user =  new User
        {
            Username = registerRequest.Username,
            Email = registerRequest.Email,
            Password = registerRequest.Password
        };
        await userRepository.AddAsync(user);
        await unitOfWork.CommitAsync();
        return "User registered successfully";
    }

    public Task<string> LoginAsync(LoginRequest loginRequest)   
    {
        throw new NotImplementedException();
    }
}
