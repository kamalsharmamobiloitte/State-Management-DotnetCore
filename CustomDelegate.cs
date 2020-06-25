using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StateManageProject
{

    public class Delegate1
    {
        private readonly RequestDelegate next;
        public readonly static object MiddleWareSecret = new object();

        public Delegate1(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            context.Items.Add(MiddleWareSecret, "I mean Secret");
            await next(context);
        }

    }
    public static class CustomDelegateExtension
    {
       

        public static IApplicationBuilder UseItemDelegate(this IApplicationBuilder appa)
        {
            return appa.UseMiddleware(typeof(Delegate1));


        }

    }
}
