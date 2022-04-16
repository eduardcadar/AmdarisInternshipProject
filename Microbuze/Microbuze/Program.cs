using System;
using System.Threading.Tasks;
using Domain.Domain;
using Infrastructure;
using Infrastructure.DataAccess;

namespace Microbuze
{
    class Program
    {
        static async Task Main(string[] args)
        {
            DAgency agency = new("agency", "0755555555");
            DAgencyUser agencyUser = new("username", "password", "0777777777", agency);
            DTrip trip = agencyUser.CreateTrip("source", "dest", DateTime.Now.AddHours(1), TimeSpan.FromMinutes(60), 20.0, 20);

            await Task.Run(new Action(() => { }));
            //var microbuzeContext = new MicrobuzeContext(@"Server=DESKTOP-DGHVO7U\SQLEXPRESS;Database=Microbuze;Trusted_Connection=True;");
            //var agencyRepo = new AgencyDbRepo(microbuzeContext);

            //agencyRepo.Save(agency);
            //Console.WriteLine(agencyRepo.Get(1));
        }
    }
}
