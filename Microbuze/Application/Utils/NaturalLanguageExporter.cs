using System;
using System.IO;
using Application.Domain;
using Domain.Visitor;

namespace Application.Utils
{
    public class NaturalLanguageExporter : IVisitor
    {
        public void Visit(Agency agency)
        {
            string fileName = AppDomain.CurrentDomain.BaseDirectory + @"..\..\..\..\..\Agencies\" + agency.AgencyName + ".txt";
            File.WriteAllText(fileName, "Agency: " + agency.AgencyName + ", phone number: " + agency.PhoneNumber);
        }

        public void Visit(Trip trip)
        {
            string fileName = AppDomain.CurrentDomain.BaseDirectory + @"..\..\..\..\..\Trips\" +
            trip.DepartureLocation + "-" + trip.Destination + ".txt";
            File.WriteAllText(fileName, "Trip from " + trip.DepartureLocation + " to " + trip.Destination + " by agency " +
                trip.Agency.AgencyName + " on " + trip.DepartureTime + "; duration: " + trip.Duration +
                ", price: " + trip.Price + ", no. seats: " + trip.Seats);
        }
    }
}
