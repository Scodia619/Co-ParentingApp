using Co_ParentingApp.Data.Models.EntityModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Co_ParentingApp.Data.Models.Configurations;

public class MessageEntityConfiguration : IEntityTypeConfiguration<MessageEntity>
{
    public void Configure(EntityTypeBuilder<MessageEntity> builder)
    {
        builder
            .HasKey(m => m.MessageId);

        builder.Property(m => m.Content)
               .IsRequired();

        builder.Property(m => m.CreatedAt)
               .IsRequired();

        builder.HasOne(m => m.Conversation)
               .WithMany(c => c.Messages)
               .HasForeignKey(m => m.ConversationId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(m => m.Sender)
               .WithMany() 
               .HasForeignKey(m => m.SenderId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(m => m.ConversationId);

        builder.ToTable("Message");
    }
}