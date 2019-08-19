using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wallabe.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cranes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(36)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(32)", nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cranes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dolls",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(36)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(32)", nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    OnCreated = table.Column<DateTime>(nullable: false),
                    CraneId = table.Column<string>(nullable: true),
                    ImaagePath = table.Column<string>(type: "varchar(256)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dolls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dolls_Cranes_CraneId",
                        column: x => x.CraneId,
                        principalTable: "Cranes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ranks",
                columns: table => new
                {
                    Date = table.Column<string>(type: "char(8)", nullable: false),
                    Craneid = table.Column<string>(nullable: false),
                    PlayerId = table.Column<string>(nullable: false),
                    Try = table.Column<int>(nullable: false),
                    Hit = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ranks", x => new { x.Date, x.Craneid, x.PlayerId });
                    table.ForeignKey(
                        name: "FK_Ranks_Cranes_Craneid",
                        column: x => x.Craneid,
                        principalTable: "Cranes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dolls_CraneId",
                table: "Dolls",
                column: "CraneId");

            migrationBuilder.CreateIndex(
                name: "IX_Ranks_Craneid",
                table: "Ranks",
                column: "Craneid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dolls");

            migrationBuilder.DropTable(
                name: "Ranks");

            migrationBuilder.DropTable(
                name: "Cranes");
        }
    }
}
