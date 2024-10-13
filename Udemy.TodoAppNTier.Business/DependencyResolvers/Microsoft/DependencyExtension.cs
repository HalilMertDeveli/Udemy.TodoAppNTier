using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Udemy.TodoAppNTier.DataAccess.Contexts;

namespace Udemy.TodoAppNTier.Business.DependencyResolvers.Microsoft
{
    public static class DependencyExtension
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddDbContext<TodoContext>(opt =>
                opt.UseSqlServer(
                    "Server=localhost; Database=TodoDb; Integrated Security=true; TrustServerCertificate=true"));
        }
    }
}
