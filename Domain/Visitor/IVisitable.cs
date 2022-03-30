﻿namespace Domain.Visitor
{
    public interface IVisitable
    {
        void Accept(IVisitor visitor);
    }
}
