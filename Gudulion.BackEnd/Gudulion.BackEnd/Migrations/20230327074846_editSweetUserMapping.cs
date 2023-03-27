using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gudulion.BackEnd.Migrations
{
    /// <inheritdoc />
    public partial class editSweetUserMapping : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserSweetMappigns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    SweetId = table.Column<int>(type: "int", nullable: false),
                    IsPayer = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSweetMappigns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSweetMappigns_Sweets_SweetId",
                        column: x => x.SweetId,
                        principalTable: "Sweets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserSweetMappigns_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserSweetMappigns_SweetId",
                table: "UserSweetMappigns",
                column: "SweetId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSweetMappigns_UserId",
                table: "UserSweetMappigns",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserSweetMappigns");
        }
    }
}
