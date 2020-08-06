using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CabsBooking.Core.Entities
{
    public class BookingsHistory
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Email { get; set; }

        public DateTime BookingDate { get; set; }

        [Column(TypeName = "varchar(16)")]
        public int BookingTime { get; set; }
        public int ToPlace { get; set; }

        [Column(TypeName = "varchar(200)")]
        public string PickUpAddress { get; set; }

        [Column(TypeName = "varchar(30)")]
        public string LandMark { get; set; } 
        public DateTime PickupDate { get; set; }

        [Column(TypeName = "varchar(5)")]
        public int PickupTime { get; set; }


        [Column(TypeName = "varchar(25)")]
        public int ContactNo { get; set; }

        [Column(TypeName = "varchar(30)")]
        public string Status { get; set; }


        public int CabTypeId { get; set; } //foreignKey

        public CabType CabType { get; set; }
        public Place Place { get; set; }
        [ForeignKey("FromPlace")]
        public int FromPlace { get; set; } // foreignKey

        [Column(TypeName = "varchar(5)")]
        public string comp_time { get; set; }
        public decimal charge { get; set; }

        [Column(TypeName = "varchar(1000)")]
        public string Feedback { get; set; }


    }
}
