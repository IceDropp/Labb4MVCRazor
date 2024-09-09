using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Labb4MVCRazor.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublicationYear = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Loans",
                columns: table => new
                {
                    LoanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    LoanDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Returned = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loans", x => x.LoanId);
                    table.ForeignKey(
                        name: "FK_Loans_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Loans_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "Author", "PublicationYear", "Title" },
                values: new object[,]
                {
                    { 1, "J.R.R. Tolkien", 1937, "The Hobbit" },
                    { 2, "George R.R. Martin", 1996, "A Game of Thrones" },
                    { 3, "Patrick Rothfuss", 2007, "The Name of the Wind" },
                    { 4, "Brandon Sanderson", 2006, "Mistborn: The Final Empire" },
                    { 5, "Scott Lynch", 2006, "The Lies of Locke Lamora" }

                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Email", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "moggewestin@hotmail.com", "Morgan Westin", "07564321" },
                    { 2, "Jan_C@gmail.com", "Jan Carlsson", "08549731" },
                    { 3, "alexBentzon@gmail.com", "Alex Begntzon", "04567785" },
                    { 4, "JhoanF@hotmail.com", "Johan Fredriksson", "03215786" },
                    { 5, "Frida.aronsson@gmail.com", "Frisa Aronsson", "04567891" }

                });

            migrationBuilder.InsertData(
                table: "Loans",
                columns: new[] { "LoanId", "BookId", "CustomerId", "LoanDate", "ReturnDate", "Returned" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2024, 09, 02, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { 2, 2, 2, new DateTime(2024, 09, 01, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { 3, 3, 3, new DateTime(2024, 09, 07, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), false },
                    { 4, 4, 4, new DateTime(2024, 09, 09, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { 5, 5, 5, new DateTime(2024, 09, 04, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), true }

                });

            migrationBuilder.CreateIndex(
                name: "IX_Loans_BookId",
                table: "Loans",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_CustomerId",
                table: "Loans",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Loans");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
