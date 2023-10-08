using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DomraSinForms.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Migration004 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FormAnswers_AspNetUsers_UserId",
                table: "FormAnswers");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "FormAnswers",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "Nickname",
                table: "FormAnswers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FormAnswers_AspNetUsers_UserId",
                table: "FormAnswers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FormAnswers_AspNetUsers_UserId",
                table: "FormAnswers");

            migrationBuilder.DropColumn(
                name: "Nickname",
                table: "FormAnswers");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "FormAnswers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FormAnswers_AspNetUsers_UserId",
                table: "FormAnswers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
