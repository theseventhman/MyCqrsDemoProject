using System;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;


namespace MyCqrs.Infra.CrossCutting.Ioc
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection serivces)
        {
            serivces.AddSingleton<IHttpContextAccessor, IHttpContextAccessor>();
        }
    }
}
