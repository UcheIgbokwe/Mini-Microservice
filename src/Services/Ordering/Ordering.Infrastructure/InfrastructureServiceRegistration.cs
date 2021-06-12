using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using src.Services.Ordering.Ordering.Application.Behaviours;
using src.Services.Ordering.Ordering.Application.Contracts.Infrastructure;
using src.Services.Ordering.Ordering.Application.Contracts.Persistence;
using src.Services.Ordering.Ordering.Application.Features.Orders.Commands.CheckOutOrder;
using src.Services.Ordering.Ordering.Application.Models;
using src.Services.Ordering.Ordering.Infrastructure.Mail;
using src.Services.Ordering.Ordering.Infrastructure.Persistence;
using src.Services.Ordering.Ordering.Infrastructure.Repositories;

namespace src.Services.Ordering.Ordering.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<OrderContext>(options => options.UseSqlServer(configuration.GetConnectionString("OrderingConnectionString")), ServiceLifetime.Singleton);

            services.AddScoped(typeof(IOrderRepository), typeof(OrderRepository));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));

            // services.Configure<EmailSettings>(_ => configuration.GetSection("EmailSettings"));
            // services.AddScoped<IEmailService, EmailService>();


            return services;
        }
    }
}