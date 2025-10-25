using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryMSApi.Migrations
{
    /// <inheritdoc />
    public partial class AddIsReadNotificationMode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "is_read",
                table: "notifications",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_read",
                table: "notifications");
        }
    }
}
