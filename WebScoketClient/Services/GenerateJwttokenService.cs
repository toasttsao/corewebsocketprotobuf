using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace WebScoketClient.Services
{
    public class GenerateJwttokenService:IGenerateJwtTokenService
    {
            private readonly IConfiguration _config;
            private readonly IHttpContextAccessor ctx;
            private TokenValidationParameters parm = null;

        #region Constructors

        public GenerateJwttokenService(IConfiguration config, IHttpContextAccessor ctx)
        {
            this._config = config;
            this.ctx = ctx;
        }

        #endregion Constructors

        #region Public Methods

        public string GenerateJwtToken(string userName)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sid, userName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                //new Claim(ClaimTypes.PrimarySid,secretId),
                //new Claim(ClaimTypes.Name, userName),
                //new Claim(ClaimTypes.Surname, opUserId)
            };
            //permission.ToList().ForEach(o => claims.Add(new Claim(ClaimTypes.Role, o)));
           // subUserId.ToList().ForEach(a => claims.Add(new Claim(ClaimTypes.GroupSid, a)));

            return this.BuildToken(claims,null);
        }
        public string RegenerateJwtToken()
        {
            var userName =ctx.HttpContext.User.Claims.FirstOrDefault(o => o.Type.Equals(JwtRegisteredClaimNames.Sid))?.Value;
           // var UserId =ctx.HttpContext.User.Claims.FirstOrDefault(o => o.Type.Equals(JwtRegisteredClaimNames.Sid))?.Value;
            //var secret_id =ctx.HttpContext.User.Claims.FirstOrDefault(o => o.Type.Equals(ClaimTypes.PrimarySid))?.Value;
            //var userName =ctx.HttpContext.User.Claims.FirstOrDefault(o => o.Type.Equals(ClaimTypes.Name))?.Value;
            //var opUserId =ctx.HttpContext.User.Claims.FirstOrDefault(o => o.Type.Equals(ClaimTypes.Surname))?.Value;


            //IEnumerable<string> roles = ctx.HttpContext.User.Claims.Where(o => o.Type.Equals(ClaimTypes.Role))
            //    .Select(o => o.Value);

            IEnumerable<string> group = ctx.HttpContext.User.Claims.Where(a => a.Type.Equals(ClaimTypes.GroupSid))
                .Select(a => a.Value);

            return GenerateJwtToken( userName); //GenerateJwtToken(UserId, userName,secret_id, group, opUserId);
        }


        public JwtUserInfoContra ReflectJwtToken(string token)
        {
            this.parm = this.parm ?? this.GetTokenValidationParameters();
            SecurityToken validatedToken = null;
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            var user = handler.ValidateToken(token, this.parm, out validatedToken);

            return this.ExtractJwtUserInfo(user);
        }

  


        public bool ValidToken(string token)
        {
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            if (handler.CanReadToken(token) == false)
                return false;

            this.parm = this.parm ?? this.GetTokenValidationParameters();
            SecurityToken validatedToken = null;

            var user = handler.ValidateToken(token, this.parm, out validatedToken);

            return
                user.HasClaim(o => o.Type.Equals(JwtRegisteredClaimNames.Sid)) &&
                user.HasClaim(o => o.Type.Equals(ClaimTypes.Surname)) &&
                user.HasClaim(o => o.Type.Equals(ClaimTypes.PrimarySid)) &&
                user.HasClaim(o => o.Type.Equals(ClaimTypes.Name)) &&
                user.HasClaim(o => o.Type.Equals(ClaimTypes.GroupSid));
        }

        #endregion Public Methods

        #region Private Methods

        private string BuildToken(IEnumerable<Claim> claims, int? timeWindow)
        {
            

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this._config.GetValue<string>("Jwt:JwtKey")));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTimeOffset.Now.AddMinutes(timeWindow ?? this._config.GetValue<int>("Jwt:JwtExpireMinutes"));

            var token = new JwtSecurityToken(
                this._config.GetValue<string>("Jwt:JwtIssuer"),
                this._config.GetValue<string>("Jwt:JwtAudience"),
                claims,
                expires: expires.DateTime,
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private TokenValidationParameters GetTokenValidationParameters()
        {

            return new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidIssuer = this._config.GetValue<string>("Jwt:JwtIssuer"),
                ValidAudience = this._config.GetValue<string>("Jwt:JwtAudience"),
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this._config.GetValue<string>("Jwt:JwtKey"))),
                ClockSkew = TimeSpan.Zero // remove delay of token when expire
            };
        }

        private JwtUserInfoContra ExtractJwtUserInfo(ClaimsPrincipal cp)
        {
            var info = new JwtUserInfoContra()
            {
                UserId = cp.Claims.FirstOrDefault(o => o.Type.Equals(JwtRegisteredClaimNames.Sid))?.Value,
                OpUserId = cp.Claims.FirstOrDefault(o => o.Type.Equals(ClaimTypes.Surname))?.Value,
                LoginName = cp.Claims.FirstOrDefault(o => o.Type.Equals(ClaimTypes.Name))?.Value,
                SecurityId = cp.Claims.FirstOrDefault(o => o.Type.Equals(ClaimTypes.PrimarySid))?.Value,
                SubUserId = cp.Claims.Where(o => o.Type.Equals(ClaimTypes.GroupSid)).Select(o => o.Value)
            };


            return info;
        }

        #endregion Private Methods
    }
}