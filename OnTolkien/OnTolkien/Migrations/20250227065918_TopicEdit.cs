using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnTolkien.Migrations
{
    public partial class TopicEdit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stories_Topics_TopicId",
                table: "Stories");

            migrationBuilder.UpdateData(
                table: "Stories",
                keyColumn: "TopicId",
                keyValue: null,
                column: "TopicId",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "TopicId",
                table: "Stories",
                type: "varchar(1)",
                maxLength: 1,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(1)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_Stories_Topics_TopicId",
                table: "Stories",
                column: "TopicId",
                principalTable: "Topics",
                principalColumn: "TopicId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stories_Topics_TopicId",
                table: "Stories");

            migrationBuilder.AlterColumn<string>(
                name: "TopicId",
                table: "Stories",
                type: "varchar(1)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(1)",
                oldMaxLength: 1)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_Stories_Topics_TopicId",
                table: "Stories",
                column: "TopicId",
                principalTable: "Topics",
                principalColumn: "TopicId");
        }
    }
}
