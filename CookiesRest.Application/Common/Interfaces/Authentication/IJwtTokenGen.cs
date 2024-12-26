using System;
using CookiesRest.Domain.Entities;

namespace CookiesRest.Application.Common.Authentication;

public interface IJwtTokenGen
{
    string GenerateToken(User user);
}