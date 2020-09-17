using Microsoft.EntityFrameworkCore.Migrations;

namespace CS.Core.Migrations
{
    public partial class Update_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Owners_Cars_CarId",
                table: "Owners");

            migrationBuilder.DropIndex(
                name: "IX_Owners_CarId",
                table: "Owners");

            migrationBuilder.DropColumn(
                name: "CarId",
                table: "Owners");

            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.CreateIndex(
                name: "IX_OwnerRepairs_OwnerId",
                table: "OwnerRepairs",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_OwnerRepairs_RepairId",
                table: "OwnerRepairs",
                column: "RepairId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_OwnerId",
                table: "Cars",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Owners_OwnerId",
                table: "Cars",
                column: "OwnerId",
                principalTable: "Owners",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_OwnerRepairs_Owners_OwnerId",
                table: "OwnerRepairs",
                column: "OwnerId",
                principalTable: "Owners",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_OwnerRepairs_Repairs_RepairId",
                table: "OwnerRepairs",
                column: "RepairId",
                principalTable: "Repairs",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Owners_OwnerId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_OwnerRepairs_Owners_OwnerId",
                table: "OwnerRepairs");

            migrationBuilder.DropForeignKey(
                name: "FK_OwnerRepairs_Repairs_RepairId",
                table: "OwnerRepairs");

            migrationBuilder.DropIndex(
                name: "IX_OwnerRepairs_OwnerId",
                table: "OwnerRepairs");

            migrationBuilder.DropIndex(
                name: "IX_OwnerRepairs_RepairId",
                table: "OwnerRepairs");

            migrationBuilder.DropIndex(
                name: "IX_Cars_OwnerId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Cars");

            migrationBuilder.AddColumn<int>(
                name: "CarId",
                table: "Owners",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Owners_CarId",
                table: "Owners",
                column: "CarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Owners_Cars_CarId",
                table: "Owners",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
