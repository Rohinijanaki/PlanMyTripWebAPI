using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlanMyTrip.Migrations
{
    /// <inheritdoc />
    public partial class PackageImageTableCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PackageImageTable",
                columns: table => new
                {
                    ImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PId = table.Column<int>(type: "int", nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageImageTable", x => x.ImageId);
                    table.ForeignKey(
                        name: "FK_PackageImageTable_PackageTable_PId",
                        column: x => x.PId,
                        principalTable: "PackageTable",
                        principalColumn: "PackageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PackageImageTable_PId",
                table: "PackageImageTable",
                column: "PId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PackageImageTable");
        }
    }
}
