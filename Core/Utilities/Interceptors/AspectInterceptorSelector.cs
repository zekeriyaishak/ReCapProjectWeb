using Castle.DynamicProxy;
using System.Reflection;

namespace Core.Utilities.Interceptors
{
    //Bu kodu yazmadım aldım.

    public class AspectInterceptorSelector : IInterceptorSelector
    {
       // Interceptor'lar belirli noktalarda metot çağrımları sırasında araya girerek bizlerin çakışan ilgilerimizi işletmemizi ve yönetmemizi sağlamakta.
       // Böylece metotların çalışmasından önce veya sonra bir takım işlemleri gerçekleştirebilmekteyiz.
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>
                (true).ToList();
            var methodAttributes = type.GetMethod(method.Name)
                .GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
            classAttributes.AddRange(methodAttributes);

            return classAttributes.OrderBy(x => x.Priority).ToArray();
        }
    }
}
