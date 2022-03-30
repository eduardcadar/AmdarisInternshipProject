using System;
using Application.Domain;
using Application.Service;

namespace Microbuze
{
    class Program
    {
        static void Main(string[] args)
        {
            AgencyService agencySrv = new AgencyService(null);
            AgencyUserService agencyUserSrv = new AgencyUserService(null);
            RegularUserService regularUserSrv = new RegularUserService(null);
            TripService tripSrv = new TripService(null);
            ReservationService resSrv = new ReservationService(null);
            Service srv = new Service(agencySrv, agencyUserSrv, regularUserSrv, tripSrv, resSrv);

            User user = new("username", "password", "0777777777");
            Agency agency = new("agency", "0755555555");
            AgencyUser agencyUser = new(user, agency);
            Trip trip = agencyUser.CreateTrip("source", "dest", DateTime.Now.AddHours(1), TimeSpan.FromMinutes(60), 20.0, 20);


            agencySrv.ExportToCsv(agency);
            tripSrv.ExportToCsv(trip);
            agencySrv.ExportToNaturalLanguage(agency);
            tripSrv.ExportToNaturalLanguage(trip);
        }
    }
}
