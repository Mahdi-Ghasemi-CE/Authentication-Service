using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Authentication_Service.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddIndexToRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "Index_SystemName",
                table: "Roles",
                column: "SystemName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "Index_SystemName",
                table: "Roles");
        }
    }
}
