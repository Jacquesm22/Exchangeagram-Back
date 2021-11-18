namespace ExchangeAGram.Application.Common.Models
{
    public class AuthenticationSettings
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Secret { get; set; }
        public int AccessTokenExpiresMinutes { get; set; }
    }
}
