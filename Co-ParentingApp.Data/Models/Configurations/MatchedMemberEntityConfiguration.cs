using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Co_ParentingApp.Data.Models.EntityModels;

namespace Co_ParentingApp.Data.Models.Configurations;

public class MatchedMemberEntityConfiguration : IEntityTypeConfiguration<MatchedMemberEntity>
{
    public void Configure(EntityTypeBuilder<MatchedMemberEntity> builder)
    {
        builder.HasKey(m => m.MatchId);

        builder.Property(m => m.CreatedAt)
               .IsRequired();

        builder.HasOne(m => m.MatchedMember)
               .WithMany()
               .HasForeignKey(m => m.MatchedMemberId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(m => m.MatchingMember)
               .WithMany()
               .HasForeignKey(m => m.MatchingMemberId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(m => new { m.MatchingMemberId, m.MatchedMemberId })
               .IsUnique();

        builder
            .ToTable("MatchedMembers");
    }
}