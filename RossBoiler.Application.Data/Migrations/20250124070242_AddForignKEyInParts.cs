using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RossBoiler.Application.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddForignKEyInParts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UnitID",
                table: "Units",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "PackingID",
                table: "Packings",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "HsnID",
                table: "HSNs",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "GSTs",
                newName: "ID");

            migrationBuilder.AlterColumn<int>(
                name: "PackingId",
                table: "Parts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Parts_GSTId",
                table: "Parts",
                column: "GSTId");

            migrationBuilder.CreateIndex(
                name: "IX_Parts_HSNDetailsId",
                table: "Parts",
                column: "HSNDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_Parts_PackingId",
                table: "Parts",
                column: "PackingId");

            migrationBuilder.CreateIndex(
                name: "IX_Parts_UnitId",
                table: "Parts",
                column: "UnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Parts_GSTs_GSTId",
                table: "Parts",
                column: "GSTId",
                principalTable: "GSTs",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Parts_HSNs_HSNDetailsId",
                table: "Parts",
                column: "HSNDetailsId",
                principalTable: "HSNs",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Parts_Packings_PackingId",
                table: "Parts",
                column: "PackingId",
                principalTable: "Packings",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Parts_Units_UnitId",
                table: "Parts",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parts_GSTs_GSTId",
                table: "Parts");

            migrationBuilder.DropForeignKey(
                name: "FK_Parts_HSNs_HSNDetailsId",
                table: "Parts");

            migrationBuilder.DropForeignKey(
                name: "FK_Parts_Packings_PackingId",
                table: "Parts");

            migrationBuilder.DropForeignKey(
                name: "FK_Parts_Units_UnitId",
                table: "Parts");

            migrationBuilder.DropIndex(
                name: "IX_Parts_GSTId",
                table: "Parts");

            migrationBuilder.DropIndex(
                name: "IX_Parts_HSNDetailsId",
                table: "Parts");

            migrationBuilder.DropIndex(
                name: "IX_Parts_PackingId",
                table: "Parts");

            migrationBuilder.DropIndex(
                name: "IX_Parts_UnitId",
                table: "Parts");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Units",
                newName: "UnitID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Packings",
                newName: "PackingID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "HSNs",
                newName: "HsnID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "GSTs",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "PackingId",
                table: "Parts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
