using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace P01_BillsPaymentSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class _01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BankAccounts",
                columns: table => new
                {
                    BankAccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BankName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SwiftCode = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccounts", x => x.BankAccountId);
                });

            migrationBuilder.CreateTable(
                name: "CreditCards",
                columns: table => new
                {
                    CreditCardId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExpirationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Limit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MoneyOwed = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditCards", x => x.CreditCardId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethods",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BankAccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreditCardId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentMethods_BankAccounts_BankAccountId",
                        column: x => x.BankAccountId,
                        principalTable: "BankAccounts",
                        principalColumn: "BankAccountId");
                    table.ForeignKey(
                        name: "FK_PaymentMethods_CreditCards_CreditCardId",
                        column: x => x.CreditCardId,
                        principalTable: "CreditCards",
                        principalColumn: "CreditCardId");
                    table.ForeignKey(
                        name: "FK_PaymentMethods_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BankAccounts",
                columns: new[] { "BankAccountId", "Balance", "BankName", "SwiftCode" },
                values: new object[,]
                {
                    { new Guid("56eef454-43b7-423b-82a1-f2f037fb0715"), 2398.355037420498100m, "Lodge Universal", "728" },
                    { new Guid("6755bfa3-0918-4304-89c8-2ff90d7c1fe2"), 9211.565137879586800m, "Buckinghamshire deposit Regional", "109" },
                    { new Guid("86c23800-c0ee-4a15-b4ac-c40eba775ad8"), 3696.02815504962700m, "Vanuatu Expanded redundant", "036" },
                    { new Guid("a308f252-19f5-4210-a590-261c0acff7d7"), 8257.86629626038400m, "mobile", "562" },
                    { new Guid("f8d5ba05-f933-462e-91b9-b8b53a67f4bd"), 8837.358287886226900m, "North Carolina compressing driver", "462" }
                });

            migrationBuilder.InsertData(
                table: "CreditCards",
                columns: new[] { "CreditCardId", "ExpirationTime", "Limit", "MoneyOwed" },
                values: new object[,]
                {
                    { new Guid("00798a00-a882-4af2-9093-ab7f822cf1d9"), new DateTime(2030, 2, 17, 12, 19, 54, 354, DateTimeKind.Local).AddTicks(6661), 3289.282970017546000m, 9367.462648339110000m },
                    { new Guid("0aa6cd06-1437-49fe-9492-844af8960eb9"), new DateTime(2030, 7, 1, 14, 3, 51, 251, DateTimeKind.Local).AddTicks(2480), 7095.353009019769000m, 9529.472757036390000m },
                    { new Guid("21462c4b-eb60-4a7f-9062-11fe1625c1d5"), new DateTime(2024, 4, 7, 7, 48, 10, 650, DateTimeKind.Local).AddTicks(9445), 5552.720171514892000m, 9277.626410303450000m },
                    { new Guid("44ffae60-2f9a-41d0-ac89-7251910dc8dd"), new DateTime(2024, 12, 30, 11, 26, 49, 71, DateTimeKind.Local).AddTicks(6881), 3985.343487140356000m, 5366.485504064230000m },
                    { new Guid("b8edcdac-a6d9-41ea-b62d-48f0904f8353"), new DateTime(2032, 7, 26, 1, 47, 37, 600, DateTimeKind.Local).AddTicks(6382), 7605.075551269195000m, 1351.900948261230000m }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "FirstName", "LastName", "Password" },
                values: new object[,]
                {
                    { new Guid("171fd338-d1ca-4760-bdb4-7d4775e462fe"), "Lorenzo73@hotmail.com", "Lorenzo", "Greenholt", "kW8p68PhI2" },
                    { new Guid("47cb7ee7-9dac-412d-8a10-b5fb0535b30d"), "Jaime66@gmail.com", "Jaime", "Rice", "x86XTg_yAs" },
                    { new Guid("9e449b67-3b57-4433-a7cd-a9878e278d59"), "Madeline.Bruen@yahoo.com", "Madeline", "Bruen", "mzwWiKBuYE" },
                    { new Guid("9ead0c1a-54d4-416b-925a-546ed44daf24"), "Traci.Russel98@yahoo.com", "Traci", "Russel", "oZWNbnMH1L" },
                    { new Guid("a521d7e3-83db-4c23-8b11-cf8365192946"), "Gustavo.Cole@gmail.com", "Gustavo", "Cole", "mXObJa3E22" }
                });

            migrationBuilder.InsertData(
                table: "PaymentMethods",
                columns: new[] { "Id", "BankAccountId", "CreditCardId", "Type", "UserId" },
                values: new object[,]
                {
                    { new Guid("064fb6df-ffa9-43a4-8121-006e7b93122a"), null, new Guid("0aa6cd06-1437-49fe-9492-844af8960eb9"), "CreditCard", new Guid("a521d7e3-83db-4c23-8b11-cf8365192946") },
                    { new Guid("4c993dc3-76b1-4e28-8123-8b6f178ee26a"), new Guid("f8d5ba05-f933-462e-91b9-b8b53a67f4bd"), null, "BankAccount", new Guid("9ead0c1a-54d4-416b-925a-546ed44daf24") },
                    { new Guid("753962f8-40a5-4195-9738-ea414804ed75"), null, new Guid("b8edcdac-a6d9-41ea-b62d-48f0904f8353"), "CreditCard", new Guid("171fd338-d1ca-4760-bdb4-7d4775e462fe") },
                    { new Guid("aa2138f9-63db-4bf0-9f55-ecc5674909c8"), new Guid("6755bfa3-0918-4304-89c8-2ff90d7c1fe2"), null, "BankAccount", new Guid("171fd338-d1ca-4760-bdb4-7d4775e462fe") },
                    { new Guid("e37c91cc-891b-4561-b452-8b501e447dd5"), null, new Guid("21462c4b-eb60-4a7f-9062-11fe1625c1d5"), "CreditCard", new Guid("171fd338-d1ca-4760-bdb4-7d4775e462fe") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PaymentMethods_BankAccountId",
                table: "PaymentMethods",
                column: "BankAccountId",
                unique: true,
                filter: "[BankAccountId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentMethods_CreditCardId",
                table: "PaymentMethods",
                column: "CreditCardId",
                unique: true,
                filter: "[CreditCardId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentMethods_UserId",
                table: "PaymentMethods",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaymentMethods");

            migrationBuilder.DropTable(
                name: "BankAccounts");

            migrationBuilder.DropTable(
                name: "CreditCards");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
