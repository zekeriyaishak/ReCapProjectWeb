using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching;
using Core.IoC;
using Core.Utilities.Interceptors;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Caching
{
/* Cacheaspect'e süre vermesek 60 dk durcak
set manager olarak service tool'umuzu kullanarak
Methodumn ismini bulup invocaton(getall) reflectedtype namespace+class ismi. method ismi ile key oluşturduk
Norhwind.Business:ICarService.GetAll()
methodun parametresini listele ve getall'un içine ekle varsa
Bellekte Daha önce var mı? varsa çalıştırmadan methodu geri dön
yoksa proceed yani methodu devam ettir ve add ile ekle*/
    public class CacheAspect : MethodInterception
    {
        private int _duration;
        private ICacheManager _cacheManager;

        public CacheAspect(int duration = 60)
        {
            _duration = duration;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        public override void Intercept(IInvocation invocation)
        {
            var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");
            var arguments = invocation.Arguments.ToList();
            var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})";
            if (_cacheManager.IsAdd(key))
            {
                invocation.ReturnValue = _cacheManager.Get(key);
                return;
            }
            invocation.Proceed();
            _cacheManager.Add(key, invocation.ReturnValue, _duration);
        }
    }
}
