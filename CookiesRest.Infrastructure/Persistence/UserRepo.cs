using CookiesRest.Application.Common.Interfaces.Persistence;
using CookiesRest.Domain.Entities;

namespace CookiesRest.Infrastructure.Persistence;

public class UserRepo : IUserRepo
{
    private static readonly List<User> _users = new();

    public void AddUser(User user)
    {
        _users.Add(user);
    }

    public User? GetUserByEmail(string email)
    {
        return _users.SingleOrDefault(u => u.Email == email);
    }
}
