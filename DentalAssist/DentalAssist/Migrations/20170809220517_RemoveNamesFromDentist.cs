using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DentalAssist.Migrations
{
    public partial class RemoveNamesFromDentist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Dentist");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Dentist");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Dentist",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Dentist",
                nullable: true);
        }
    }
}
