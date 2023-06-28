using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Panaderia_DonDonas_NET_Core.Migrations
{
    public partial class RelationOneToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Order_Donut_Id",
                table: "Order");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Donut_Id",
                table: "Order",
                column: "Donut_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Order_Donut_Id",
                table: "Order");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Donut_Id",
                table: "Order",
                column: "Donut_Id",
                unique: true);
        }
    }
}
