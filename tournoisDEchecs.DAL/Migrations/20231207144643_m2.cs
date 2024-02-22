using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tournoisDEchecs.DAL.Migrations
{
    /// <inheritdoc />
    public partial class m2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Catrgorie",
                table: "Tournaments",
                newName: "Categorie");

            migrationBuilder.CreateTable(
                name: "TournamentUser",
                columns: table => new
                {
                    UsersId = table.Column<int>(type: "int", nullable: false),
                    tournamentsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TournamentUser", x => new { x.UsersId, x.tournamentsId });
                    table.ForeignKey(
                        name: "FK_TournamentUser_Tournaments_tournamentsId",
                        column: x => x.tournamentsId,
                        principalTable: "Tournaments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TournamentUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TournamentUser_tournamentsId",
                table: "TournamentUser",
                column: "tournamentsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TournamentUser");

            migrationBuilder.RenameColumn(
                name: "Categorie",
                table: "Tournaments",
                newName: "Catrgorie");
        }
    }
}
