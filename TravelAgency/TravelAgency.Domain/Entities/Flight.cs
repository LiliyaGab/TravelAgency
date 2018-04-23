namespace TravelAgency.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Flight")]
    public partial class Flight
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Flight()
        {
            Tour = new HashSet<Tour>();
        }

        public int Id { get; set; }

        public DateTime DepDate { get; set; }

        public DateTime ArrDate { get; set; }

        [Required]
        [StringLength(50)]
        public string DepCity { get; set; }

        [Required]
        [StringLength(50)]
        public string ArrCity { get; set; }
        public int Price { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tour> Tour { get; set; }
    }
}
