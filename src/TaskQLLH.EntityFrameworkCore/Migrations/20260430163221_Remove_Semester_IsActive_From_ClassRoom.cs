using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskQLLH.Migrations
{
    /// <inheritdoc />
    public partial class Remove_Semester_IsActive_From_ClassRoom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "ClassRooms");

            migrationBuilder.DropColumn(
                name: "Semester",
                table: "ClassRooms");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "ClassRooms",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Semester",
                table: "ClassRooms",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
