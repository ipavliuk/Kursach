using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RentApartment.Core.Models.Mapping
{
    public class AccountMap : EntityTypeConfiguration<Account>
    {
        public AccountMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.AccountId)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.PasswordHash)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.FirstName)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.LastName)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.Email)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.City)
                .HasMaxLength(255);

            this.Property(t => t.Address)
                .HasMaxLength(255);

            this.Property(t => t.Mobile)
                .HasMaxLength(15);

            this.Property(t => t.PostalCode)
                .HasMaxLength(255);

            this.Property(t => t.ImageSourceId)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("Account");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.AccountId).HasColumnName("AccountId");
            this.Property(t => t.PasswordHash).HasColumnName("PasswordHash");
            this.Property(t => t.FirstName).HasColumnName("FirstName");
            this.Property(t => t.LastName).HasColumnName("LastName");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.IsEmailConfirmed).HasColumnName("IsEmailConfirmed");
            this.Property(t => t.FK__Country).HasColumnName("FK__Country");
            this.Property(t => t.FK__Roles).HasColumnName("FK__Roles");
            this.Property(t => t.City).HasColumnName("City");
            this.Property(t => t.Address).HasColumnName("Address");
            this.Property(t => t.Mobile).HasColumnName("Mobile");
            this.Property(t => t.Gender).HasColumnName("Gender");
            this.Property(t => t.PostalCode).HasColumnName("PostalCode");
            this.Property(t => t.Language).HasColumnName("Language");
            this.Property(t => t.IsValidated).HasColumnName("IsValidated");
            this.Property(t => t.ImageSourceId).HasColumnName("ImageSourceId");

            // Relationships
            this.HasRequired(t => t.C_Country)
                .WithMany(t => t.Accounts)
                .HasForeignKey(d => d.FK__Country);
            this.HasRequired(t => t.C_Roles)
                .WithMany(t => t.Accounts)
                .HasForeignKey(d => d.FK__Roles);

        }
    }
}
