using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RentApartment.Core.Models.Mapping
{
    public class ReservationMap : EntityTypeConfiguration<Reservation>
    {
        public ReservationMap()
        {
            // Primary Key
            this.HasKey(t => t.ReservationId);

            // Properties
            this.Property(t => t.ReservationNote)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("Reservations");
            this.Property(t => t.ReservationId).HasColumnName("ReservationId");
            this.Property(t => t.FK_Account).HasColumnName("FK_Account");
            this.Property(t => t.FK_PropertyListing).HasColumnName("FK_PropertyListing");
            this.Property(t => t.ReservationStatus).HasColumnName("ReservationStatus");
            this.Property(t => t.ReservationStart).HasColumnName("ReservationStart");
            this.Property(t => t.ReservationEnd).HasColumnName("ReservationEnd");
            this.Property(t => t.ReservationNote).HasColumnName("ReservationNote");
            this.Property(t => t.FK__Currency).HasColumnName("FK__Currency");

            // Relationships
            this.HasRequired(t => t.C_Currency)
                .WithMany(t => t.Reservations)
                .HasForeignKey(d => d.FK__Currency);
            this.HasRequired(t => t.Account)
                .WithMany(t => t.Reservations)
                .HasForeignKey(d => d.FK_Account);
            this.HasRequired(t => t.PropertyListing)
                .WithMany(t => t.Reservations)
                .HasForeignKey(d => d.FK_PropertyListing);

        }
    }
}
