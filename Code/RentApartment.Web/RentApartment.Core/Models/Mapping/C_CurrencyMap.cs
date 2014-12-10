using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RentApartment.Core.Models.Mapping
{
    public class C_CurrencyMap : EntityTypeConfiguration<C_Currency>
    {
        public C_CurrencyMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Country)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.Currency)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.Code)
                .IsRequired()
                .HasMaxLength(3);

            this.Property(t => t.Symbol)
                .IsRequired()
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("_Currency");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Country).HasColumnName("Country");
            this.Property(t => t.Currency).HasColumnName("Currency");
            this.Property(t => t.Code).HasColumnName("Code");
            this.Property(t => t.Symbol).HasColumnName("Symbol");
        }
    }
}
