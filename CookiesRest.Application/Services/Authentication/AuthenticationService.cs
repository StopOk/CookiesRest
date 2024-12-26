using System.Runtime.InteropServices;
using CookiesRest.Application.Common.Authentication;
using CookiesRest.Application.Common.Interfaces.Persistence;
using CookiesRest.Domain.Entities;

namespace CookiesRest.Application.Services.Authentication;
public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGen _jwtTokenGen;
    private readonly IUserRepo _userRepo;

    public AuthenticationService(IJwtTokenGen jwtTokenGen, IUserRepo userRepo)
    {
        _jwtTokenGen = jwtTokenGen;
        _userRepo = userRepo;
    }

    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        // Check if user already exists
        if (_userRepo.GetUserByEmail(email) is not null)
        {
            throw new Exception("There is already an account with this email address.");
        }

        // Create user (generate unique ID) and add to database
        var user = new User
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };

        _userRepo.AddUser(user);

        // Create JWT token
        Guid userId = Guid.NewGuid();
        var token = _jwtTokenGen.GenerateToken(user);

        return new AuthenticationResult
        (
            user,
            token
        );
    }

    public AuthenticationResult Login(string email, string password)
    {
        // Check if user exists
        if (_userRepo.GetUserByEmail(email) is not User user)
        {
            throw new Exception("There is no account with this email address.");
        }
        // Check if password is correct
        if (user.Password != password)
        {
            throw new Exception("Incorrect password.");
        }
        // Create JWT token
        var token = _jwtTokenGen.GenerateToken(user);

        return new AuthenticationResult
        (
            user,
            token
        );
    }
}