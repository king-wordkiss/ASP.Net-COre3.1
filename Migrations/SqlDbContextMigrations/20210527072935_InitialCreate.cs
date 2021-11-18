using Microsoft.EntityFrameworkCore.Migrations;

namespace AspNetCore3._1Student.Migrations.SqlDbContextMigrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    ClassName = table.Column<int>(type: "int", nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentNo = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "ID", "Adress", "ClassName", "Name", "StudentNo" },
                values: new object[] { 2, "南昌市", 0, "张三", "200101" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "ID", "Adress", "ClassName", "Name", "StudentNo" },
                values: new object[] { 3, "解放路", 0, "李四", "200102" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "ID", "Adress", "ClassName", "Name", "StudentNo" },
                values: new object[] { 4, "中山路", 0, "王五", "200103" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
