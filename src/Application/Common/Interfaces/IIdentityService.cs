using ExchangeAGram.Application.Common.Models;
using System.Threading.Tasks;

namespace ExchangeAGram.Application.Common.Interfaces
{
    public interface IIdentityService
    {
        Task<AuthenticateResultModel> AuthenticateUserAsync(string username, string password);
    }
}
