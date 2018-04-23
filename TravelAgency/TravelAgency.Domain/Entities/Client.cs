namespace TravelAgency.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    [Table("Client")]
    public partial class Client
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Client()
        {
            Sale = new HashSet<Sale>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage="Пожалуйста, введите свои фамилию, имя, отчество")]
        [StringLength(50)]
        public string FullName { get; set; }
        [Required(ErrorMessage="Пожалуйста, введите номер паспорта")]
        [RegularExpression(@"\d{10}", ErrorMessage = "Неверный формат паспорта")]
        public string Passport { get; set; }
        //[Required(ErrorMessage="Пожалуйста, введите свою дату рождения")]
        [Column(TypeName = "date")]
        public DateTime DOB { get; set; }

        [Required(ErrorMessage="Пожалуйста, введите свой адрес")]
        public string Address { get; set; }
        [Required(ErrorMessage="Пожалуйста, введите свой номер телефона")]
        [RegularExpression(@"^((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$", ErrorMessage="Неверный формат номера телефона")]
        public string PhoneNum { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sale> Sale { get; set; }

        public virtual User User { get; set; }
        public string BirthdateDay { get; set; }
        public string BirthdateMonth { get; set; }
        public string BirthdateYear { get; set; }
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
                        //Selected = DOB.Day == i
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
                        //Selected = DOB.Month == i
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
                        //Selected = DOB.Year == i
                    };
                }
            }
        }
    }
}
