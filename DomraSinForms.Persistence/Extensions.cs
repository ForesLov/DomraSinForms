using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomraSinForms.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DomraSinForms.Persistence;
public static class Extensions
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, string connectionString)
    {
        return services
            .AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(connectionString, 
                    options => options.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.GetName().Name));
            })
            .AddScoped<IDatabaseContext, ApplicationDbContext>();
    }
}
