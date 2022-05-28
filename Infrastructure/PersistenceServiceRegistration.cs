using Application.ReaderInterfaces;
using Domain.Repository;
using Infrastructure.DataAccess.Readers;
using Infrastructure.DataAccess.Repos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<MicrobuzeContext>((options) => options
                .UseSqlServer(connectionString: configuration.GetConnectionString("AppConnectionString")));

            // System.Configuration.ConfigurationManager.AppSettings["connectionString"]

            services.AddScoped<IAgencyUserRepo, AgencyUserDbRepo>();
            services.AddScoped<IAgencyUserReader, AgencyUserDbReader>();
            services.AddScoped<IRegularUserRepo, RegularUserDbRepo>();
            services.AddScoped<IRegularUserReader, RegularUserDbReader>();
            services.AddScoped<ITripRepo, TripDbRepo>();
            services.AddScoped<ITripReader, TripDbReader>();
            services.AddScoped<IReservationRepo, ReservationDbRepo>();
            services.AddScoped<IReservationReader, ReservationDbReader>();

            return services;
        }
    }
}
