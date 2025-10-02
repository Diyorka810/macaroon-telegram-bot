using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MacaroonBot.Model.Migrations
{
    /// <inheritdoc />
    public partial class AddSurnameToChild : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SurName",
                table: "Children",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SurName",
                table: "Children");
        }
    }
}
