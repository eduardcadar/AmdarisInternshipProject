using System;
using System.IO;
using Domain.Domain;
using Domain.Visitor;

namespace Domain.Utils
{
    public class NaturalLanguageExporter : IVisitor
    {
        public void Visit(DAgency agency)
        {
            string fileName = AppDomain.CurrentDomain.BaseDirectory + @"..\..\..\..\..\Agencies\" + agency.AgencyName + ".txt";
            File.WriteAllText(fileName, "Agency: " + agency.AgencyName + ", phone number: " + agency.PhoneNumber);
        }

        public void Visit(DTrip trip)
        {
            string fileName = AppDomain.CurrentDomain.BaseDirectory + @"..\..\..\..\..\Trips\" +
            trip.DepartureLocation + "-" + trip.Destination + ".txt";
            File.WriteAllText(fileName, "Trip from " + trip.DepartureLocation + " to " + trip.Destination + " by agency " +
                trip.Agency.AgencyName + " on " + trip.DepartureTime + "; duration: " + trip.Duration +
                ", price: " + trip.Price + ", no. seats: " + trip.Seats);
        }
    }
}
