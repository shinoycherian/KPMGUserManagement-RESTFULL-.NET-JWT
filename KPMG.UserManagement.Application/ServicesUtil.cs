
namespace KPMG.UserManagement.Application
{
    using AutoMapper;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Text;

       public static class ServiceUtil
    {
            public static void AddApplicationLayer(this IServiceCollection services)
            {
                // Setting AutoMapper
                services.AddAutoMapper(Assembly.GetExecutingAssembly());

                // other services here
            }
        }
    

}
