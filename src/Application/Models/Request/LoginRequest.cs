namespace Application.Models.Request;

public record class LoginRequest(
    string Email,
    string Password
);
