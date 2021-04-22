using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaBox.Storing.Migrations
{
    public partial class changenamehere : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Crusts",
                columns: table => new
                {
                    EntityID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crusts", x => x.EntityID);
                });

            migrationBuilder.CreateTable(
                name: "RegCustomer",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntityID = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegCustomer", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Sizes",
                columns: table => new
                {
                    EntityID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sizes", x => x.EntityID);
                });

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    EntityID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.EntityID);
                });

            migrationBuilder.CreateTable(
                name: "RegOrder",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntityID = table.Column<long>(type: "bigint", nullable: false),
                    StoreEntityID = table.Column<long>(type: "bigint", nullable: true),
                    CustomerID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegOrder", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RegOrder_RegCustomer_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "RegCustomer",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RegOrder_Stores_StoreEntityID",
                        column: x => x.StoreEntityID,
                        principalTable: "Stores",
                        principalColumn: "EntityID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pizzas",
                columns: table => new
                {
                    EntityID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SizeEntityID = table.Column<long>(type: "bigint", nullable: true),
                    CrustEntityID = table.Column<long>(type: "bigint", nullable: true),
                    TotalPrice = table.Column<double>(type: "float", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegOrderID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizzas", x => x.EntityID);
                    table.ForeignKey(
                        name: "FK_Pizzas_Crusts_CrustEntityID",
                        column: x => x.CrustEntityID,
                        principalTable: "Crusts",
                        principalColumn: "EntityID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pizzas_RegOrder_RegOrderID",
                        column: x => x.RegOrderID,
                        principalTable: "RegOrder",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pizzas_Sizes_SizeEntityID",
                        column: x => x.SizeEntityID,
                        principalTable: "Sizes",
                        principalColumn: "EntityID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Toppings",
                columns: table => new
                {
                    EntityID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    APizzaEntityID = table.Column<long>(type: "bigint", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Toppings", x => x.EntityID);
                    table.ForeignKey(
                        name: "FK_Toppings_Pizzas_APizzaEntityID",
                        column: x => x.APizzaEntityID,
                        principalTable: "Pizzas",
                        principalColumn: "EntityID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_CrustEntityID",
                table: "Pizzas",
                column: "CrustEntityID");

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_RegOrderID",
                table: "Pizzas",
                column: "RegOrderID");

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_SizeEntityID",
                table: "Pizzas",
                column: "SizeEntityID");

            migrationBuilder.CreateIndex(
                name: "IX_RegOrder_CustomerID",
                table: "RegOrder",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_RegOrder_StoreEntityID",
                table: "RegOrder",
                column: "StoreEntityID");

            migrationBuilder.CreateIndex(
                name: "IX_Toppings_APizzaEntityID",
                table: "Toppings",
                column: "APizzaEntityID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Toppings");

            migrationBuilder.DropTable(
                name: "Pizzas");

            migrationBuilder.DropTable(
                name: "Crusts");

            migrationBuilder.DropTable(
                name: "RegOrder");

            migrationBuilder.DropTable(
                name: "Sizes");

            migrationBuilder.DropTable(
                name: "RegCustomer");

            migrationBuilder.DropTable(
                name: "Stores");
        }
    }
}
