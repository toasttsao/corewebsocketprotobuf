using System.Collections.Generic;

namespace WebScoketClient.Services
{
    public class JwtUserInfoContra
    {
        public string UserId { get; set; }
        public string OpUserId { get; set; }

        public string LoginName { get; set; }

        public string SecurityId { get; set; }
        public IEnumerable<string> Permission { get; set; }
        public IEnumerable<string> SubUserId { get; set; }
    }
}