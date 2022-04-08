using System;
using System.IO;
using Domain.Domain;
using Domain.Visitor;

namespace Domain.Utils
{
    public class CSVExporter : IVisitor
    {
        public void Visit(DAgency agency)
        {
            string fileName = AppDomain.CurrentDomain.BaseDirectory + @"..\..\..\..\..\Agencies\" + agency.AgencyName + ".csv";
            File.WriteAllText(fileName, agency.AgencyName + "," + agency.PhoneNumber);
        }

        public void Visit(DTrip trip)
        {
            string fileName = AppDomain.CurrentDomain.BaseDirectory + @"..\..\..\..\..\Trips\" +
                trip.DepartureLocation + "-" + trip.Destination + ".csv";
            File.WriteAllText(fileName,
                trip.Agency.AgencyName + "," + trip.DepartureLocation + "," + trip.Destination + "," +
                trip.DepartureTime + "," + trip.Duration + "," + trip.Price + "," + trip.Seats);
        }
    }
}
