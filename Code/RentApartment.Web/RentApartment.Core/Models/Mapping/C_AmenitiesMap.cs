using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RentApartment.Core.Models.Mapping
{
    public class C_AmenitiesMap : EntityTypeConfiguration<C_Amenities>
    {
        public C_AmenitiesMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.Description)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("_Amenities");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.IsActive).HasColumnName("IsActive");

            // Relationships
            this.HasMany(t => t.PropertyListings)
                .WithMany(t => t.C_Amenities)
                .Map(m =>
                    {
                        m.ToTable("PropertyListing__Amenities");
                        m.MapLeftKey("FK__Amenities");
                        m.MapRightKey("FK_PropertyListing");
                    });


        }
    }
}
