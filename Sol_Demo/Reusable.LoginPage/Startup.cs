using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reusable.LoginPage
{
    public static class Startup
    {
        public static void AddLoginPage(this IServiceCollection services)
        {
            services.AddMediatR(typeof(Startup));
        }
    }
}