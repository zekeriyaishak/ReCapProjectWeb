using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.IoC
{
    public interface ICoreModule
    {
        //Ioc ile Uygulama içerisindeki obje instance'larının yönetimi sağlanarak, bağımlılıklarını en aza indirgemek amaçlanmaktadır. 
        void Load(IServiceCollection serviceCollection);
    }
}
