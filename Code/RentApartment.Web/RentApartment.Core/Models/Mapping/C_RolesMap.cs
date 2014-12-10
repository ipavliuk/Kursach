using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RentApartment.Core.Models.Mapping
{
    public class C_RolesMap : EntityTypeConfiguration<C_Roles>
    {
        public C_RolesMap()
        {
            // Primary Key
            this.HasKey(t => t.RoleId);

            // Properties
            this.Property(t => t.RoleName)
                .IsRequired()
                .HasMaxLength(15);

            this.Property(t => t.RoleDescription)
                .HasMaxLength(40);

            // Table & Column Mappings
            this.ToTable("_Roles");
            this.Property(t => t.RoleId).HasColumnName("RoleId");
            this.Property(t => t.RoleName).HasColumnName("RoleName");
            this.Property(t => t.RoleDescription).HasColumnName("RoleDescription");
        }
    }
}
