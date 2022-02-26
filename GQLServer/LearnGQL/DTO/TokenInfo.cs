using System;

namespace LearnGQL.DTO
{
    public class TokenInfo
    {
        public string UserName { get; set; }
        public string Token { get; set; }
        public DateTimeOffset ExpiresAt { get; set; }
        public DateTimeOffset IssuedAt { get; set; }
    }
}
