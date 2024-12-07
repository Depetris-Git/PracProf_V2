using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebITSC.DB.Migrations
{
    /// <inheritdoc />
    public partial class AbreviaturaCarrera : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Abreviatura",
                table: "Carreras",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Abreviatura",
                table: "Carreras");
        }
    }
}
