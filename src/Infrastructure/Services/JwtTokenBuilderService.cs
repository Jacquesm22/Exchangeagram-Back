using ExchangeAGram.Application.Common.Interfaces;
using ExchangeAGram.Application.Common.Models;
using ExchangeAGram.Infrastructure.Auth;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ExchangeAGram.Infrastructure.Services
{
    public class JwtTokenBuilderService : IJwtTokenBuilder
    {
        private readonly AuthenticationSettings _authenticationSettings;

        public JwtTokenBuilderService(IOptions<AuthenticationSettings> options)
        {
            _authenticationSettings = options.Value;
        }

        public TokenModel Build(string userId, string username)
        {
            var tokenBuilder = new JwtTokenBuilder()
                                .AddSecurityKey(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_authenticationSettings.Secret)))
                                .AddSubject(userId)
                                .AddUsername(username)
                                .AddIssuer(_authenticationSettings.Issuer)
                                .AddExpiry(_authenticationSettings.AccessTokenExpiresMinutes)
                                .AddAudience(_authenticationSettings.Audience);

            return tokenBuilder.Build();
        }
    }
}
