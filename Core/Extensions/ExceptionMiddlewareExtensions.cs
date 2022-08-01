using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{

    public static class ExceptionMiddlewareExtensions
    {
        /* Middleware nedir sorusuna cevap verecek olursak; 
         * Request/Response Pipeline’ı üzerinde özelleştirilmiş aksiyonlar alınmasını mümkün kılan,
         * bu Pipeline akışının handle edilmesini sağlayan modüler ve etkili yapılardır.
        Request’lerin istenilen kontrollerden geçirilmesi sağlanabilir,
        Response’ların cache üzerinden türetilmesi sağlanabilir,
        Uygulama üzerinde loglama mekanizmaları oluşturabilir,
        Exception Handling için çözümler sağlanabilir */
        
        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
