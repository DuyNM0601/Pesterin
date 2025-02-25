using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pesterin.Infrastructure.Migrations
{
    public partial class AddCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Arts_Accounts_AccountId",
                table: "Arts");

            migrationBuilder.AlterColumn<Guid>(
                name: "AccountId",
                table: "Arts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "Arts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Arts_CategoryId",
                table: "Arts",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Arts_Accounts_AccountId",
                table: "Arts",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Arts_Category_CategoryId",
                table: "Arts",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Arts_Accounts_AccountId",
                table: "Arts");

            migrationBuilder.DropForeignKey(
                name: "FK_Arts_Category_CategoryId",
                table: "Arts");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Arts_CategoryId",
                table: "Arts");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Arts");

            migrationBuilder.AlterColumn<Guid>(
                name: "AccountId",
                table: "Arts",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Arts_Accounts_AccountId",
                table: "Arts",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id");
        }
    }
}
