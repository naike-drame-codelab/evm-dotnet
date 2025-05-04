using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EVM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateClientTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Email", "Name", "Password", "PhoneNumber", "Role", "Salt" },
                values: new object[,]
                {
                    { 4, "john@xyz.net", "XYZ Corporation", "�8�y��^ͪ>�Ǒ\"��-�������X�5����\\��)\0d%�Wy*��e��QU���|o", "585-123-4567", "Client", new Guid("92ac876f-ee41-47dd-9c8b-ca0d38ba3974") },
                    { 5, "emily@ejplanner.org", "Emily Johnson", "x3�xտ��}��B	}��%�i�e��ߓ�	��ؐ��e��Q���=@P�X��/�O���<O}�y", "585-123-4567", "Client", new Guid("e3b55037-3257-421d-9c8c-8276e6a0bca0") },
                    { 6, "mchen@tech.net", "Tech Innovations LLC", "�����A��?U���a�\n��\0@S�l	O�a>=S0=�����w�\\��)M�=��A5���	��", "585-123-4567", "Client", new Guid("cfe18d0e-3dbb-4bb7-a940-0941bdea2d6d") },
                    { 7, "mchen@tech.net", "Media Inc.", "�/�/��5�!��o��K��\rp�K�ʆi)�N^�*���r�o����:�st�=~:3�u\n�", "585-123-4567", "Client", new Guid("252dab5a-4508-4750-932e-c558b5bb03ca") },
                    { 8, "mchen@tech.net", "Global Finance Group", "��o��=v�_�����Fy��d��H�\nr 3)�!���E~���1�n\\��;�.�9΀�Ne<�g", "585-123-4567", "Client", new Guid("cced3ada-98ea-4cb6-b18c-085cceca338c") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 8);
        }
    }
}
