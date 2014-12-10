using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RentApartment.Core.Models.Mapping
{
    public class C_CountryMap : EntityTypeConfiguration<C_Country>
    {
        public C_CountryMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.IsoCode)
                .IsRequired()
                .HasMaxLength(2);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("_Country");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.IsoCode).HasColumnName("IsoCode");
            this.Property(t => t.Name).HasColumnName("Name");
        }
    }
}
