using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MacaroonBot.Model.Migrations
{
    /// <inheritdoc />
    public partial class AddActivitiesDbSet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Activity_ActivityId",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_ParentChild_Children_ChildId",
                table: "ParentChild");

            migrationBuilder.DropForeignKey(
                name: "FK_ParentChild_Parents_ParentId",
                table: "ParentChild");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Activity_ActivityId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Activity_ActivityId",
                table: "Schedules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ParentChild",
                table: "ParentChild");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Activity",
                table: "Activity");

            migrationBuilder.RenameTable(
                name: "ParentChild",
                newName: "ParentChildren");

            migrationBuilder.RenameTable(
                name: "Activity",
                newName: "Activities");

            migrationBuilder.RenameIndex(
                name: "IX_ParentChild_ChildId",
                table: "ParentChildren",
                newName: "IX_ParentChildren_ChildId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ParentChildren",
                table: "ParentChildren",
                columns: new[] { "ParentId", "ChildId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Activities",
                table: "Activities",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Activities_ActivityId",
                table: "Groups",
                column: "ActivityId",
                principalTable: "Activities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ParentChildren_Children_ChildId",
                table: "ParentChildren",
                column: "ChildId",
                principalTable: "Children",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ParentChildren_Parents_ParentId",
                table: "ParentChildren",
                column: "ParentId",
                principalTable: "Parents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Activities_ActivityId",
                table: "Payments",
                column: "ActivityId",
                principalTable: "Activities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Activities_ActivityId",
                table: "Schedules",
                column: "ActivityId",
                principalTable: "Activities",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Activities_ActivityId",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_ParentChildren_Children_ChildId",
                table: "ParentChildren");

            migrationBuilder.DropForeignKey(
                name: "FK_ParentChildren_Parents_ParentId",
                table: "ParentChildren");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Activities_ActivityId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Activities_ActivityId",
                table: "Schedules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ParentChildren",
                table: "ParentChildren");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Activities",
                table: "Activities");

            migrationBuilder.RenameTable(
                name: "ParentChildren",
                newName: "ParentChild");

            migrationBuilder.RenameTable(
                name: "Activities",
                newName: "Activity");

            migrationBuilder.RenameIndex(
                name: "IX_ParentChildren_ChildId",
                table: "ParentChild",
                newName: "IX_ParentChild_ChildId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ParentChild",
                table: "ParentChild",
                columns: new[] { "ParentId", "ChildId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Activity",
                table: "Activity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Activity_ActivityId",
                table: "Groups",
                column: "ActivityId",
                principalTable: "Activity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ParentChild_Children_ChildId",
                table: "ParentChild",
                column: "ChildId",
                principalTable: "Children",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ParentChild_Parents_ParentId",
                table: "ParentChild",
                column: "ParentId",
                principalTable: "Parents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Activity_ActivityId",
                table: "Payments",
                column: "ActivityId",
                principalTable: "Activity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Activity_ActivityId",
                table: "Schedules",
                column: "ActivityId",
                principalTable: "Activity",
                principalColumn: "Id");
        }
    }
}
