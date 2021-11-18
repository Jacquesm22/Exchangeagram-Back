using ExchangeAGram.Application.Common.Models;

namespace ExchangeAGram.Application.Common.Interfaces
{
    public interface IJwtTokenBuilder
    {
        TokenModel Build(string userId, string username);
    }
}
