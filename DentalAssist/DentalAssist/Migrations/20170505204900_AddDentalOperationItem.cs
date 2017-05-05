using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DentalAssist.Migrations
{
    public partial class AddDentalOperationItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "DentalOperation");

            migrationBuilder.AddColumn<int>(
                name: "DentalOperationItemId",
                table: "DentalOperation",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "DentalOperationItem",
                columns: table => new
                {
                    DentalOperationItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DentalOperationItem", x => x.DentalOperationItemId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DentalOperation_DentalOperationItemId",
                table: "DentalOperation",
                column: "DentalOperationItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_DentalOperation_DentalOperationItem_DentalOperationItemId",
                table: "DentalOperation",
                column: "DentalOperationItemId",
                principalTable: "DentalOperationItem",
                principalColumn: "DentalOperationItemId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DentalOperation_DentalOperationItem_DentalOperationItemId",
                table: "DentalOperation");

            migrationBuilder.DropTable(
                name: "DentalOperationItem");

            migrationBuilder.DropIndex(
                name: "IX_DentalOperation_DentalOperationItemId",
                table: "DentalOperation");

            migrationBuilder.DropColumn(
                name: "DentalOperationItemId",
                table: "DentalOperation");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "DentalOperation",
                nullable: true);
        }
    }
}
