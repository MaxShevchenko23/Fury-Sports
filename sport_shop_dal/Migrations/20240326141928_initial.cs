using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sportshopdal.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nchar(15)", fixedLength: true, maxLength: 15, nullable: false),
                    rootcategoryid = table.Column<int>(name: "root_category_id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    categoryid = table.Column<int>(name: "category_id", type: "int", nullable: false),
                    manufacturerid = table.Column<int>(name: "manufacturer_id", type: "int", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "manufacturers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nchar(20)", fixedLength: true, maxLength: 20, nullable: false),
                    country = table.Column<string>(type: "nchar(20)", fixedLength: true, maxLength: 20, nullable: false),
                    maincategoryid = table.Column<int>(name: "main_category_id", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_manufacturers", x => x.id);
                    table.ForeignKey(
                        name: "FK_manufacturers_categories",
                        column: x => x.maincategoryid,
                        principalTable: "categories",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "specifications",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productid = table.Column<int>(name: "product_id", type: "int", nullable: false),
                    specificationname = table.Column<string>(name: "specification_name", type: "nvarchar(50)", maxLength: 50, nullable: false),
                    specificationvalue = table.Column<string>(name: "specification_value", type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_specifications", x => x.id);
                    table.ForeignKey(
                        name: "FK_specifications_products",
                        column: x => x.productid,
                        principalTable: "products",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_manufacturers_main_category_id",
                table: "manufacturers",
                column: "main_category_id");

            migrationBuilder.CreateIndex(
                name: "IX_specifications_product_id",
                table: "specifications",
                column: "product_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "manufacturers");

            migrationBuilder.DropTable(
                name: "specifications");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "products");
        }
    }
}
