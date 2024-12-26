using CookiesRest.Domain.Entities;

namespace CookiesRest.Application.Services.Authentication;

public record AuthenticationResult(
    User User,
    string Token
);