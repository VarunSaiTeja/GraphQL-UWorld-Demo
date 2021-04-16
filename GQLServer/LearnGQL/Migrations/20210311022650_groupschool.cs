using Microsoft.EntityFrameworkCore.Migrations;

namespace LearnGQL.Migrations
{
    public partial class groupschool : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SchoolId",
                table: "Groups",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Groups_SchoolId",
                table: "Groups",
                column: "SchoolId");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Schools_SchoolId",
                table: "Groups",
                column: "SchoolId",
                principalTable: "Schools",
                principalColumn: "SchoolId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Schools_SchoolId",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Groups_SchoolId",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "SchoolId",
                table: "Groups");
        }
    }
}
