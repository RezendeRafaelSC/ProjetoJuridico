using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JuridicoProjeto.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isAdvogado",
                table: "Advogados");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isAdvogado",
                table: "Advogados",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
