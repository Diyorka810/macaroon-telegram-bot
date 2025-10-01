using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MacaroonBot.Model.Migrations
{
    /// <inheritdoc />
    public partial class AddSurnameToParent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SurName",
                table: "Parents",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SurName",
                table: "Parents");
        }
    }
}
