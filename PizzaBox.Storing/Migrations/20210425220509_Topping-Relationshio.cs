using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaBox.Storing.Migrations
{
    public partial class ToppingRelationshio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "APizzaTopping");

            migrationBuilder.AlterColumn<long>(
                name: "APizzaEntityID",
                table: "Toppings",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "APizzaEntityID1",
                table: "Toppings",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ToppingEntityID",
                table: "Pizzas",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Toppings_APizzaEntityID",
                table: "Toppings",
                column: "APizzaEntityID");

            migrationBuilder.CreateIndex(
                name: "IX_Toppings_APizzaEntityID1",
                table: "Toppings",
                column: "APizzaEntityID1");

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_ToppingEntityID",
                table: "Pizzas",
                column: "ToppingEntityID");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_Toppings_ToppingEntityID",
                table: "Pizzas",
                column: "ToppingEntityID",
                principalTable: "Toppings",
                principalColumn: "EntityID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Toppings_Pizzas_APizzaEntityID",
                table: "Toppings",
                column: "APizzaEntityID",
                principalTable: "Pizzas",
                principalColumn: "EntityID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Toppings_Pizzas_APizzaEntityID1",
                table: "Toppings",
                column: "APizzaEntityID1",
                principalTable: "Pizzas",
                principalColumn: "EntityID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_Toppings_ToppingEntityID",
                table: "Pizzas");

            migrationBuilder.DropForeignKey(
                name: "FK_Toppings_Pizzas_APizzaEntityID",
                table: "Toppings");

            migrationBuilder.DropForeignKey(
                name: "FK_Toppings_Pizzas_APizzaEntityID1",
                table: "Toppings");

            migrationBuilder.DropIndex(
                name: "IX_Toppings_APizzaEntityID",
                table: "Toppings");

            migrationBuilder.DropIndex(
                name: "IX_Toppings_APizzaEntityID1",
                table: "Toppings");

            migrationBuilder.DropIndex(
                name: "IX_Pizzas_ToppingEntityID",
                table: "Pizzas");

            migrationBuilder.DropColumn(
                name: "APizzaEntityID1",
                table: "Toppings");

            migrationBuilder.DropColumn(
                name: "ToppingEntityID",
                table: "Pizzas");

            migrationBuilder.AlterColumn<string>(
                name: "APizzaEntityID",
                table: "Toppings",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "APizzaTopping",
                columns: table => new
                {
                    PizzasEntityID = table.Column<long>(type: "bigint", nullable: false),
                    ToppingsEntityID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APizzaTopping", x => new { x.PizzasEntityID, x.ToppingsEntityID });
                    table.ForeignKey(
                        name: "FK_APizzaTopping_Pizzas_PizzasEntityID",
                        column: x => x.PizzasEntityID,
                        principalTable: "Pizzas",
                        principalColumn: "EntityID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_APizzaTopping_Toppings_ToppingsEntityID",
                        column: x => x.ToppingsEntityID,
                        principalTable: "Toppings",
                        principalColumn: "EntityID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_APizzaTopping_ToppingsEntityID",
                table: "APizzaTopping",
                column: "ToppingsEntityID");
        }
    }
}
