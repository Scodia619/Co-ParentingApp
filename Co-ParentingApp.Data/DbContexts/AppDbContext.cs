using Co_ParentingApp.Data.Models.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace Co_ParentingApp.Data.DbContexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { }

    public DbSet<MemberEntity> Member { get; set; }
    public DbSet<MatchedMemberEntity> MatchedMembers { get; set; }
    public DbSet<MessageEntity> Message { get; set; }
    public DbSet<ConversationEntity> Conversation { get; set; }
    public DbSet<ConversationMembersEntity> ConversationMembers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}