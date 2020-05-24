using System.Collections.Generic;

namespace WebScoketClient.Services
{
    public interface IGenerateJwtTokenService
    {
        string RegenerateJwtToken();

        //string GenerateJwtToken(string userId, string userName,string secretId, IEnumerable<string> subUserId, string opUserId);
        string GenerateJwtToken( string userName);
     

        JwtUserInfoContra ReflectJwtToken(string token);

        bool ValidToken(string token);
    }
}