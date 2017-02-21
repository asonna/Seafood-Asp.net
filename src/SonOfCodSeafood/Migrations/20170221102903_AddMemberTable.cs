using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SonOfCodSeafood.Migrations
{
    public partial class AddMemberTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Members",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Members",
                nullable: false);

            migrationBuilder.RenameColumn(
                name: "phone",
                table: "Members",
                newName: "Phone");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "Members");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Members",
                nullable: true);

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Members",
                newName: "phone");
        }
    }
}
