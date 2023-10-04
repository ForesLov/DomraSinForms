using DomraSinForms.Application.Behaviors;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace DomraSinForms.Application;

public static class ApplicationExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        return services
            .AddMediatR(config =>
            {
                config.Lifetime = ServiceLifetime.Scoped;
                config.RegisterServicesFromAssembly(typeof(ApplicationExtensions).Assembly);
            })
            .AddValidatorsFromAssembly(typeof(ApplicationExtensions).Assembly)
            .AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>))
            .AddAutoMapper(typeof(ApplicationExtensions).Assembly);
    }
}