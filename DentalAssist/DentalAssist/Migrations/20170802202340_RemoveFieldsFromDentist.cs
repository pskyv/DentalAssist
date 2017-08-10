using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DentalAssist.Migrations
{
    public partial class RemoveFieldsFromDentist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Dentist");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Dentist");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Dentist",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Dentist",
                nullable: true);
        }
    }
}
