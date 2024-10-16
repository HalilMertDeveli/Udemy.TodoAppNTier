using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Udemy.TodoAppNTier.Business.Interfaces;
using Udemy.TodoAppNTier.Business.Mappings.AutoMapper;
using Udemy.TodoAppNTier.Business.Services;
using Udemy.TodoAppNTier.DataAccess.Contexts;
using Udemy.TodoAppNTier.DataAccess.UnitOfWork;

namespace Udemy.TodoAppNTier.Business.DependencyResolvers.Microsoft
{
    public static class DependencyExtension
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddDbContext<TodoContext>(opt =>
            {
                opt.LogTo(Console.WriteLine, LogLevel.Information);
                opt.UseSqlServer(
                    "Server=localhost; Database=TodoDb; Integrated Security=true; TrustServerCertificate=true");
            });
        
            services.AddScoped<IUow, Uow>();
            services.AddScoped<IWorkService, WorkService>();

            var configuration = new MapperConfiguration(opt =>
            {
                opt.AddProfile(new WorkProfile());
            });

            var mapper = configuration.CreateMapper();

            services.AddSingleton(mapper);
        }
    }
}
