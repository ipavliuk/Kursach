using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RentApartment.Core.Models.Mapping
{
    public class MessageMap : EntityTypeConfiguration<Message>
    {
        public MessageMap()
        {
            // Primary Key
            this.HasKey(t => t.MessageId);

            // Properties
            this.Property(t => t.MessageBody)
                .IsRequired()
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("Messages");
            this.Property(t => t.MessageId).HasColumnName("MessageId");
            this.Property(t => t.MessageType).HasColumnName("MessageType");
            this.Property(t => t.MessageStatus).HasColumnName("MessageStatus");
            this.Property(t => t.MessageBody).HasColumnName("MessageBody");
            this.Property(t => t.FK_Account).HasColumnName("FK_Account");

            // Relationships
            this.HasRequired(t => t.Account)
                .WithMany(t => t.Messages)
                .HasForeignKey(d => d.FK_Account);

        }
    }
}
