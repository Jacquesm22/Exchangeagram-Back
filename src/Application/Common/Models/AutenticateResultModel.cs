namespace ExchangeAGram.Application.Common.Models
{
    public class AuthenticateResultModel
    {
        public bool Authenticated { get; set; }
        public string Message { get; set; }
        public string Username { get; set; }
        public TokenModel AccessToken { get; set; }
    }
}
