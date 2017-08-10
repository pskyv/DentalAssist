using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DentalAssist.Migrations
{
    public partial class ChangePrimaryKeyInDentalOperationTooth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DentalOperationTooth",
                table: "DentalOperationTooth");

            migrationBuilder.AddColumn<int>(
                name: "DentalOperationToothId",
                table: "DentalOperationTooth",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DentalOperationTooth",
                table: "DentalOperationTooth",
                column: "DentalOperationToothId");

            migrationBuilder.CreateIndex(
                name: "IX_DentalOperationTooth_DentalOperationId",
                table: "DentalOperationTooth",
                column: "DentalOperationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DentalOperationTooth",
                table: "DentalOperationTooth");

            migrationBuilder.DropIndex(
                name: "IX_DentalOperationTooth_DentalOperationId",
                table: "DentalOperationTooth");

            migrationBuilder.DropColumn(
                name: "DentalOperationToothId",
                table: "DentalOperationTooth");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DentalOperationTooth",
                table: "DentalOperationTooth",
                columns: new[] { "DentalOperationId", "ToothId" });
        }
    }
}
