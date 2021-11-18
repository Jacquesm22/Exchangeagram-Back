using ExchangeAGram.Application.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Security.Claims;

namespace ExchangeAGram.WebApi.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            UserId = httpContextAccessor.HttpContext?
                                        .User?
                                        .Claims?
                                        .FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?
                                        .Value;
        }

        public string UserId { get; }
    }
}
