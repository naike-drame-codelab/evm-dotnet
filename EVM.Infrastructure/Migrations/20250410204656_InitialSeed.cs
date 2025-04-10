using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EVM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "Admin")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Caterings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PricePerPerson = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Caterings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "Client")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "Customer")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Materials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PricePerUnit = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    PricePerHour = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    EventType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Source = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DetailsJson = table.Column<string>(type: "TEXT", nullable: true),
                    ClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventLogs_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.CheckConstraint("CK_Event_Dates", "StartDate < EndDate");
                    table.ForeignKey(
                        name: "FK_Events_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CateringOptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberOfPeople = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EventId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CateringId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CateringOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CateringOptions_Caterings_CateringId",
                        column: x => x.CateringId,
                        principalTable: "Caterings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CateringOptions_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MaterialOptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    MaterialId = table.Column<int>(type: "int", nullable: false),
                    EventId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaterialOptions_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MaterialOptions_Materials_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoomReservations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaymentStatus = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "Pending"),
                    EventId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomReservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomReservations_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomReservations_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QuantityAvailable = table.Column<int>(type: "int", nullable: false),
                    QuantitySold = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    EventId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tickets_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "Email", "Password", "Username" },
                values: new object[] { 1, "admin@evm.net", "1234", "guildmaster" });

            migrationBuilder.InsertData(
                table: "Caterings",
                columns: new[] { "Id", "Name", "PricePerPerson" },
                values: new object[,]
                {
                    { 1, "Standard Package", 25.00m },
                    { 2, "Deluxe Menu", 40.00m },
                    { 3, "Coffee Break", 10.00m }
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Email", "Name", "Password", "PhoneNumber", "Role" },
                values: new object[,]
                {
                    { 1, "info@eventpro.com", "EventPro Corp", "epropass", "123-456-7890", "Client" },
                    { 2, "contact@globalgatherings.net", "Global Gatherings", "ggpass", "987-654-3210", "Client" },
                    { 3, "alice.planner@events.net", "Event Planner Alice", "eventpass", "555-123-4567", "Client" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Email", "Role" },
                values: new object[,]
                {
                    { 1, "alice.smith@example.com", "Customer" },
                    { 2, "bob.johnson@example.com", "Customer" }
                });

            migrationBuilder.InsertData(
                table: "Materials",
                columns: new[] { "Id", "Name", "PricePerUnit" },
                values: new object[,]
                {
                    { 1, "Projector", 30.00m },
                    { 2, "Sound System", 50.00m },
                    { 3, "Flip Chart", 10.00m }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Capacity", "Description", "IsAvailable", "Name", "PricePerHour" },
                values: new object[,]
                {
                    { 1, 200, "Our largest and most elegant space, perfect for weddings, galas, and large conferences. Features high ceilings, a stage, and ample dance floor.", true, "Grand Ballroom", 150.00m },
                    { 2, 50, "A well-equipped conference room ideal for meetings, workshops, and presentations. Includes built-in AV equipment and comfortable seating.", true, "Conference Room A", 75.00m },
                    { 3, 20, "A smaller, more intimate meeting room suitable for team discussions, interviews, and small group sessions. Offers a quiet and focused environment.", true, "Meeting Room 1", 40.00m }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Capacity", "Description", "Name", "PricePerHour" },
                values: new object[] { 4, 30, "A premium suite offering a sophisticated setting for high-level meetings and VIP events. Includes a private lounge area and dedicated amenities.", "Executive Suite", 120.00m });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Capacity", "Description", "IsAvailable", "Name", "PricePerHour" },
                values: new object[] { 5, 60, "A flexible training room that can be configured in various layouts. Equipped with whiteboards and projector screens, perfect for workshops and training sessions.", true, "Training Room B", 85.00m });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "ClientId", "Description", "EndDate", "ImageUrl", "Name", "StartDate", "Type" },
                values: new object[,]
                {
                    { new Guid("a1b2c3d4-e5f6-7890-1234-567890abcdef"), 1, "The premier tech event of the year.", new DateTime(2025, 5, 17, 17, 0, 0, 0, DateTimeKind.Unspecified), null, "Annual Tech Conference", new DateTime(2025, 5, 15, 9, 0, 0, 0, DateTimeKind.Unspecified), "Conference" },
                    { new Guid("fedcba98-7654-3210-fedc-ba9876543210"), 2, "Hands-on workshop for marketing professionals.", new DateTime(2025, 6, 10, 16, 30, 0, 0, DateTimeKind.Unspecified), null, "Marketing Workshop", new DateTime(2025, 6, 10, 9, 30, 0, 0, DateTimeKind.Unspecified), "Corporate" }
                });

            migrationBuilder.InsertData(
                table: "CateringOptions",
                columns: new[] { "Id", "CateringId", "EventId", "NumberOfPeople", "TotalPrice" },
                values: new object[,]
                {
                    { 1, 2, new Guid("a1b2c3d4-e5f6-7890-1234-567890abcdef"), 150, 0m },
                    { 2, 3, new Guid("fedcba98-7654-3210-fedc-ba9876543210"), 40, 0m }
                });

            migrationBuilder.InsertData(
                table: "MaterialOptions",
                columns: new[] { "Id", "EventId", "MaterialId", "Quantity" },
                values: new object[,]
                {
                    { 1, new Guid("a1b2c3d4-e5f6-7890-1234-567890abcdef"), 1, 2 },
                    { 2, new Guid("fedcba98-7654-3210-fedc-ba9876543210"), 3, 1 }
                });

            migrationBuilder.InsertData(
                table: "RoomReservations",
                columns: new[] { "Id", "EventId", "PaymentStatus", "RoomId" },
                values: new object[] { new Guid("01234567-89ab-cdef-0123-456789abcdef"), new Guid("a1b2c3d4-e5f6-7890-1234-567890abcdef"), "Completed", 1 });

            migrationBuilder.InsertData(
                table: "RoomReservations",
                columns: new[] { "Id", "EventId", "RoomId" },
                values: new object[] { new Guid("98765432-10fe-dcba-9876-543210fedcba"), new Guid("fedcba98-7654-3210-fedc-ba9876543210"), 2 });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "CustomerId", "EventId", "Price", "QuantityAvailable", "QuantitySold", "Type" },
                values: new object[,]
                {
                    { new Guid("689f906c-446a-4b85-a266-dc2591c15482"), 2, new Guid("fedcba98-7654-3210-fedc-ba9876543210"), 50.00m, 0, 1, "VIP" },
                    { new Guid("ea81fc53-c9be-43ce-9446-989068a647a7"), 1, new Guid("a1b2c3d4-e5f6-7890-1234-567890abcdef"), 100.00m, 0, 2, "Regular" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CateringOptions_CateringId",
                table: "CateringOptions",
                column: "CateringId");

            migrationBuilder.CreateIndex(
                name: "IX_CateringOptions_EventId_CateringId",
                table: "CateringOptions",
                columns: new[] { "EventId", "CateringId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EventLogs_ClientId",
                table: "EventLogs",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_ClientId",
                table: "Events",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialOptions_EventId_MaterialId",
                table: "MaterialOptions",
                columns: new[] { "EventId", "MaterialId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MaterialOptions_MaterialId",
                table: "MaterialOptions",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomReservations_EventId_RoomId",
                table: "RoomReservations",
                columns: new[] { "EventId", "RoomId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoomReservations_RoomId",
                table: "RoomReservations",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_CustomerId",
                table: "Tickets",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_EventId_CustomerId",
                table: "Tickets",
                columns: new[] { "EventId", "CustomerId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "CateringOptions");

            migrationBuilder.DropTable(
                name: "EventLogs");

            migrationBuilder.DropTable(
                name: "MaterialOptions");

            migrationBuilder.DropTable(
                name: "RoomReservations");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Caterings");

            migrationBuilder.DropTable(
                name: "Materials");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
