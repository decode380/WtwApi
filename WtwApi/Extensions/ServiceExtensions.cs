using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using WtwApi.Behavior;
using WtwApi.Context;
using WtwApi.Interfaces;
using WtwApi.Repository;

namespace WtwApi
{
    public static class ServiceExtensions
    {
        public static void AddApplicationInfraestructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddDbContext<WtwDbContext>(options => options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(WtwDbContext).Assembly.FullName)
            ));
            #region Repositories
            services.AddTransient(typeof(Interfaces.IRepositoryAsync<>), typeof(RepositoryAsync<>));
            #endregion
        }
    }
}
