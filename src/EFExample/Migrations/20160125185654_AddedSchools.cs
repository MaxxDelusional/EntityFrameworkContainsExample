using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Metadata;

namespace EFExample.Migrations
{
    public partial class AddedSchools : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Student_Teacher_TeacherID", table: "Student");
            migrationBuilder.CreateTable(
                name: "School",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_School", x => x.ID);
                });
            migrationBuilder.AddColumn<long>(
                name: "SchoolID",
                table: "Teacher",
                nullable: false,
                defaultValue: 0L);
            migrationBuilder.AddForeignKey(
                name: "FK_Student_Teacher_TeacherID",
                table: "Student",
                column: "TeacherID",
                principalTable: "Teacher",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_Teacher_School_SchoolID",
                table: "Teacher",
                column: "SchoolID",
                principalTable: "School",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Student_Teacher_TeacherID", table: "Student");
            migrationBuilder.DropForeignKey(name: "FK_Teacher_School_SchoolID", table: "Teacher");
            migrationBuilder.DropColumn(name: "SchoolID", table: "Teacher");
            migrationBuilder.DropTable("School");
            migrationBuilder.AddForeignKey(
                name: "FK_Student_Teacher_TeacherID",
                table: "Student",
                column: "TeacherID",
                principalTable: "Teacher",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
