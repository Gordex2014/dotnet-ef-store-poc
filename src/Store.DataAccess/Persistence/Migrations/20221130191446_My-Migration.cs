using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Store.DataAccess.Persistence.Migrations
{
    public partial class MyMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "parts",
                columns: table => new
                {
                    part_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    part_name = table.Column<string>(type: "text", nullable: false),
                    part_price = table.Column<decimal>(type: "numeric", nullable: false),
                    part_currency = table.Column<string>(type: "text", nullable: false),
                    part_stock = table.Column<int>(type: "integer", nullable: false),
                    part_unit = table.Column<string>(type: "text", nullable: false),
                    part_description = table.Column<string>(type: "text", nullable: true),
                    part_active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_parts", x => x.part_id);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    product_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    product_title = table.Column<string>(type: "text", nullable: false),
                    product_slug = table.Column<string>(type: "text", nullable: false),
                    product_description = table.Column<string>(type: "text", nullable: true),
                    product_price = table.Column<decimal>(type: "numeric", nullable: false),
                    product_currency = table.Column<string>(type: "text", nullable: false),
                    product_stock = table.Column<int>(type: "integer", nullable: false),
                    product_active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.product_id);
                });

            migrationBuilder.CreateTable(
                name: "images",
                columns: table => new
                {
                    image_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    image_url = table.Column<string>(type: "text", nullable: false),
                    image_product_id = table.Column<int>(type: "integer", nullable: false),
                    image_active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_images", x => x.image_id);
                    table.ForeignKey(
                        name: "FK_images_products_image_product_id",
                        column: x => x.image_product_id,
                        principalTable: "products",
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "products_parts",
                columns: table => new
                {
                    product_part_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    product_part_product_id = table.Column<int>(type: "integer", nullable: false),
                    product_part_part_id = table.Column<int>(type: "integer", nullable: false),
                    product_part_parts_required = table.Column<int>(type: "integer", nullable: false),
                    product_part_active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products_parts", x => x.product_part_id);
                    table.ForeignKey(
                        name: "FK_products_parts_parts_product_part_part_id",
                        column: x => x.product_part_part_id,
                        principalTable: "parts",
                        principalColumn: "part_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_products_parts_products_product_part_product_id",
                        column: x => x.product_part_product_id,
                        principalTable: "products",
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "parts",
                columns: new[] { "part_id", "part_active", "part_currency", "part_description", "part_name", "part_price", "part_stock", "part_unit" },
                values: new object[,]
                {
                    { 1, true, "USD", "A simple ASUS cooler", "ASUS Cooler", 30.00m, 30, "piece" },
                    { 2, true, "USD", "A simple RAM module", "Corsair RAM", 56.00m, 25, "piece" },
                    { 3, true, "USD", "Intel Core i7 8th gen", "Intel Core i7", 500.00m, 9, "piece" },
                    { 4, true, "USD", "Monitor stand, just to seel in a combo", "Monitor Stand", 40.00m, 15, "piece" }
                });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "product_id", "product_active", "product_currency", "product_description", "product_price", "product_slug", "product_stock", "product_title" },
                values: new object[,]
                {
                    { 1, true, "USD", "A budget PC, can run a bunch of games in medium quality", 500.00m, "budget-computer", 4, "Budget Computer" },
                    { 2, true, "USD", "Asus keyboard for productivity", 50.00m, "asus-keyboard", 5, "Asus Keyboard" },
                    { 3, true, "USD", "A gaming desktop PC that can run most of the games", 1900.00m, "gaming-pc", 2, "Gaming PC" }
                });

            migrationBuilder.InsertData(
                table: "images",
                columns: new[] { "image_id", "image_active", "image_product_id", "image_url" },
                values: new object[,]
                {
                    { 1, true, 1, "https://cdn.thewirecutter.com/wp-content/media/2021/03/cheap-desktop-pc-2048px-dell-inspiron.jpg" },
                    { 2, true, 1, "https://rukminim1.flixcart.com/image/416/416/kcw9w280/cpu/t/7/t/home-desktop-series-budget-pc-pro-original-imaftwj5hkupvuyn.jpeg?q=70" },
                    { 3, true, 2, "https://ae01.alicdn.com/kf/H73cf9845043d47308a6314fc29e498a9a/US-English-laptop-keyboard-for-ASUS-vivobook-14-X409-x409fa-X409FB-X409DA-X409BA-QWERTY-notebook-pc.jpg_Q90.jpg_.webp" },
                    { 4, true, 3, "https://cdn.shopify.com/s/files/1/0061/7594/8882/products/SY-PCBuild-Frost.png?v=1658745338" }
                });

            migrationBuilder.InsertData(
                table: "products_parts",
                columns: new[] { "product_part_id", "product_part_active", "product_part_part_id", "product_part_parts_required", "product_part_product_id" },
                values: new object[,]
                {
                    { 1, true, 1, 1, 1 },
                    { 2, true, 2, 2, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_images_image_product_id",
                table: "images",
                column: "image_product_id");

            migrationBuilder.CreateIndex(
                name: "IX_products_parts_product_part_part_id",
                table: "products_parts",
                column: "product_part_part_id");

            migrationBuilder.CreateIndex(
                name: "IX_products_parts_product_part_product_id",
                table: "products_parts",
                column: "product_part_product_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "images");

            migrationBuilder.DropTable(
                name: "products_parts");

            migrationBuilder.DropTable(
                name: "parts");

            migrationBuilder.DropTable(
                name: "products");
        }
    }
}
