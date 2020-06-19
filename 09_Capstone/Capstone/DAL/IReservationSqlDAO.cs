using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.DAL
{
    public interface IReservationSqlDAO
    {
        int AddReservation(Reservation reservation);

        IList<Reservation> getAllReservations(int siteId);
    }
}
