using Domain.Domain;

namespace Domain.Visitor
{
    public interface IVisitor
    {
        void Visit(DTrip trip);
    }
}
