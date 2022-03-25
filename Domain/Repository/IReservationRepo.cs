using System;
using System.Collections.Generic;
using Domain.Domain;

namespace Domain.Repository
{
    public interface IReservationRepo : IRepo<Reservation, Tuple<Trip, User>>
    {
        public List<Reservation> GetReservationsForUser(User user);
    }
}
