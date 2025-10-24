using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryMSApi.Migrations
{
    /// <inheritdoc />
    public partial class AddProductFKToNotificationModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "product_id",
                table: "notifications",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "ix_notifications_product_id",
                table: "notifications",
                column: "product_id");

            migrationBuilder.AddForeignKey(
                name: "fk_notifications_products_product_id",
                table: "notifications",
                column: "product_id",
                principalTable: "products",
                principalColumn: "product_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_notifications_products_product_id",
                table: "notifications");

            migrationBuilder.DropIndex(
                name: "ix_notifications_product_id",
                table: "notifications");

            migrationBuilder.DropColumn(
                name: "product_id",
                table: "notifications");
        }
    }
}
