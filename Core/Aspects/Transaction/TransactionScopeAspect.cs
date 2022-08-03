using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Core.Aspects.Transaction
{
    public class TransactionScopeAspect : MethodInterception
    {
        // daha küçük parçalara ayrılamayan en küçük işlem yığınına denir.
        // Belirli bir grup işlemin arka arkaya gerçekleşmesine rağmen, işlemlerin seri ya da toplu halde değerlendirilip
        // hepsinin düzgün bir şekilde ele alınması gerektiğinde kullanılır.
        public override void Intercept(IInvocation invocation)
        {
            using (TransactionScope transactionScope = new TransactionScope())
            {
                try
                {
                    invocation.Proceed();
                    transactionScope.Complete();
                }
                catch (Exception e)
                {
                    transactionScope.Dispose();
                    throw;
                }
            }
        }
    }
}
