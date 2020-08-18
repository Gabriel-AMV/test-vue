using Microsoft.EntityFrameworkCore.Migrations;

namespace test_vue.Migrations
{
    public partial class AddedSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TiposPermisos",
                columns: new[] { "Id", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Enfermedad o Lesión" },
                    { 2, "Diligencia" },
                    { 3, "Problema de transporte" },
                    { 4, "Por servicio a jurado" },
                    { 5, "Otros" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TiposPermisos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TiposPermisos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TiposPermisos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TiposPermisos",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TiposPermisos",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
