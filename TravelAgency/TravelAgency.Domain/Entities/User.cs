namespace TravelAgency.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required(ErrorMessage = "¬ведите логин")]
        [StringLength(50)]
        public string Login { get; set; }

        [Required(ErrorMessage = "¬ведите пароль")]
        [StringLength(50)]
        public string Password { get; set; }

        public virtual Client Client { get; set; }
    }
}
