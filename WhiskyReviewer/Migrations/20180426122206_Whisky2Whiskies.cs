using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WhiskyReviewer.Migrations
{
    public partial class Whisky2Whiskies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Review_Whisky_WhiskyId",
                table: "Review");

            migrationBuilder.DropForeignKey(
                name: "FK_Whisky_Distilleries_DistilleryId",
                table: "Whisky");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Whisky",
                table: "Whisky");

            migrationBuilder.RenameTable(
                name: "Whisky",
                newName: "Whiskies");

            migrationBuilder.RenameIndex(
                name: "IX_Whisky_DistilleryId",
                table: "Whiskies",
                newName: "IX_Whiskies_DistilleryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Whiskies",
                table: "Whiskies",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Whiskies_WhiskyId",
                table: "Review",
                column: "WhiskyId",
                principalTable: "Whiskies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Whiskies_Distilleries_DistilleryId",
                table: "Whiskies",
                column: "DistilleryId",
                principalTable: "Distilleries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Review_Whiskies_WhiskyId",
                table: "Review");

            migrationBuilder.DropForeignKey(
                name: "FK_Whiskies_Distilleries_DistilleryId",
                table: "Whiskies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Whiskies",
                table: "Whiskies");

            migrationBuilder.RenameTable(
                name: "Whiskies",
                newName: "Whisky");

            migrationBuilder.RenameIndex(
                name: "IX_Whiskies_DistilleryId",
                table: "Whisky",
                newName: "IX_Whisky_DistilleryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Whisky",
                table: "Whisky",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Whisky_WhiskyId",
                table: "Review",
                column: "WhiskyId",
                principalTable: "Whisky",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Whisky_Distilleries_DistilleryId",
                table: "Whisky",
                column: "DistilleryId",
                principalTable: "Distilleries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
