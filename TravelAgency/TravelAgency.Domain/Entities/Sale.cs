namespace TravelAgency.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sale")]
    public partial class Sale
    {
        public int Id { get; set; }

        public int ClientId { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        public int Price { get; set; }

        public int TourId { get; set; }

        public int AssociateId { get; set; }

        public virtual Associate Associate { get; set; }

        public virtual Client Client { get; set; }

        public virtual Tour Tour { get; set; }
    }
}
