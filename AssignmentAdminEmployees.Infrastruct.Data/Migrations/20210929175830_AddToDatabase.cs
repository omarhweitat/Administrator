using Microsoft.EntityFrameworkCore.Migrations;

namespace AssignmentAdminEmployees.Infrastruct.Data.Migrations
{
    public partial class AddToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DEPARTMENT",
                columns: table => new
                {
                    DEPARTMENT_ID = table.Column<decimal>(type: "numeric", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DEPARTMENT_DESC = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DEPARTMENT", x => x.DEPARTMENT_ID);
                });

            migrationBuilder.CreateTable(
                name: "EMPLOYEES",
                columns: table => new
                {
                    EMPLOYEE_ID = table.Column<decimal>(type: "numeric", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EMPLOYEE_NAME_LANG1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EMPLOYEE_NAME_LANG2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EMAIL_ADDRERSS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WORKING_HOUR_FROM = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WORKING_HOUR_TO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MOBILE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EMPLOYEE_STATUS_ID = table.Column<decimal>(type: "numeric", nullable: false),
                    EMPLOYEE_DEPARTMENT_ID = table.Column<decimal>(type: "numeric", nullable: false),
                    DATETIMEADD = table.Column<decimal>(type: "numeric", nullable: true),
                    DATETIMEMODDEL = table.Column<decimal>(type: "numeric", nullable: true),
                    RECORDSTATUS = table.Column<decimal>(type: "numeric", nullable: false),
                    USER_ADD = table.Column<decimal>(type: "numeric", nullable: true),
                    GENDER_ID = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AGE = table.Column<int>(type: "int", nullable: false),
                    SALARY = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMPLOYEES", x => x.EMPLOYEE_ID);
                });

            migrationBuilder.CreateTable(
                name: "GENDER",
                columns: table => new
                {
                    GENDER_ID = table.Column<decimal>(type: "numeric", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GENDER_DESC = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GENDER", x => x.GENDER_ID);
                });

            migrationBuilder.CreateTable(
                name: "RECOREDSTATUS",
                columns: table => new
                {
                    RECORED_STATUS_ID = table.Column<decimal>(type: "numeric", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RECORED_STATUS_DESC = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RECOREDSTATUS", x => x.RECORED_STATUS_ID);
                });

            migrationBuilder.CreateTable(
                name: "STATUS",
                columns: table => new
                {
                    STATUS_ID = table.Column<decimal>(type: "numeric", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    STATUS_DESC = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STATUS", x => x.STATUS_ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    User_Id = table.Column<decimal>(type: "numeric", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.User_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DEPARTMENT");

            migrationBuilder.DropTable(
                name: "EMPLOYEES");

            migrationBuilder.DropTable(
                name: "GENDER");

            migrationBuilder.DropTable(
                name: "RECOREDSTATUS");

            migrationBuilder.DropTable(
                name: "STATUS");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
