using System;
using Domain.Domain;
using Domain.Service;
using Infrastructure;
using Infrastructure.DataAccess;

namespace Microbuze
{
    class Program
    {
        static void Main(string[] args)
        {
            AgencyService agencySrv = new(null, null);
            AgencyUserService agencyUserSrv = new(null);
            RegularUserService regularUserSrv = new(null);
            TripService tripSrv = new(null);
            ReservationService resSrv = new(null);
            Service srv = new(agencySrv, agencyUserSrv, regularUserSrv, tripSrv, resSrv);

            DAgency agency = new("agency", "0755555555");
            DAgencyUser agencyUser = new("username", "password", "0777777777", agency);
            DTrip trip = agencyUser.CreateTrip("source", "dest", DateTime.Now.AddHours(1), TimeSpan.FromMinutes(60), 20.0, 20);


            var microbuzeContext = new MicrobuzeContext(@"Server=DESKTOP-DGHVO7U\SQLEXPRESS;Database=Microbuze;Trusted_Connection=True;");
            var agencyRepo = new AgencyDbRepo(microbuzeContext);

            //agencyRepo.Save(agency);
            Console.WriteLine(agencyRepo.Get(1));
        }
    }
}
