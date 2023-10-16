using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Exceptions.Extensions;

public static class ExceptionMiddlewareExtensions
{
    
    public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
    {
        Console.WriteLine("test "+app.ApplicationServices);
        app.UseMiddleware<ExceptionMiddleware>();
    }
        
}
