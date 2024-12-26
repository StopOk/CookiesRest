using CookiesRest.Domain.Entities;

namespace CookiesRest.Application.Common.Interfaces.Persistence;

public interface IUserRepo
{
    User? GetUserByEmail(string email);
    void AddUser(User user);
}
