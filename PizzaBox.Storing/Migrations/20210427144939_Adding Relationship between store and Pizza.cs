using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaBox.Storing.Migrations
{
    public partial class AddingRelationshipbetweenstoreandPizza : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_Orders_AOrderEntityID",
                table: "Pizzas");

            migrationBuilder.DropIndex(
                name: "IX_Pizzas_AOrderEntityID",
                table: "Pizzas");

            migrationBuilder.DropColumn(
                name: "AOrderEntityID",
                table: "Pizzas");

            migrationBuilder.CreateTable(
                name: "AOrderAPizza",
                columns: table => new
                {
                    OrdersEntityID = table.Column<long>(type: "bigint", nullable: false),
                    PizzasEntityID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AOrderAPizza", x => new { x.OrdersEntityID, x.PizzasEntityID });
                    table.ForeignKey(
                        name: "FK_AOrderAPizza_Orders_OrdersEntityID",
                        column: x => x.OrdersEntityID,
                        principalTable: "Orders",
                        principalColumn: "EntityID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AOrderAPizza_Pizzas_PizzasEntityID",
                        column: x => x.PizzasEntityID,
                        principalTable: "Pizzas",
                        principalColumn: "EntityID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AOrderAPizza_PizzasEntityID",
                table: "AOrderAPizza",
                column: "PizzasEntityID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AOrderAPizza");

            migrationBuilder.AddColumn<long>(
                name: "AOrderEntityID",
                table: "Pizzas",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_AOrderEntityID",
                table: "Pizzas",
                column: "AOrderEntityID");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_Orders_AOrderEntityID",
                table: "Pizzas",
                column: "AOrderEntityID",
                principalTable: "Orders",
                principalColumn: "EntityID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
