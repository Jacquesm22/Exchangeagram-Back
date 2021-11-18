using ExchangeAGram.Application.Common.Interfaces;
using ExchangeAGram.Application.Common.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ExchangeAGram.Infrastructure.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly IHashService _hashService;
        private readonly IApplicationDbContext _context;
        private readonly IJwtTokenBuilder _jwtTokenBuilder;

        public IdentityService(IHashService hashService, IApplicationDbContext context, IJwtTokenBuilder jwtTokenBuilder)
        {
            _hashService = hashService;
            _context = context;
            _jwtTokenBuilder = jwtTokenBuilder;
        }

        public async Task<AuthenticateResultModel> AuthenticateUserAsync(string username, string password) 
        {
            var user = await _context.Users.FirstOrDefaultAsync(f => f.Username.ToLower() == username.ToLower());
            if (user == null)
            {
                return new AuthenticateResultModel
                {
                    Authenticated = false,
                    Message = "Bad credentials"
                };
            }

            bool validLogin = _hashService.Hash(user.Password) == _hashService.Hash(password);
            if (!validLogin)
            {
                return new AuthenticateResultModel
                {
                    Authenticated = false,
                    Message = "Bad credentials"
                };
            }

            if (!user.Active)
            {
                return new AuthenticateResultModel
                {
                    Authenticated = false,
                    Message = "Account not active"
                };
            }

            return new AuthenticateResultModel
            {
                Message = "Authenticated",
                Authenticated = true,
                Username = user.Username,
                AccessToken = _jwtTokenBuilder.Build(user.Id.ToString(), user.Username)
            };
        }
    }
}
