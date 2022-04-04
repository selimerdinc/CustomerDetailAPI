using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerDetailAPI.Migrations
{
    /// <inheritdoc />
    public partial class CreateInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "customersdb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<double>(type: "float", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isEnabled = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customersdb", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "customersdb");
        }
    }
}
