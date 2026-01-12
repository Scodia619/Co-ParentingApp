using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Co_ParentingApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddPairingKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "pairing_key",
                table: "Member",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "pairing_key",
                table: "Member");
        }
    }
}
