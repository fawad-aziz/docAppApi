using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace docAppSqliteProvider.Migrations
{
    public partial class morecol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppointmentTime",
                table: "AppointmentEntity",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "AppointmentEntity",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "AppointmentTime", table: "AppointmentEntity");
            migrationBuilder.DropColumn(name: "Gender", table: "AppointmentEntity");
        }
    }
}
