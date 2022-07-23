using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {
        //out- keywordlaı oraya gönderilen iki tane değeri boş bile olsa doldurup geri döndürür
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            //kriptolide kullandıgımız class
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                //biz de kendimiz şifreleyeceğiz. Key- kullandığımız algoritmanın oluşturduğu key değeri. farklı kullanıcılar için farklı oluşturur
                passwordSalt = hmac.Key;
                //stringin byte arrayi almamızı sağlar
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }
    }
}
