using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using src.Services.Ordering.Ordering.Application;
using src.Services.Ordering.Ordering.Application.Behaviours;
using src.Services.Ordering.Ordering.Application.Contracts.Infrastructure;
using src.Services.Ordering.Ordering.Application.Contracts.Persistence;
using src.Services.Ordering.Ordering.Application.Features.Orders.Commands.CheckOutOrder;
using src.Services.Ordering.Ordering.Application.Features.Orders.Queries.GetOrdersList;
using src.Services.Ordering.Ordering.Application.Models;
using src.Services.Ordering.Ordering.Infrastructure;
using src.Services.Ordering.Ordering.Infrastructure.Mail;
using src.Services.Ordering.Ordering.Infrastructure.Persistence;
using src.Services.Ordering.Ordering.Infrastructure.Repositories;

namespace Ordering.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddApplicationServices();
            //services.AddInfrastructureServices(Configuration);

            services.AddControllers();

            services.AddDbContext<OrderContext>(c =>
                c.UseSqlServer(Configuration.GetConnectionString("OrderingConnectionString")), ServiceLifetime.Singleton);
            
            services.AddScoped(typeof(IOrderRepository), typeof(OrderRepository));
            services.AddTransient<IOrderRepository, OrderRepository>();

            services.AddAutoMapper(typeof(Startup));

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(typeof(CheckOutOrderCommandHandler).GetTypeInfo().Assembly);

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));

            
            // services.AddTransient(typeof(IEmailService), typeof(EmailService));
            // services.Configure<EmailSettings>( _ => Configuration.GetSection("EmailSettings"));




            services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "Ordering.API", Version = "v1" }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ordering.API v1"));
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
