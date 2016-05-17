using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace docAppSqliteProvider.Migrations
{
    public partial class newcols : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "EstablishedPatient",
                table: "AppointmentEntity",
                nullable: false,
                defaultValue: false);
            migrationBuilder.AddColumn<string>(
                name: "InsuranceOption",
                table: "AppointmentEntity",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "EstablishedPatient", table: "AppointmentEntity");
            migrationBuilder.DropColumn(name: "InsuranceOption", table: "AppointmentEntity");
        }
    }
}
