namespace TravelAgency.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    [Table("Tour")]
    public partial class Tour
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tour()
        {
            Sale = new HashSet<Sale>();
            Flight = new HashSet<Flight>();
        }
        public IEnumerable<SelectListItem> SelectType { get; set; }
        public IEnumerable<SelectListItem> SelectFoodType { get; set; }
        public IEnumerable<SelectListItem> SelectHotel { get; set; }
        public IEnumerable<SelectListItem> BirthdateDaySelectList
        {
            get
            {
                for (int i = 1; i < 32; i++)
                {
                    yield return new SelectListItem
                    {
                        Value = i.ToString(),
                        Text = i.ToString(),
                    };
                }
            }
        }
        public IEnumerable<SelectListItem> BirthdateMonthSelectList
        {
            get
            {
                for (int i = 1; i < 13; i++)
                {
                    yield return new SelectListItem
                    {
                        Value = i.ToString(),
                        Text = new DateTime(2000, i, 1).ToString("MMMM"),
                    };
                }
            }
        }
        public IEnumerable<SelectListItem> BirthdateYearSelectList
        {
            get
            {
                for (int i = 1910; i < DateTime.Now.Year; i++)
                {
                    yield return new SelectListItem
                    {
                        Value = i.ToString(),
                        Text = i.ToString(),
                    };
                }
            }
        }
        
        [HiddenInput(DisplayValue=false)]
        public int Id { get; set; }

        [Display(Name="Дата начала тура")]
        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Дата конца тура")]
        [Column(TypeName = "date")]
        public DateTime EndDate { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int Type { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int FoodType { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int HotelId { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Описание тура")]
        public string Description { get; set; }

        public virtual FoodType FoodType1 { get; set; }

        public virtual Hotel Hotel { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sale> Sale { get; set; }

        public virtual TourType TourType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Flight> Flight { get; set; }
    }
}
