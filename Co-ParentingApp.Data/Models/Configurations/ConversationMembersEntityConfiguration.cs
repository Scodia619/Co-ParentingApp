using Co_ParentingApp.Data.Models.EntityModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Co_ParentingApp.Data.Models.Configurations;

public class ConversationMembersEntityConfiguration : IEntityTypeConfiguration<ConversationMembersEntity>
{
    public void Configure(EntityTypeBuilder<ConversationMembersEntity> builder)
    {
        // Primary Key
        builder.HasKey(cm => cm.ConversationMemberId);

        builder.Property(cm => cm.ConversationId).IsRequired();
        builder.Property(cm => cm.MemberId).IsRequired();
        builder.Property(cm => cm.JoinedAt).IsRequired();
        builder.Property(cm => cm.LastReadAt).IsRequired(false);

        builder.HasOne(cm => cm.Conversation)
               .WithMany(c => c.Members)
               .HasForeignKey(cm => cm.ConversationId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(cm => cm.Member)
               .WithMany()
               .HasForeignKey(cm => cm.MemberId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(cm => new { cm.ConversationId, cm.MemberId })
               .IsUnique();

        builder.ToTable("ConversationMembers");
    }
}