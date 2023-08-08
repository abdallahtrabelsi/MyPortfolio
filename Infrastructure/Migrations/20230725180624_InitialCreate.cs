using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "portfolioItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    ProjectName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_portfolioItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Owner",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Profil = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    adressId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owner", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Owner_Address_adressId",
                        column: x => x.adressId,
                        principalTable: "Address",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Owner",
                columns: new[] { "Id", "Avatar", "FullName", "Profil", "adressId" },
                values: new object[] { new Guid("9fef470a-7e0d-44a6-8cd5-546025898488"), "avatare.jpg", "abdallahtrabelsi", "micro mvp /.net consulting", null });

            migrationBuilder.CreateIndex(
                name: "IX_Owner_adressId",
                table: "Owner",
                column: "adressId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Owner");

            migrationBuilder.DropTable(
                name: "portfolioItems");

            migrationBuilder.DropTable(
                name: "Address");
        }
    }
}
