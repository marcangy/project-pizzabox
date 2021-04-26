using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaBox.Storing.Migrations
{
    public partial class StoreRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Stores_AStoreEntityID",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_Crusts_CrustEntityID1",
                table: "Pizzas");

            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_Orders_AOrderEntityID1",
                table: "Pizzas");

            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_Sizes_SizeEntityID1",
                table: "Pizzas");

            migrationBuilder.DropIndex(
                name: "IX_Pizzas_AOrderEntityID1",
                table: "Pizzas");

            migrationBuilder.DropIndex(
                name: "IX_Pizzas_CrustEntityID1",
                table: "Pizzas");

            migrationBuilder.DropIndex(
                name: "IX_Pizzas_SizeEntityID1",
                table: "Pizzas");

            migrationBuilder.DropIndex(
                name: "IX_Orders_AStoreEntityID",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "AOrderEntityID1",
                table: "Pizzas");

            migrationBuilder.DropColumn(
                name: "CrustEntityID1",
                table: "Pizzas");

            migrationBuilder.DropColumn(
                name: "SizeEntityID1",
                table: "Pizzas");

            migrationBuilder.DropColumn(
                name: "AStoreEntityID",
                table: "Orders");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "AOrderEntityID1",
                table: "Pizzas",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CrustEntityID1",
                table: "Pizzas",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "SizeEntityID1",
                table: "Pizzas",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "AStoreEntityID",
                table: "Orders",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_AOrderEntityID1",
                table: "Pizzas",
                column: "AOrderEntityID1");

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_CrustEntityID1",
                table: "Pizzas",
                column: "CrustEntityID1");

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_SizeEntityID1",
                table: "Pizzas",
                column: "SizeEntityID1");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AStoreEntityID",
                table: "Orders",
                column: "AStoreEntityID");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Stores_AStoreEntityID",
                table: "Orders",
                column: "AStoreEntityID",
                principalTable: "Stores",
                principalColumn: "EntityID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_Crusts_CrustEntityID1",
                table: "Pizzas",
                column: "CrustEntityID1",
                principalTable: "Crusts",
                principalColumn: "EntityID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_Orders_AOrderEntityID1",
                table: "Pizzas",
                column: "AOrderEntityID1",
                principalTable: "Orders",
                principalColumn: "EntityID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_Sizes_SizeEntityID1",
                table: "Pizzas",
                column: "SizeEntityID1",
                principalTable: "Sizes",
                principalColumn: "EntityID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
