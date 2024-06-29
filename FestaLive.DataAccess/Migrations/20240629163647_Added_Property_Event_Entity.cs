using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FestaLive.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Added_Property_Event_Entity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AdditionalRequest",
                table: "Tickets",
                newName: "AdditionalRequest");

            migrationBuilder.AddColumn<DateTime>(
                name: "EventDate",
                table: "Events",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EventDate",
                table: "Events");

            migrationBuilder.RenameColumn(
                name: "AdditionalRequest",
                table: "Tickets",
                newName: "PhoneAdditionalRequest");
        }
    }
}
