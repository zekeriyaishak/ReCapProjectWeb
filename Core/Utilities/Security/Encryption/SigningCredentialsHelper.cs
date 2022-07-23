using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Encryption
{
    //JWT oluşturalıbılmesi içinn elimizde olanlardan anahtar ıluşturyo sısteme girebilmemiz için
    //email password kulanılıyo ya o usercredentials mesela
    public class SigningCredentialsHelper
    {
        //hangi anahtarı ve algoritmayı kullanacagını söyluyoryz asp.net kullanabılmesı ıcın
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
        {
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);
        }
    }
}
