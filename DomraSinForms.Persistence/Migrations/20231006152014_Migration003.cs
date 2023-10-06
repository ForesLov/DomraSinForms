using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DomraSinForms.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Migration003 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RightAnswerQuestionId",
                table: "Questions",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "QuestionRightAnswers",
                columns: table => new
                {
                    QuestionId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RightAnswer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionRightAnswers", x => x.QuestionId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Questions_RightAnswerQuestionId",
                table: "Questions",
                column: "RightAnswerQuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_QuestionRightAnswers_RightAnswerQuestionId",
                table: "Questions",
                column: "RightAnswerQuestionId",
                principalTable: "QuestionRightAnswers",
                principalColumn: "QuestionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_QuestionRightAnswers_RightAnswerQuestionId",
                table: "Questions");

            migrationBuilder.DropTable(
                name: "QuestionRightAnswers");

            migrationBuilder.DropIndex(
                name: "IX_Questions_RightAnswerQuestionId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "RightAnswerQuestionId",
                table: "Questions");
        }
    }
}
