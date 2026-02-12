using CGR.Application.Interfaces;
using CGR.Application.Mappings;
using CGR.Application.Services;
using CGR.Domain.Interfaces;
using CGR.Infra.Data.Context;
using CGR.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;

namespace CGR.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // Registro para AutoMapper
            //services.AddAutoMapper(typeof(DomainToDTOMappingProfile));
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<DomainToDTOMappingProfile>();
            });

            // Registro para injeção de dependências dos repositórios
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();

            // Registro para injeção de dependências dos serviços
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<ITransactionService, TransactionService>();


            return services;
        }
    }
}