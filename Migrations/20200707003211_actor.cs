using Microsoft.EntityFrameworkCore.Migrations;

namespace Online_Exam_Management_System.Migrations
{
    public partial class actor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Actors_ActorId",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "ActorId",
                table: "Users",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Actors_ActorId",
                table: "Users",
                column: "ActorId",
                principalTable: "Actors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Actors_ActorId",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "ActorId",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Actors_ActorId",
                table: "Users",
                column: "ActorId",
                principalTable: "Actors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
