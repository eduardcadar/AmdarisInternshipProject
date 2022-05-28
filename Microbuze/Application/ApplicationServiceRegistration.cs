using Application.ReaderInterfaces;
using Application.Services;
using Application.Services.Interfaces;
using Application.UseCases.Create;
using Application.UseCases.Delete;
using Application.UseCases.Find;
using Application.UseCases.Update;
using Domain.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<CreateAgencyUser>();
            services.AddScoped<FindAgencyUserById>();
            services.AddScoped<FindAgencyUserByUsernameAndPassword>();
            services.AddScoped<CreateRegularUser>();
            services.AddScoped<FindRegularUserById>();
            services.AddScoped<FindRegularUserByUsernameAndPassword>();
            services.AddScoped<CreateTrip>();
            services.AddScoped<FindTripById>();
            services.AddScoped<FindTripsFiltered>();
            services.AddScoped<CreateReservation>();
            services.AddScoped<FindReservationById>();
            services.AddScoped<FindReservationsByRegularUserId>();
            services.AddScoped<FindReservationsByTripId>();
            services.AddScoped<DeleteReservation>();
            services.AddScoped<UpdateReservation>();

            services.AddScoped<IAgencyUsersService, AgencyUsersService>();
            services.AddScoped<IRegularUsersService, RegularUsersService>();
            services.AddScoped<ITripsService, TripsService>();
            services.AddScoped<IReservationsService, ReservationsService>();

            return services;
        }
    }
}
