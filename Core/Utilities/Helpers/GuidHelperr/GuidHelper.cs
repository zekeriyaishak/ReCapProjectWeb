using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers.GuidHelperr
{
    //Guid, benzersiz değerler oluşturmak için kullanılmaktadır. Örnek olarak ortak bir alana birden fazla kullanıcının dosya kaydetmesini gösterebiliriz.
    //İki farklı kullanıcı aynı isimde dosya oluşturabilir ve bir kullanıcı diğer bir kullanıcının dosyasını bu şekilde ezebilir.
    public class GuidHelper
    {
        public static string CreateGuid()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
