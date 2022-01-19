using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InspectionApi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InspectionTypeModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InspectionName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionTypeModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatusModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InspectionModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    InspectionTypeId = table.Column<int>(type: "int", nullable: false),
                    InspectionTypeModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InspectionModels_InspectionTypeModels_InspectionTypeModelId",
                        column: x => x.InspectionTypeModelId,
                        principalTable: "InspectionTypeModels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_InspectionModels_InspectionTypeModelId",
                table: "InspectionModels",
                column: "InspectionTypeModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InspectionModels");

            migrationBuilder.DropTable(
                name: "StatusModels");

            migrationBuilder.DropTable(
                name: "InspectionTypeModels");
        }
    }
}
