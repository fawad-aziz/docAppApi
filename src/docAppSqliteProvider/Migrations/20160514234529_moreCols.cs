using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace docAppSqliteProvider.Migrations
{
    public partial class moreCols : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "AppointmentDate",
                table: "AppointmentEntity",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
            migrationBuilder.AddColumn<string>(
                name: "Reason",
                table: "AppointmentEntity",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "AppointmentDate", table: "AppointmentEntity");
            migrationBuilder.DropColumn(name: "Reason", table: "AppointmentEntity");
        }
    }
}
