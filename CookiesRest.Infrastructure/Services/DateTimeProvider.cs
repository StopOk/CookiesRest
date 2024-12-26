using CookiesRest.Application.Common.Interfaces.Services;

namespace CookiesRest.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
