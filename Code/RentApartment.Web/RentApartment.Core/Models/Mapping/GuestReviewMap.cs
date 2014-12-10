using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RentApartment.Core.Models.Mapping
{
    public class GuestReviewMap : EntityTypeConfiguration<GuestReview>
    {
        public GuestReviewMap()
        {
            // Primary Key
            this.HasKey(t => t.ReviewId);

            // Properties
            this.Property(t => t.Review)
                .IsRequired()
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("GuestReviews");
            this.Property(t => t.ReviewId).HasColumnName("ReviewId");
            this.Property(t => t.FK_Account).HasColumnName("FK_Account");
            this.Property(t => t.FK_PropertyListing).HasColumnName("FK_PropertyListing");
            this.Property(t => t.Review).HasColumnName("Review");
            this.Property(t => t.RatingScore).HasColumnName("RatingScore");

            // Relationships
            this.HasRequired(t => t.Account)
                .WithMany(t => t.GuestReviews)
                .HasForeignKey(d => d.FK_Account);
            this.HasRequired(t => t.PropertyListing)
                .WithMany(t => t.GuestReviews)
                .HasForeignKey(d => d.FK_PropertyListing);

        }
    }
}
