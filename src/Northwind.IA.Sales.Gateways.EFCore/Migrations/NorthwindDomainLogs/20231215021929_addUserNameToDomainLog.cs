using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Northwind.IA.Sales.Gateways.EFCore.Migrations.NorthwindDomainLogs
{
    /// <inheritdoc />
    public partial class addUserNameToDomainLog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "DomainLogs",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "DomainLogs");
        }
    }
}
