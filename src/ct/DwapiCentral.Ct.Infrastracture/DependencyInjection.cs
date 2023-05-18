using DwapiCentral.Ct.Application.Interfaces.Repository;
using DwapiCentral.Ct.Infrastracture.Persistence.Context;
using DwapiCentral.Ct.Infrastracture.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DwapiCentral.Ct.Infrastracture
{
    public static class DependencyInjection
    {
        //Here we are configuring the db context and adding IProductRepository to the services collection as Scoped.

        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

            var defaultConnectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<CtDbContext>(options =>
            options.UseSqlServer(defaultConnectionString));

            services.AddScoped<IFacilityRepository, FacilityRepository>();
           
            services.AddScoped<IPatientExtractRepository, IPatientExtractRepository>();

            return services;

        }
    }
}
