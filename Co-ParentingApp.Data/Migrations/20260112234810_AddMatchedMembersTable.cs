using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Co_ParentingApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddMatchedMembersTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                    name: "MatchedMembers",
                    columns: table => new
                    {
                        MatchId = table.Column<Guid>(type: "uuid", nullable: false),
                        MatchingMemberId = table.Column<Guid>(type: "uuid", nullable: false),
                        MatchedMemberId = table.Column<Guid>(type: "uuid", nullable: false),
                        CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                    },
                    constraints: table =>
                    {
                        table.PrimaryKey("PK_MatchedMembers", x => x.MatchId);
                        table.ForeignKey(
                            name: "FK_MatchedMembers_Member_MatchingMemberId",
                            column: x => x.MatchingMemberId,
                            principalTable: "Member",
                            principalColumn: "id",
                            onDelete: ReferentialAction.Restrict);
                        table.ForeignKey(
                            name: "FK_MatchedMembers_Member_MatchedMemberId",
                            column: x => x.MatchedMemberId,
                            principalTable: "Member",
                            principalColumn: "id",
                            onDelete: ReferentialAction.Restrict);
                    });

            migrationBuilder.CreateIndex(
                name: "IX_MatchedMembers_MatchingMemberId_MatchedMemberId",
                table: "MatchedMembers",
                columns: new[] { "MatchingMemberId", "MatchedMemberId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MatchedMembers_MatchedMemberId",
                table: "MatchedMembers",
                column: "MatchedMemberId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
