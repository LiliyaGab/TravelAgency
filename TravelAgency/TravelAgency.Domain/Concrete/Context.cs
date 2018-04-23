namespace TravelAgency.Domain.Concrete
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using TravelAgency.Domain.Entities;

    public partial class Context : DbContext
    {
        public Context()
            : base("name=Context")
        {
        }

        public virtual DbSet<AllocationType> AllocationType { get; set; }
        public virtual DbSet<Associate> Associate { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Flight> Flight { get; set; }
        public virtual DbSet<FoodType> FoodType { get; set; }
        public virtual DbSet<Hotel> Hotel { get; set; }
        public virtual DbSet<Sale> Sale { get; set; }
        public virtual DbSet<Tour> Tour { get; set; }
        public virtual DbSet<TourType> TourType { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserAssociate> UserAssociate { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AllocationType>()
                .Property(e => e.AllocationType1)
                .IsUnicode(false);

            modelBuilder.Entity<AllocationType>()
                .HasMany(e => e.Hotel)
                .WithMany(e => e.AllocationType)
                .Map(m => m.ToTable("Hotel-AllocationType").MapLeftKey("AllocationTypeId").MapRightKey("HotelId"));

            modelBuilder.Entity<Associate>()
                .HasMany(e => e.Sale)
                .WithRequired(e => e.Associate)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Associate>()
                .HasOptional(e => e.UserAssociate)
                .WithRequired(e => e.Associate);

            modelBuilder.Entity<City>()
                .HasMany(e => e.Hotel)
                .WithRequired(e => e.City)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Client>()
                .HasMany(e => e.Sale)
                .WithRequired(e => e.Client)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Client>()
                .HasOptional(e => e.User)
                .WithRequired(e => e.Client);

            modelBuilder.Entity<Country>()
                .HasMany(e => e.City)
                .WithRequired(e => e.Country1)
                .HasForeignKey(e => e.Country)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Flight>()
                .Property(e => e.DepCity)
                .IsUnicode(false);

            modelBuilder.Entity<Flight>()
                .Property(e => e.ArrCity)
                .IsUnicode(false);

            modelBuilder.Entity<Flight>()
                .HasMany(e => e.Tour)
                .WithMany(e => e.Flight)
                .Map(m => m.ToTable("Tour-Flight").MapLeftKey("FlightId").MapRightKey("TourId"));

            modelBuilder.Entity<FoodType>()
                .Property(e => e.FoodType1)
                .IsUnicode(false);

            modelBuilder.Entity<FoodType>()
                .HasMany(e => e.Tour)
                .WithRequired(e => e.FoodType1)
                .HasForeignKey(e => e.FoodType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Hotel>()
                .HasMany(e => e.Tour)
                .WithRequired(e => e.Hotel)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tour>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Tour>()
                .HasMany(e => e.Sale)
                .WithRequired(e => e.Tour)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TourType>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<TourType>()
                .HasMany(e => e.Tour)
                .WithRequired(e => e.TourType)
                .HasForeignKey(e => e.Type)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Login)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<UserAssociate>()
                .Property(e => e.Login)
                .IsUnicode(false);

            modelBuilder.Entity<UserAssociate>()
                .Property(e => e.Password)
                .IsUnicode(false);
        }
    }
}
