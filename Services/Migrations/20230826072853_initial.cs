using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Services.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Staffs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staffs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StaffEmoloyees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StaffId = table.Column<Guid>(type: "uuid", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffEmoloyees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StaffEmoloyees_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StaffEmoloyees_Staffs_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staffs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Address", "Email", "Name", "Phone" },
                values: new object[,]
                {
                    { new Guid("5d76e748-011f-4cb6-bc8d-2423b06bb696"), "Toshkent", "...", "Kohinur", "+998938853616" },
                    { new Guid("ab950de1-34ef-4e87-8111-fef59e38e467"), "Toshkent", "...", "Najot ta`lim", "+998999999999" }
                });

            migrationBuilder.InsertData(
                table: "Staffs",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0f30f95b-6ee6-4822-8fed-f53a4084383e"), "O`quv bo`limi" },
                    { new Guid("eea4ff91-2222-4e5f-a0e0-d5a2348d9efe"), "Moliya bo`limi" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "CompanyId", "Email", "FirstName", "LastName", "Phone" },
                values: new object[,]
                {
                    { new Guid("b1af9ed4-7cb5-47af-963e-5ce381403e00"), new Guid("5d76e748-011f-4cb6-bc8d-2423b06bb696"), "Sev@gmail.com", "Sevinch", "Xayriddinova", "+998939613663" },
                    { new Guid("ffb9a741-99b1-4e9e-a44f-5d0b111dbc37"), new Guid("ab950de1-34ef-4e87-8111-fef59e38e467"), "Sadaf@gmail.com", "Sadaf", "Karimova", "+998994027833" }
                });

            migrationBuilder.InsertData(
                table: "StaffEmoloyees",
                columns: new[] { "Id", "EmployeeId", "StaffId" },
                values: new object[,]
                {
                    { new Guid("7838b104-32d2-47ba-b02b-3871cd03cafa"), new Guid("ffb9a741-99b1-4e9e-a44f-5d0b111dbc37"), new Guid("0f30f95b-6ee6-4822-8fed-f53a4084383e") },
                    { new Guid("a9fa9ff6-fb96-488e-a8c1-9a59767a7706"), new Guid("b1af9ed4-7cb5-47af-963e-5ce381403e00"), new Guid("0f30f95b-6ee6-4822-8fed-f53a4084383e") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CompanyId",
                table: "Employees",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffEmoloyees_EmployeeId",
                table: "StaffEmoloyees",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffEmoloyees_StaffId",
                table: "StaffEmoloyees",
                column: "StaffId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StaffEmoloyees");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Staffs");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
