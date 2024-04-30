using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistense.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Books",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Description", "Title", "Year" },
                values: new object[,]
                {
                    { 1, "This is the first novel by Jane Austen", "Sense and Sensibility", 1811 },
                    { 2, "This is a novel of manners", "Pride and Prejudice", 1813 },
                    { 3, "The novel tells the story of Fanny Price, starting when her overburnered family sends her at the age of tento live in the household of her wealthy aunt and uncle.", "Mansfield Park", 1814 },
                    { 4, "This is a novel of manners.", "Emma", 1816 },
                    { 5, "This is a coming-of-age novel and a satire of Gothic novels.", "Northanger Abbey", 1818 },
                    { 6, "The story concerns Anne Elliot, an Englishwoman of 27 years, whose family moves to lower their home to an admiral and his wife.", "Persuasion", 1818 },
                    { 7, "This is an epistolary novella.", "Lady Susan", 1871 }
                });

            migrationBuilder.InsertData(
                table: "FemaleCharacters",
                columns: new[] { "Id", "BookId", "Characteristic", "Name" },
                values: new object[,]
                {
                    { 1, 1, "The sensible and reserved eldest daughter of Mr and Mrs Henry Dashwood.", "Elinor Dashwood" },
                    { 2, 1, "The romantically inclined and eagerly expressive second daughter of Mr and Mrs Henry Dashwood.", "Marianne Dashwood" },
                    { 3, 1, "the youngest daughter of Mr and Mrs Henry Dashwood.", "Margaret Dashwood" }
                });

            migrationBuilder.InsertData(
                table: "MaleCharacters",
                columns: new[] { "Id", "BookId", "Characteristic", "Name" },
                values: new object[,]
                {
                    { 1, 1, "The elder of Fanny Dashwood's two brothers.", "Edward Ferras" },
                    { 2, 1, "A philandering nephew of a neighbour of the Middletons.", "John Willoughby" },
                    { 3, 1, "a close friend of Sir John Middleton.", "Colonel Brandon" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "FemaleCharacters",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FemaleCharacters",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FemaleCharacters",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MaleCharacters",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MaleCharacters",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MaleCharacters",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Books",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(40)",
                oldMaxLength: 40);
        }
    }
}
