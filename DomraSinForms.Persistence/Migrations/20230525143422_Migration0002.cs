using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DomraSinForms.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Migration0002 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FormAnswers_FormVersions_FormVersionId",
                table: "FormAnswers");

            migrationBuilder.DropIndex(
                name: "IX_FormAnswers_FormVersionId",
                table: "FormAnswers");

            migrationBuilder.DropColumn(
                name: "FormVersionId",
                table: "FormAnswers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FormVersionId",
                table: "FormAnswers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FormAnswers_FormVersionId",
                table: "FormAnswers",
                column: "FormVersionId");

            migrationBuilder.AddForeignKey(
                name: "FK_FormAnswers_FormVersions_FormVersionId",
                table: "FormAnswers",
                column: "FormVersionId",
                principalTable: "FormVersions",
                principalColumn: "Id");
        }
    }
}
