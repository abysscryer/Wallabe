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
                    ImagePath = table.Column<string>(type: "varchar(256)", nullable: true),
                    Cash = table.Column<int>(nullable: false)
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
                    OnCreated = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
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
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(36)", nullable: false),
                    CraneId = table.Column<string>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Cash = table.Column<int>(nullable: false),
                    OnCreated = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Cranes_CraneId",
                        column: x => x.CraneId,
                        principalTable: "Cranes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(36)", nullable: false),
                    OnCreated = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    PlayerId = table.Column<string>(nullable: false),
                    ProductId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
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
                    OrderId = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    State = table.Column<int>(nullable: false),
                    OnCreated = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    OnUpdated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_Cranes_CraneId",
                        column: x => x.CraneId,
                        principalTable: "Cranes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Games_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Games_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.InsertData(
                table: "Cranes",
                columns: new[] { "Id", "ImagePath", "Name", "Status" },
                values: new object[,]
                {
                    { "42ba9d7d-62ba-4958-87a7-1bef9df38674", "42ba9d7d-62ba-4958-87a7-1bef9df38674", "원피스", 0 },
                    { "ce7ea78e-56d6-49db-bb84-4165e3c958e9", "ce7ea78e-56d6-49db-bb84-4165e3c958e9", "포켓몬", 0 }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "Cash", "ImagePath", "Name" },
                values: new object[,]
                {
                    { "c09c1133-242d-43f8-9ce6-afac824b88c0", 100000000, "748960dc-70cd-4d9d-a470-3f9445d89183", "이니" },
                    { "8558b62a-7e15-4083-b6d7-cd199839fd31", 100000000, "248528e4-f59e-445e-9899-6c8d465c5479", "혀니" }
                });

            migrationBuilder.InsertData(
                table: "Dolls",
                columns: new[] { "Id", "CraneId", "ImagePath", "Name", "OnCreated", "Quantity" },
                values: new object[,]
                {
                    { "61c59cb6-1ba6-4a3a-9d89-e9f0c6504ef6", "42ba9d7d-62ba-4958-87a7-1bef9df38674", "61c59cb6-1ba6-4a3a-9d89-e9f0c6504ef6", "루피", new DateTime(2019, 8, 22, 12, 5, 0, 0, DateTimeKind.Local), 10 },
                    { "c69a518d-1dc5-4939-91cb-4dec75c08733", "42ba9d7d-62ba-4958-87a7-1bef9df38674", "c69a518d-1dc5-4939-91cb-4dec75c08733", "조로", new DateTime(2019, 8, 22, 12, 10, 0, 0, DateTimeKind.Local), 10 },
                    { "c3e7202c-c7cc-4e18-b8dc-2c4f259e7aa2", "ce7ea78e-56d6-49db-bb84-4165e3c958e9", "c3e7202c-c7cc-4e18-b8dc-2c4f259e7aa2", "피카츄", new DateTime(2019, 8, 22, 12, 15, 0, 0, DateTimeKind.Local), 10 },
                    { "e5bdc11d-9194-4e06-a1dc-a33226512692", "ce7ea78e-56d6-49db-bb84-4165e3c958e9", "e5bdc11d-9194-4e06-a1dc-a33226512692", "파이리", new DateTime(2019, 8, 22, 12, 20, 0, 0, DateTimeKind.Local), 10 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Cash", "CraneId", "OnCreated", "Quantity" },
                values: new object[,]
                {
                    { "b9fe5e69-cc69-4354-b0ff-557c54392a21", 1000, "42ba9d7d-62ba-4958-87a7-1bef9df38674", new DateTime(2019, 8, 22, 12, 1, 0, 0, DateTimeKind.Local), 1 },
                    { "d25830d7-1523-487e-86ea-bdb9ce224d59", 2000, "42ba9d7d-62ba-4958-87a7-1bef9df38674", new DateTime(2019, 8, 22, 12, 1, 0, 0, DateTimeKind.Local), 2 },
                    { "d17babcb-ab39-4fd9-9f2e-8ae4529e92a0", 3000, "42ba9d7d-62ba-4958-87a7-1bef9df38674", new DateTime(2019, 8, 22, 12, 3, 0, 0, DateTimeKind.Local), 3 },
                    { "b59a1e20-f31e-4d0f-a72e-489013ce7170", 4000, "42ba9d7d-62ba-4958-87a7-1bef9df38674", new DateTime(2019, 8, 22, 12, 4, 0, 0, DateTimeKind.Local), 4 },
                    { "efdf197e-cd23-4b44-9cbe-caac4809309d", 5000, "42ba9d7d-62ba-4958-87a7-1bef9df38674", new DateTime(2019, 8, 22, 12, 5, 0, 0, DateTimeKind.Local), 5 },
                    { "d57567b0-cb03-4410-a517-383ca9880904", 1000, "ce7ea78e-56d6-49db-bb84-4165e3c958e9", new DateTime(2019, 8, 22, 12, 6, 0, 0, DateTimeKind.Local), 1 },
                    { "46aeb3db-80ab-437d-9b34-4e553633461e", 2000, "ce7ea78e-56d6-49db-bb84-4165e3c958e9", new DateTime(2019, 8, 22, 12, 7, 0, 0, DateTimeKind.Local), 2 },
                    { "c7c8de70-b9c1-4df0-8520-340c16e1f585", 3000, "ce7ea78e-56d6-49db-bb84-4165e3c958e9", new DateTime(2019, 8, 22, 12, 8, 0, 0, DateTimeKind.Local), 3 },
                    { "f1afa3d7-4df8-4766-92be-e522110f7dae", 4000, "ce7ea78e-56d6-49db-bb84-4165e3c958e9", new DateTime(2019, 8, 22, 12, 9, 0, 0, DateTimeKind.Local), 4 },
                    { "7da6f8d6-eb6a-4466-8b1b-cb7d470d88b8", 5000, "ce7ea78e-56d6-49db-bb84-4165e3c958e9", new DateTime(2019, 8, 22, 12, 10, 0, 0, DateTimeKind.Local), 5 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "OnCreated", "PlayerId", "ProductId" },
                values: new object[,]
                {
                    { "b3fb6608-5597-4cbf-8cd1-ba74399ee308", new DateTime(2019, 8, 22, 12, 15, 0, 0, DateTimeKind.Local), "c09c1133-242d-43f8-9ce6-afac824b88c0", "b9fe5e69-cc69-4354-b0ff-557c54392a21" },
                    { "516dab55-308c-4741-af35-7733c316dbd2", new DateTime(2019, 8, 22, 12, 25, 0, 0, DateTimeKind.Local), "8558b62a-7e15-4083-b6d7-cd199839fd31", "b9fe5e69-cc69-4354-b0ff-557c54392a21" },
                    { "b3592c2e-6e78-4ebe-a494-ae00e5dbaeeb", new DateTime(2019, 8, 22, 12, 20, 0, 0, DateTimeKind.Local), "c09c1133-242d-43f8-9ce6-afac824b88c0", "d57567b0-cb03-4410-a517-383ca9880904" },
                    { "58b773a5-2bb7-4106-a510-d4ab8ac0bbad", new DateTime(2019, 8, 22, 12, 30, 0, 0, DateTimeKind.Local), "8558b62a-7e15-4083-b6d7-cd199839fd31", "d57567b0-cb03-4410-a517-383ca9880904" }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "CraneId", "OnCreated", "OnUpdated", "OrderId", "PlayerId", "State", "Status" },
                values: new object[,]
                {
                    { "322173e1-9821-4026-a0c2-cecd97ea3f64", "42ba9d7d-62ba-4958-87a7-1bef9df38674", new DateTime(2019, 8, 22, 12, 15, 0, 0, DateTimeKind.Local), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "b3fb6608-5597-4cbf-8cd1-ba74399ee308", "c09c1133-242d-43f8-9ce6-afac824b88c0", 1, 2 },
                    { "91763ee1-382c-43b6-bcff-0c7146400544", "42ba9d7d-62ba-4958-87a7-1bef9df38674", new DateTime(2019, 8, 22, 12, 25, 0, 0, DateTimeKind.Local), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "516dab55-308c-4741-af35-7733c316dbd2", "8558b62a-7e15-4083-b6d7-cd199839fd31", 2, 2 },
                    { "cf04144b-846b-450c-8d5e-35c11a64acd3", "ce7ea78e-56d6-49db-bb84-4165e3c958e9", new DateTime(2019, 8, 22, 12, 20, 0, 0, DateTimeKind.Local), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "b3592c2e-6e78-4ebe-a494-ae00e5dbaeeb", "c09c1133-242d-43f8-9ce6-afac824b88c0", 2, 2 },
                    { "16259d75-2244-4bcc-b0e7-73a20d5d2243", "ce7ea78e-56d6-49db-bb84-4165e3c958e9", new DateTime(2019, 8, 22, 12, 30, 0, 0, DateTimeKind.Local), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "58b773a5-2bb7-4106-a510-d4ab8ac0bbad", "8558b62a-7e15-4083-b6d7-cd199839fd31", 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "Plays",
                columns: new[] { "Id", "GameId", "OnCreated", "State", "Status" },
                values: new object[,]
                {
                    { "aa7e7fa8-07df-4368-85b1-74f0dfde0ac0", "322173e1-9821-4026-a0c2-cecd97ea3f64", new DateTime(2019, 8, 22, 12, 31, 0, 0, DateTimeKind.Local), 0, 0 },
                    { "e835a48a-f0e9-4a83-96ae-886d7cb6fb48", "322173e1-9821-4026-a0c2-cecd97ea3f64", new DateTime(2019, 8, 22, 12, 32, 0, 0, DateTimeKind.Local), 0, 1 },
                    { "119355fd-dc13-45fe-a5bb-122f727c58b3", "322173e1-9821-4026-a0c2-cecd97ea3f64", new DateTime(2019, 8, 22, 12, 33, 0, 0, DateTimeKind.Local), 1, 2 },
                    { "0a4cc44f-d7e9-41df-9ae7-f2930afb3134", "91763ee1-382c-43b6-bcff-0c7146400544", new DateTime(2019, 8, 22, 12, 37, 0, 0, DateTimeKind.Local), 0, 0 },
                    { "b763531b-fb5e-4e87-9c78-c7b8f4fcad7e", "91763ee1-382c-43b6-bcff-0c7146400544", new DateTime(2019, 8, 22, 12, 38, 0, 0, DateTimeKind.Local), 0, 1 },
                    { "2b187756-fadb-4b2a-85d3-30c5219c78a5", "91763ee1-382c-43b6-bcff-0c7146400544", new DateTime(2019, 8, 22, 12, 39, 0, 0, DateTimeKind.Local), 2, 2 },
                    { "f8449d35-6217-4c27-8eef-9dabda971081", "cf04144b-846b-450c-8d5e-35c11a64acd3", new DateTime(2019, 8, 22, 12, 34, 0, 0, DateTimeKind.Local), 0, 0 },
                    { "93e46c07-3261-466c-91de-4423166d9227", "cf04144b-846b-450c-8d5e-35c11a64acd3", new DateTime(2019, 8, 22, 12, 35, 0, 0, DateTimeKind.Local), 0, 1 },
                    { "2fc59b99-891d-4aa3-ada5-132414094e0d", "cf04144b-846b-450c-8d5e-35c11a64acd3", new DateTime(2019, 8, 22, 12, 36, 0, 0, DateTimeKind.Local), 2, 2 },
                    { "c6d31ffa-8e26-41d9-8347-3322c1c4ca27", "16259d75-2244-4bcc-b0e7-73a20d5d2243", new DateTime(2019, 8, 22, 12, 40, 0, 0, DateTimeKind.Local), 0, 0 },
                    { "1f1e4209-d122-473d-adbf-ef4b70dc233a", "16259d75-2244-4bcc-b0e7-73a20d5d2243", new DateTime(2019, 8, 22, 12, 41, 0, 0, DateTimeKind.Local), 0, 1 },
                    { "d9b0e57a-40af-420f-8989-ebed4b8b8ec1", "16259d75-2244-4bcc-b0e7-73a20d5d2243", new DateTime(2019, 8, 22, 12, 42, 0, 0, DateTimeKind.Local), 1, 2 }
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
                name: "IX_Games_OrderId",
                table: "Games",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_PlayerId",
                table: "Games",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PlayerId",
                table: "Orders",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ProductId",
                table: "Orders",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Plays_GameId",
                table: "Plays",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CraneId",
                table: "Products",
                column: "CraneId");

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
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Cranes");
        }
    }
}
