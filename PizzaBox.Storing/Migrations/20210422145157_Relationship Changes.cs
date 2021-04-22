using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaBox.Storing.Migrations
{
    public partial class RelationshipChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_RegOrder_RegOrderID",
                table: "Pizzas");

            migrationBuilder.DropForeignKey(
                name: "FK_RegOrder_RegCustomer_CustomerID",
                table: "RegOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_RegOrder_Stores_StoreEntityID",
                table: "RegOrder");

            migrationBuilder.DropIndex(
                name: "IX_Pizzas_RegOrderID",
                table: "Pizzas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RegOrder",
                table: "RegOrder");

            migrationBuilder.DropIndex(
                name: "IX_RegOrder_CustomerID",
                table: "RegOrder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RegCustomer",
                table: "RegCustomer");

            migrationBuilder.DropColumn(
                name: "RegOrderID",
                table: "Pizzas");

            migrationBuilder.DropColumn(
                name: "CustomerID",
                table: "RegOrder");

            migrationBuilder.RenameTable(
                name: "RegOrder",
                newName: "Orders");

            migrationBuilder.RenameTable(
                name: "RegCustomer",
                newName: "Customers");

            migrationBuilder.RenameIndex(
                name: "IX_RegOrder_StoreEntityID",
                table: "Orders",
                newName: "IX_Orders_StoreEntityID");

            migrationBuilder.AddColumn<long>(
                name: "APizzaEntityID1",
                table: "Toppings",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "RegOrderEntityID",
                table: "Pizzas",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "RegOrderEntityID1",
                table: "Pizzas",
                type: "bigint",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "EntityID",
                table: "Orders",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "Orders",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<long>(
                name: "AStoreEntityID",
                table: "Orders",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CustomerEntityID",
                table: "Orders",
                type: "bigint",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "EntityID",
                table: "Customers",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "Customers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "EntityID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "EntityID");

            migrationBuilder.CreateIndex(
                name: "IX_Toppings_APizzaEntityID1",
                table: "Toppings",
                column: "APizzaEntityID1");

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_RegOrderEntityID",
                table: "Pizzas",
                column: "RegOrderEntityID");

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_RegOrderEntityID1",
                table: "Pizzas",
                column: "RegOrderEntityID1");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AStoreEntityID",
                table: "Orders",
                column: "AStoreEntityID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerEntityID",
                table: "Orders",
                column: "CustomerEntityID");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CustomerEntityID",
                table: "Orders",
                column: "CustomerEntityID",
                principalTable: "Customers",
                principalColumn: "EntityID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Stores_AStoreEntityID",
                table: "Orders",
                column: "AStoreEntityID",
                principalTable: "Stores",
                principalColumn: "EntityID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Stores_StoreEntityID",
                table: "Orders",
                column: "StoreEntityID",
                principalTable: "Stores",
                principalColumn: "EntityID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_Orders_RegOrderEntityID",
                table: "Pizzas",
                column: "RegOrderEntityID",
                principalTable: "Orders",
                principalColumn: "EntityID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_Orders_RegOrderEntityID1",
                table: "Pizzas",
                column: "RegOrderEntityID1",
                principalTable: "Orders",
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
                name: "FK_Orders_Customers_CustomerEntityID",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Stores_AStoreEntityID",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Stores_StoreEntityID",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_Orders_RegOrderEntityID",
                table: "Pizzas");

            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_Orders_RegOrderEntityID1",
                table: "Pizzas");

            migrationBuilder.DropForeignKey(
                name: "FK_Toppings_Pizzas_APizzaEntityID1",
                table: "Toppings");

            migrationBuilder.DropIndex(
                name: "IX_Toppings_APizzaEntityID1",
                table: "Toppings");

            migrationBuilder.DropIndex(
                name: "IX_Pizzas_RegOrderEntityID",
                table: "Pizzas");

            migrationBuilder.DropIndex(
                name: "IX_Pizzas_RegOrderEntityID1",
                table: "Pizzas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_AStoreEntityID",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CustomerEntityID",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "APizzaEntityID1",
                table: "Toppings");

            migrationBuilder.DropColumn(
                name: "RegOrderEntityID",
                table: "Pizzas");

            migrationBuilder.DropColumn(
                name: "RegOrderEntityID1",
                table: "Pizzas");

            migrationBuilder.DropColumn(
                name: "AStoreEntityID",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CustomerEntityID",
                table: "Orders");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "RegOrder");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "RegCustomer");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_StoreEntityID",
                table: "RegOrder",
                newName: "IX_RegOrder_StoreEntityID");

            migrationBuilder.AddColumn<int>(
                name: "RegOrderID",
                table: "Pizzas",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "RegOrder",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<long>(
                name: "EntityID",
                table: "RegOrder",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "CustomerID",
                table: "RegOrder",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "RegCustomer",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<long>(
                name: "EntityID",
                table: "RegCustomer",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RegOrder",
                table: "RegOrder",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RegCustomer",
                table: "RegCustomer",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_RegOrderID",
                table: "Pizzas",
                column: "RegOrderID");

            migrationBuilder.CreateIndex(
                name: "IX_RegOrder_CustomerID",
                table: "RegOrder",
                column: "CustomerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_RegOrder_RegOrderID",
                table: "Pizzas",
                column: "RegOrderID",
                principalTable: "RegOrder",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RegOrder_RegCustomer_CustomerID",
                table: "RegOrder",
                column: "CustomerID",
                principalTable: "RegCustomer",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RegOrder_Stores_StoreEntityID",
                table: "RegOrder",
                column: "StoreEntityID",
                principalTable: "Stores",
                principalColumn: "EntityID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
