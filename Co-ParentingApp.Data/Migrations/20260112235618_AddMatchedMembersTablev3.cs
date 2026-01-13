using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Co_ParentingApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddMatchedMembersTablev3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "MatchedMemberId1",
                table: "MatchedMembers",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "MatchingMemberId1",
                table: "MatchedMembers",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_MatchedMembers_MatchedMemberId1",
                table: "MatchedMembers",
                column: "MatchedMemberId1");

            migrationBuilder.CreateIndex(
                name: "IX_MatchedMembers_MatchingMemberId1",
                table: "MatchedMembers",
                column: "MatchingMemberId1");

            migrationBuilder.AddForeignKey(
                name: "FK_MatchedMembers_Member_MatchedMemberId1",
                table: "MatchedMembers",
                column: "MatchedMemberId1",
                principalTable: "Member",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MatchedMembers_Member_MatchingMemberId1",
                table: "MatchedMembers",
                column: "MatchingMemberId1",
                principalTable: "Member",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MatchedMembers_Member_MatchedMemberId1",
                table: "MatchedMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_MatchedMembers_Member_MatchingMemberId1",
                table: "MatchedMembers");

            migrationBuilder.DropIndex(
                name: "IX_MatchedMembers_MatchedMemberId1",
                table: "MatchedMembers");

            migrationBuilder.DropIndex(
                name: "IX_MatchedMembers_MatchingMemberId1",
                table: "MatchedMembers");

            migrationBuilder.DropColumn(
                name: "MatchedMemberId1",
                table: "MatchedMembers");

            migrationBuilder.DropColumn(
                name: "MatchingMemberId1",
                table: "MatchedMembers");
        }
    }
}
