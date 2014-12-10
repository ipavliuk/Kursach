using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using RentApartment.Core.Models.Mapping;

namespace RentApartment.Core.Models
{
    public partial class RentApartmentsContext : DbContext
    {
        static RentApartmentsContext()
        {
            Database.SetInitializer<RentApartmentsContext>(null);
        }

        public RentApartmentsContext()
            : base("Name=RentApartmentsContext")
        {
        }

        public DbSet<C_Amenities> C_Amenities { get; set; }
        public DbSet<C_Country> C_Country { get; set; }
        public DbSet<C_Currency> C_Currency { get; set; }
        public DbSet<C_Roles> C_Roles { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<GuestReview> GuestReviews { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<PropertyListing> PropertyListings { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new C_AmenitiesMap());
            modelBuilder.Configurations.Add(new C_CountryMap());
            modelBuilder.Configurations.Add(new C_CurrencyMap());
            modelBuilder.Configurations.Add(new C_RolesMap());
            modelBuilder.Configurations.Add(new AccountMap());
            modelBuilder.Configurations.Add(new GuestReviewMap());
            modelBuilder.Configurations.Add(new MessageMap());
            modelBuilder.Configurations.Add(new PropertyListingMap());
            modelBuilder.Configurations.Add(new ReservationMap());
        }
    }
}
