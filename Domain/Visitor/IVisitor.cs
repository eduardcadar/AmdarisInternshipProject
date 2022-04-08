using Domain.Domain;

namespace Domain.Visitor
{
    public interface IVisitor
    {
        void Visit(DAgency agency);
        void Visit(DTrip trip);
    }
}
