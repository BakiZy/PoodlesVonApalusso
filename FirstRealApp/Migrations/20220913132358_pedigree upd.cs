using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FirstRealApp.Migrations
{
    public partial class pedigreeupd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Name", "PedigreeUrl", "Url" },
                values: new object[,]
                {
                    { 1, "Don", "https://i.imgur.com/buICnwV.png", "https://i.imgur.com/xOseBFm.jpeg" },
                    { 2, "Ruza", "https://i.imgur.com/5wGPffP.png", "https://i.imgur.com/6Ll5PQL.jpeg" },
                    { 3, "Luna", "https://i.imgur.com/1HvFBCZ.png", "https://i.imgur.com/QnE8Brd.jpeg" },
                    { 4, "Sosa", "https://i.imgur.com/FFnFmyy.png", "https://i.imgur.com/nuBvd3X.jpeg" },
                    { 5, "Dolly", "https://i.imgur.com/YHBaAPu.png", "https://i.imgur.com/t2q0Put.jpeg" },
                    { 6, "Cici", "https://i.imgur.com/P5ZegtI.png", "https://i.imgur.com/dWBkNFR.jpeg" }
                });

            migrationBuilder.InsertData(
                table: "Poodles",
                columns: new[] { "Id", "DateOfBirth", "GeneticTests", "ImageId", "Name", "PedigreeNumber", "PoodleColorId", "PoodleSizeId" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 1, "Toy Love Story Don Juan", "JR 70883", 6, 2 },
                    { 2, new DateTime(2020, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 2, "Scarlet Rain  Von Apalusso", "JR 70883", 6, 1 },
                    { 3, new DateTime(2017, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 3, "Loko Loko Crveni Mayestoso", "JR 70883", 7, 1 },
                    { 4, new DateTime(2020, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 4, "Skyler Von Apalusso", "JR 70883", 6, 2 },
                    { 5, new DateTime(2018, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 5, "Greta Garbo Von Apalusso", "JR 70883", 5, 2 },
                    { 6, new DateTime(2020, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 6, "Cici", "JR 81231", 5, 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Poodles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Poodles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Poodles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Poodles",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Poodles",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Poodles",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
