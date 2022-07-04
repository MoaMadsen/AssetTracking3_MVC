using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssetTracking3_MVC.Data.Migrations
{
    public partial class AddingAssetCategoryOfficeTables2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assetitems_Categories_CategoryId1",
                table: "Assetitems");

            migrationBuilder.DropForeignKey(
                name: "FK_Assetitems_Offices_OfficeId1",
                table: "Assetitems");

            migrationBuilder.DropIndex(
                name: "IX_Assetitems_CategoryId1",
                table: "Assetitems");

            migrationBuilder.DropIndex(
                name: "IX_Assetitems_OfficeId1",
                table: "Assetitems");

            migrationBuilder.DropColumn(
                name: "CategoryId1",
                table: "Assetitems");

            migrationBuilder.DropColumn(
                name: "OfficeId1",
                table: "Assetitems");

            migrationBuilder.AlterColumn<int>(
                name: "OfficeId",
                table: "Assetitems",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Assetitems",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Assetitems_CategoryId",
                table: "Assetitems",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Assetitems_OfficeId",
                table: "Assetitems",
                column: "OfficeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assetitems_Categories_CategoryId",
                table: "Assetitems",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Assetitems_Offices_OfficeId",
                table: "Assetitems",
                column: "OfficeId",
                principalTable: "Offices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assetitems_Categories_CategoryId",
                table: "Assetitems");

            migrationBuilder.DropForeignKey(
                name: "FK_Assetitems_Offices_OfficeId",
                table: "Assetitems");

            migrationBuilder.DropIndex(
                name: "IX_Assetitems_CategoryId",
                table: "Assetitems");

            migrationBuilder.DropIndex(
                name: "IX_Assetitems_OfficeId",
                table: "Assetitems");

            migrationBuilder.AlterColumn<string>(
                name: "OfficeId",
                table: "Assetitems",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "CategoryId",
                table: "Assetitems",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId1",
                table: "Assetitems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OfficeId1",
                table: "Assetitems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Assetitems_CategoryId1",
                table: "Assetitems",
                column: "CategoryId1");

            migrationBuilder.CreateIndex(
                name: "IX_Assetitems_OfficeId1",
                table: "Assetitems",
                column: "OfficeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Assetitems_Categories_CategoryId1",
                table: "Assetitems",
                column: "CategoryId1",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Assetitems_Offices_OfficeId1",
                table: "Assetitems",
                column: "OfficeId1",
                principalTable: "Offices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
