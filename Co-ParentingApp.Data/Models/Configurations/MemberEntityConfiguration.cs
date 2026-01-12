using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Co_ParentingApp.Data.Models.EntityModels;

namespace Co_ParentingApp.Data.Models.Configurations
{
    public class MemberEntityConfiguration : IEntityTypeConfiguration<MemberEntity>
    {
        public void Configure(EntityTypeBuilder<MemberEntity> builder)
        {
            builder
                .HasKey(m => m.Id);

            builder
                .Property(m => m.Id)
                .HasColumnName("id");

            builder
                .Property(m => m.CreatedAt)
                .HasColumnName("created_at");

            builder
                .Property(m => m.Email)
                .HasColumnName("email");

            builder
                .Property(m => m.Username)
                .HasColumnName("username");

            builder
                .Property(m => m.Password)
                .HasColumnName("password");

            builder
                .Property(m => m.PairingKey)
                .HasColumnName("pairing_key");

            builder
                .ToTable("Member");
        }
    }
}
