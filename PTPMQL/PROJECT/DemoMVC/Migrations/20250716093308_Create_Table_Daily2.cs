using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoMVC.Migrations
{
    /// <inheritdoc />
    public partial class Create_Table_Daily2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DaiLy_HeThongPhanPhoi_MaHTPP",
                table: "DaiLy");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HeThongPhanPhoi",
                table: "HeThongPhanPhoi");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DaiLy",
                table: "DaiLy");

            migrationBuilder.RenameTable(
                name: "HeThongPhanPhoi",
                newName: "HeThongPhanPhois");

            migrationBuilder.RenameTable(
                name: "DaiLy",
                newName: "DaiLies");

            migrationBuilder.RenameIndex(
                name: "IX_DaiLy_MaHTPP",
                table: "DaiLies",
                newName: "IX_DaiLies_MaHTPP");

            migrationBuilder.AlterColumn<string>(
                name: "MaHTPP",
                table: "DaiLies",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HeThongPhanPhois",
                table: "HeThongPhanPhois",
                column: "MaHTPP");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DaiLies",
                table: "DaiLies",
                column: "MaDaiLy");

            migrationBuilder.AddForeignKey(
                name: "FK_DaiLies_HeThongPhanPhois_MaHTPP",
                table: "DaiLies",
                column: "MaHTPP",
                principalTable: "HeThongPhanPhois",
                principalColumn: "MaHTPP");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DaiLies_HeThongPhanPhois_MaHTPP",
                table: "DaiLies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HeThongPhanPhois",
                table: "HeThongPhanPhois");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DaiLies",
                table: "DaiLies");

            migrationBuilder.RenameTable(
                name: "HeThongPhanPhois",
                newName: "HeThongPhanPhoi");

            migrationBuilder.RenameTable(
                name: "DaiLies",
                newName: "DaiLy");

            migrationBuilder.RenameIndex(
                name: "IX_DaiLies_MaHTPP",
                table: "DaiLy",
                newName: "IX_DaiLy_MaHTPP");

            migrationBuilder.AlterColumn<string>(
                name: "MaHTPP",
                table: "DaiLy",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_HeThongPhanPhoi",
                table: "HeThongPhanPhoi",
                column: "MaHTPP");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DaiLy",
                table: "DaiLy",
                column: "MaDaiLy");

            migrationBuilder.AddForeignKey(
                name: "FK_DaiLy_HeThongPhanPhoi_MaHTPP",
                table: "DaiLy",
                column: "MaHTPP",
                principalTable: "HeThongPhanPhoi",
                principalColumn: "MaHTPP",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
