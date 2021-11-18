using ExchangeAGram.Application.Common.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace ExchangeAGram.Infrastructure.Auth
{
    public sealed class JwtTokenBuilder
    {
        private SecurityKey _securityKey = null;
        private string _subject = "";
        private string _issuer = "";
        private string _audience = "";
        private readonly Dictionary<string, object> _claims = new();
        private int _expiryInMinutes = 5;

        public JwtTokenBuilder AddSecurityKey(SecurityKey securityKey)
        {
            _securityKey = securityKey;
            return this;
        }

        public JwtTokenBuilder AddSubject(string subject)
        {
            _subject = subject;
            return this;
        }

        public JwtTokenBuilder AddUsername(string username)
        {
            return AddClaim(ClaimTypes.Name, username);
        }

        public JwtTokenBuilder AddIssuer(string issuer)
        {
            _issuer = issuer;
            return this;
        }

        public JwtTokenBuilder AddAudience(string audience)
        {
            _audience = audience;
            return this;
        }

        public JwtTokenBuilder AddClaim(string type, string value)
        {
            _claims.Add(type, value);
            return this;
        }

        public JwtTokenBuilder AddClaim(string type, string[] value)
        {
            _claims.Add(type, value);
            return this;
        }

        public JwtTokenBuilder AddClaims(Dictionary<string, object> claims)
        {
            _claims.Union(claims);
            return this;
        }

        public JwtTokenBuilder AddExpiry(int expiryInMinutes)
        {
            _expiryInMinutes = expiryInMinutes;
            return this;
        }

        public TokenModel Build()
        {
            EnsureArguments();

            var claims = new List<Claim>
            {
              new Claim(JwtRegisteredClaimNames.Sub, _subject),
              new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            }
            .Union(_claims.Select(item => item.Value is string[]?
                                                new Claim(item.Key, JsonExtensions.SerializeToJson(item.Value), JsonClaimValueTypes.JsonArray) :
                                                new Claim(item.Key, item.Value.ToString())));


            var token = new JwtSecurityToken(
                              issuer: _issuer,
                              audience: _audience,
                              claims: claims,
                              expires: DateTime.UtcNow.AddMinutes(_expiryInMinutes),
                              signingCredentials: new SigningCredentials(
                                                        _securityKey,
                                                        SecurityAlgorithms.HmacSha256));



            var jwtToken = new TokenModel
            {
                ValidTo = token.ValidTo.ToLocalTime(),
                Value = new JwtSecurityTokenHandler().WriteToken(token)
            };

            return jwtToken;
        }

        private void EnsureArguments()
        {
            if (_securityKey == null)
                throw new ArgumentNullException("Security Key");

            if (string.IsNullOrWhiteSpace(_subject))
                throw new ArgumentNullException("Subject");

            if (string.IsNullOrWhiteSpace(_issuer))
                throw new ArgumentNullException("Issuer");

            if (string.IsNullOrWhiteSpace(_audience))
                throw new ArgumentNullException("Audience");
        }
    }
}
