using Co_ParentingApp.Data.Models.EntityModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Co_ParentingApp.Data.Models.Configurations;
public class ConversationEntityConfiguration : IEntityTypeConfiguration<ConversationEntity>
{
    public void Configure(EntityTypeBuilder<ConversationEntity> builder)
    {
        builder.HasKey(c => c.ConversationId);

        builder.Property(c => c.CreatedAt).IsRequired();

        builder.Property(c => c.LastMessage)
                .IsRequired(false)
                .HasMaxLength(500);

        builder.Property(c => c.LastMessageAt)
            .IsRequired(false);

        builder.HasMany(c => c.Members)
               .WithOne(cm => cm.Conversation)
               .HasForeignKey(cm => cm.ConversationId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(c => c.Messages)
               .WithOne(m => m.Conversation)
               .HasForeignKey(m => m.ConversationId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.ToTable("Conversations");
    }
}
