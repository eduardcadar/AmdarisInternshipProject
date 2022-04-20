using Application.ReaderInterfaces;
using Application.Services;
using Application.Services.Interfaces;
using Application.UseCases.Create;
using Application.UseCases.Find;
using Domain.Repository;
using Infrastructure;
using Infrastructure.DataAccess.Readers;
using Infrastructure.DataAccess.Repos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MicrobuzeContext>((options) => options
    .UseSqlServer(connectionString: System.Configuration.ConfigurationManager.AppSettings["connectionString"]));

builder.Services.AddScoped<IAgencyReader, AgencyDbReader>();
builder.Services.AddScoped<IAgencyRepo, AgencyDbRepo>();
builder.Services.AddScoped<IAgencyUserRepo, AgencyUserDbRepo>();
builder.Services.AddScoped<IAgencyUserReader, AgencyUserDbReader>();
builder.Services.AddScoped<IRegularUserRepo, RegularUserDbRepo>();
builder.Services.AddScoped<IRegularUserReader, RegularUserDbReader>();
builder.Services.AddScoped<ITripRepo, TripDbRepo>();
builder.Services.AddScoped<ITripReader, TripDbReader>();
builder.Services.AddScoped<IReservationRepo, ReservationDbRepo>();
builder.Services.AddScoped<IReservationReader, ReservationDbReader>();

builder.Services.AddScoped<CreateAgency>();
builder.Services.AddScoped<FindAgencyById>();
builder.Services.AddScoped<CreateAgencyUser>();
builder.Services.AddScoped<FindAgencyUserById>();
builder.Services.AddScoped<FindAgencyUserByUsernameAndPassword>();
builder.Services.AddScoped<CreateRegularUser>();
builder.Services.AddScoped<FindRegularUserById>();
builder.Services.AddScoped<FindRegularUserByUsernameAndPassword>();
builder.Services.AddScoped<CreateTrip>();
builder.Services.AddScoped<FindTripById>();
builder.Services.AddScoped<FindTripsFiltered>();
builder.Services.AddScoped<CreateReservation>();
builder.Services.AddScoped<FindReservationById>();
builder.Services.AddScoped<FindReservationsByRegularUserId>();
builder.Services.AddScoped<FindReservationsByTripId>();

builder.Services.AddScoped<IAgenciesService, AgenciesService>();
builder.Services.AddScoped<IAgencyUsersService, AgencyUsersService>();
builder.Services.AddScoped<IRegularUsersService, RegularUsersService>();
builder.Services.AddScoped<ITripsService, TripsService>();
builder.Services.AddScoped<IReservationsService, ReservationsService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.UseEndpoints(endpoints => endpoints.MapControllers());

app.Run();
