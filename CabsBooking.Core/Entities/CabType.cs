using System;
using System.Collections.Generic;

namespace CabsBooking.Core.Entities
{
    public class CabType
    {
        public int CabTypeId { get; set; }
        public string CabTypeName { get; set; }

        public ICollection<Booking> Bookings { get; set; }
        public ICollection<BookingsHistory> BookingsHistories { get; set; }
    }
}
