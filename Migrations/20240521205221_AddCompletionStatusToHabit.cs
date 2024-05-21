using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HabitifyBackend.Migrations
{
    /// <inheritdoc />
    public partial class AddCompletionStatusToHabit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCompleteDaily",
                table: "Habits",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsCompleteWeekly",
                table: "Habits",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCompleteDaily",
                table: "Habits");

            migrationBuilder.DropColumn(
                name: "IsCompleteWeekly",
                table: "Habits");
        }
    }
}
