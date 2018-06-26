﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentEnrollment.Migrations
{
    public partial class changeStudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Students");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Students",
                nullable: false,
                defaultValue: 0);
        }
    }
}
