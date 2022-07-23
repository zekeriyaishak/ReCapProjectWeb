using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.JWT
{
    //erişim tokenı mesela admın, user yetkileri
    public class AccessToken
    {
        public string Token { get; set; }

        //Token'ın bitiş tarihi 
        public DateTime Expiration { get; set; }
    }
}
