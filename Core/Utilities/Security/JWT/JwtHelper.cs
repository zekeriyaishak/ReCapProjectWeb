using Core.Entities.Concrete;
using Core.Extensions;
using Core.Utilities.Security.Encryption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.JWT
{
    public class JwtHelper : ITokenHelper
    {
        public IConfiguration Configuration { get; } //apideki appsetting.jsondaki dosyayı okumayı sağlar
        private TokenOptions _tokenOptions; //token'ın değerleri
        private DateTime _accessTokenExpiration; //accesstoken ne zaman gecersizleşecek
        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
        }
        //user ve claim bilgilerini ver token oluşturayım
        public AccessToken CreateToken(User user, List<OperationClaim> operationClaims)
        {
            //10 dk sonra 
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);

            //Oluştururken securtiykey olması lazım dıyor
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            //hangi alg ve anahtarı kullanayım diyor
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
            //tokenoptions kullanarak ılgılı kullanıcı ve credentialsları(???) kullanarak oluşturan method yaptık
            var jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials, operationClaims);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration
            };

        }

        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, User user,
            SigningCredentials signingCredentials, List<OperationClaim> operationClaims)
        {
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: _accessTokenExpiration,
                notBefore: DateTime.Now,
                claims: SetClaims(user, operationClaims),
                signingCredentials: signingCredentials
            );
            return jwt;
        }

        //Claim-yetki ama başka bilgilerde olabilir.
        private IEnumerable<Claim> SetClaims(User user, List<OperationClaim> operationClaims)
        {

            //.net de var olan bir nesneye yeni method ekleyebılıyoruz extensions denıyor
            var claims = new List<Claim>();
            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddEmail(user.Email);
            claims.AddName($"{user.FirstName} {user.LastName}");
            claims.AddRoles(operationClaims.Select(c => c.Name).ToArray());

            return claims;
        }
    }
}
