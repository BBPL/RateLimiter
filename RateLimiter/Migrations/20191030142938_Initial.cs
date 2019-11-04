using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RateLimiter.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TransactionLogs",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ReceivedAt = table.Column<DateTime>(nullable: false),
                    Receiver = table.Column<int>(nullable: false),
                    ServiceName = table.Column<int>(nullable: false),
                    Result = table.Column<int>(nullable: false),
                    RequestData = table.Column<string>(nullable: true),
                    AnswerData = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionLogs", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransactionLogs");
        }
    }
}
