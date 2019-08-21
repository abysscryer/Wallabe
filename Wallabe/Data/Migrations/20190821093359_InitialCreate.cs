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
                    Status = table.Column<int>(nullable: false),
                    ImagePath = table.Column<string>(type: "varchar(256)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cranes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(36)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(32)", nullable: false),
                    ImagePath = table.Column<string>(type: "varchar(256)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dolls",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(36)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(32)", nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    ImagePath = table.Column<string>(type: "varchar(256)", nullable: true),
                    OnCreated = table.Column<DateTime>(nullable: false),
                    CraneId = table.Column<string>(nullable: true)
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
                name: "CraneRecords",
                columns: table => new
                {
                    Date = table.Column<string>(type: "char(8)", nullable: false),
                    CraneId = table.Column<string>(nullable: false),
                    PlayerId = table.Column<string>(nullable: false),
                    Rank = table.Column<int>(nullable: false),
                    Shift = table.Column<int>(nullable: false),
                    Try = table.Column<int>(nullable: false),
                    Hit = table.Column<int>(nullable: false),
                    Rate = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CraneRecords", x => new { x.Date, x.CraneId, x.PlayerId });
                    table.ForeignKey(
                        name: "FK_CraneRecords_Cranes_CraneId",
                        column: x => x.CraneId,
                        principalTable: "Cranes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CraneRecords_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(36)", nullable: false),
                    PlayerId = table.Column<string>(nullable: false),
                    CraneId = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    State = table.Column<bool>(nullable: false),
                    OnCreated = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    OnUpdated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_Players_CraneId",
                        column: x => x.CraneId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Games_Cranes_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Cranes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Records",
                columns: table => new
                {
                    Date = table.Column<string>(type: "char(8)", nullable: false),
                    PlayerId = table.Column<string>(nullable: false),
                    Rank = table.Column<int>(nullable: false),
                    Shift = table.Column<int>(nullable: false),
                    Try = table.Column<int>(nullable: false),
                    Hit = table.Column<int>(nullable: false),
                    Rate = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Records", x => new { x.Date, x.PlayerId });
                    table.ForeignKey(
                        name: "FK_Records_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Plays",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(36)", nullable: false),
                    GameId = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    State = table.Column<int>(nullable: false),
                    OnCreated = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plays_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CraneRecords_CraneId",
                table: "CraneRecords",
                column: "CraneId");

            migrationBuilder.CreateIndex(
                name: "IX_CraneRecords_PlayerId",
                table: "CraneRecords",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Dolls_CraneId",
                table: "Dolls",
                column: "CraneId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_CraneId",
                table: "Games",
                column: "CraneId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_PlayerId",
                table: "Games",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Plays_GameId",
                table: "Plays",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Records_PlayerId",
                table: "Records",
                column: "PlayerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CraneRecords");

            migrationBuilder.DropTable(
                name: "Dolls");

            migrationBuilder.DropTable(
                name: "Plays");

            migrationBuilder.DropTable(
                name: "Records");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Cranes");
        }
    }
}
