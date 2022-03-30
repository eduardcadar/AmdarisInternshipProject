using Application.Domain;

namespace Domain.Visitor
{
    public interface IVisitor
    {
        void Visit(Agency agency);
        void Visit(Trip trip);
    }
}
