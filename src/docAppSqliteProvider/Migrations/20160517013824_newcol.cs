using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace docAppSqliteProvider.Migrations
{
    public partial class newcol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContactNumber",
                table: "AppointmentEntity",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "ContactNumber", table: "AppointmentEntity");
        }
    }
}
