using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreApps.DAL.Migrations
{
    public partial class AddedAnotations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "Users",
                newName: "TimeStamp");

            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "Tasks",
                newName: "TimeStamp");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Tasks",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Tasks",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Task_Name",
                table: "Tasks",
                columns: new[] { "Name", "Description" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Task_Name",
                table: "Tasks");

            migrationBuilder.RenameColumn(
                name: "TimeStamp",
                table: "Users",
                newName: "DateTime");

            migrationBuilder.RenameColumn(
                name: "TimeStamp",
                table: "Tasks",
                newName: "DateTime");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Tasks",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Tasks",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300);
        }
    }
}
