using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Panaderia_DonDonas_NET_Core.Migrations
{
    public partial class RelationOD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Donut_Id",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Order_Donut_Id",
                table: "Order",
                column: "Donut_Id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Donut_Donut_Id",
                table: "Order",
                column: "Donut_Id",
                principalTable: "Donut",
                principalColumn: "Donut_Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Donut_Donut_Id",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_Donut_Id",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "Donut_Id",
                table: "Order");
        }
    }
}
