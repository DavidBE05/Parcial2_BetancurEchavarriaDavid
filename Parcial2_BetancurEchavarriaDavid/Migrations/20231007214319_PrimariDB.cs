using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Parcial2_BetancurEchavarriaDavid.Migrations
{
    public partial class PrimariDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NaturalPeople",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BirthYear = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NaturalPeople", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NaturalPeople_Email",
                table: "NaturalPeople",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NaturalPeople_FullName",
                table: "NaturalPeople",
                column: "FullName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NaturalPeople");
        }
    }
}
