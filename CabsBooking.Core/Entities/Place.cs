using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CabsBooking.Core.Entities
{
    public class Place
    {
        public int PlaceId { get; set; }
        public string PlaceName { get; set; }
        [ForeignKey("FromPlace")]
        public ICollection<Booking> Bookings { get; set; }
        [ForeignKey("FromPlace")]
        public ICollection<BookingsHistory> BookingsHistories { get; set; }
    }
}
