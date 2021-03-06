using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Helpers.FileHelper.Abstract;
using Core.Utilities.Helpers.FileHelper.Concrete;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule: Module
    {
        //sen bir autofac modülüsün
        //yani çalışma anında programın tek bir örneğinin oluşturulmasını, eğer program açıksa daha fazla örneğin oluşturulmaması için kullanılır
        protected override void Load(ContainerBuilder builder)
            {
                //autofac'de kayıt geliştirmek böyle oluyor.
                //birisi sendeen ICarService isterse ona Carmanager örneği ver demek. Tek bir instance oluşturur tutar
                builder.RegisterType<CarManager>().As<ICarService>().SingleInstance();
                builder.RegisterType<EfCarDal>().As<ICarDal>().SingleInstance();
                builder.RegisterType<BrandManager>().As<IBrandService>().SingleInstance();
                builder.RegisterType<EfBrandDal>().As<IBrandDal>().SingleInstance();
                builder.RegisterType<ColorManager>().As<IColorService>().SingleInstance();
                builder.RegisterType<EfColorDal>().As<IColorDal>().SingleInstance();
                builder.RegisterType<CustomerManager>().As<ICustomerService>().SingleInstance();
                builder.RegisterType<EfCustomerDal>().As<ICustomerDal>().SingleInstance();
                builder.RegisterType<RentalManager>().As<IRentalService>().SingleInstance();
                builder.RegisterType<EfRentalDal>().As<IRentalDal>().SingleInstance();
                builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
                builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();
                builder.RegisterType<CarImageManager>().As<ICarImageService>().SingleInstance();
                builder.RegisterType<EfCarImageDal>().As<ICarImageDal>().SingleInstance();
                builder.RegisterType<FileHelper>().As<IFileHelper>().SingleInstance();
                builder.RegisterType<AuthManager>().As<IAuthService>();
                builder.RegisterType<JwtHelper>().As<ITokenHelper>();
                builder.RegisterType<PaymentManager>().As<IPaymentService>().SingleInstance();
                builder.RegisterType<EfPaymentDal>().As<IPaymentDal>().SingleInstance();
                builder.RegisterType<CreditCardManager>().As<ICreditCardService>().SingleInstance();
                builder.RegisterType<EfCreditCardDal>().As<ICreditCardDal>().SingleInstance();




            //Aldım- sadece bir şeyi denedim - önemsiz şimdilik
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();

        }
    }
}
