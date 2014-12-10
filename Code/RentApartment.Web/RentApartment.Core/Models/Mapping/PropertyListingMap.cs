using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RentApartment.Core.Models.Mapping
{
    public class PropertyListingMap : EntityTypeConfiguration<PropertyListing>
    {
        public PropertyListingMap()
        {
            // Primary Key
            this.HasKey(t => t.PropertyId);

            // Properties
            this.Property(t => t.Photos)
                .HasMaxLength(2000);

            this.Property(t => t.GreatTitle)
                .HasMaxLength(40);

            this.Property(t => t.GreatSummary)
                .HasMaxLength(255);

            this.Property(t => t.Address1)
                .HasMaxLength(50);

            this.Property(t => t.Address2)
                .HasMaxLength(50);

            this.Property(t => t.City)
                .HasMaxLength(20);

            this.Property(t => t.State2)
                .HasMaxLength(255);

            this.Property(t => t.Zip)
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("PropertyListing");
            this.Property(t => t.PropertyId).HasColumnName("PropertyId");
            this.Property(t => t.FK_Account).HasColumnName("FK_Account");
            this.Property(t => t.State).HasColumnName("State");
            this.Property(t => t.PricePerNight).HasColumnName("PricePerNight");
            this.Property(t => t.PricePerMonth).HasColumnName("PricePerMonth");
            this.Property(t => t.PricePerWeek).HasColumnName("PricePerWeek");
            this.Property(t => t.Photos).HasColumnName("Photos");
            this.Property(t => t.GreatTitle).HasColumnName("GreatTitle");
            this.Property(t => t.GreatSummary).HasColumnName("GreatSummary");
            this.Property(t => t.BedRoom).HasColumnName("BedRoom");
            this.Property(t => t.Bathroom).HasColumnName("Bathroom");
            this.Property(t => t.HomeType).HasColumnName("HomeType");
            this.Property(t => t.RoomType).HasColumnName("RoomType");
            this.Property(t => t.Accommodates).HasColumnName("Accommodates");
            this.Property(t => t.Address1).HasColumnName("Address1");
            this.Property(t => t.Address2).HasColumnName("Address2");
            this.Property(t => t.City).HasColumnName("City");
            this.Property(t => t.State2).HasColumnName("State2");
            this.Property(t => t.Zip).HasColumnName("Zip");
            this.Property(t => t.FK__Country).HasColumnName("FK__Country");

            // Relationships
            this.HasRequired(t => t.C_Country)
                .WithMany(t => t.PropertyListings)
                .HasForeignKey(d => d.FK__Country);
            this.HasRequired(t => t.Account)
                .WithMany(t => t.PropertyListings)
                .HasForeignKey(d => d.FK_Account);

        }
    }
}
