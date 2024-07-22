using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DabClinicRepo.Migrations
{
    /// <inheritdoc />
    public partial class firstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    email = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    password_hash = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    creation_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    fullname = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    birthdate = table.Column<DateOnly>(type: "date", nullable: true),
                    gender = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    phone = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    role = table.Column<int>(type: "int", nullable: false),
                    active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    removed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Account__3213E83FCE57C7FE", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Clinic",
                columns: table => new
                {
                    clinic_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    address = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    description = table.Column<string>(type: "text", nullable: false, defaultValue: ""),
                    phone = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    email = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    open_hour = table.Column<TimeOnly>(type: "time", nullable: false),
                    close_hour = table.Column<TimeOnly>(type: "time", nullable: false),
                    working = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    clinic_status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Clinic__A0C8D19B1F4BF56A", x => x.clinic_id);
                });

            migrationBuilder.CreateTable(
                name: "ClinicSlot",
                columns: table => new
                {
                    slot_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    max_checkup = table.Column<int>(type: "int", nullable: false),
                    max_treatment = table.Column<int>(type: "int", nullable: false),
                    weekday = table.Column<int>(type: "int", nullable: false),
                    time_id = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    start = table.Column<TimeOnly>(type: "time", nullable: false),
                    end = table.Column<TimeOnly>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ClinicSl__971A01BB0C346FB0", x => x.slot_id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceCategory",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ServiceC__3213E83F667C2AEE", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Appointment",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    appointment_type = table.Column<int>(type: "int", nullable: false),
                    number = table.Column<int>(type: "int", nullable: false),
                    date = table.Column<DateOnly>(type: "date", nullable: false),
                    slot_id = table.Column<int>(type: "int", nullable: false),
                    customer_id = table.Column<int>(type: "int", nullable: false),
                    dentist_id = table.Column<int>(type: "int", nullable: false),
                    cycle_count = table.Column<int>(type: "int", nullable: false),
                    dentist_note = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false, defaultValue: ""),
                    appointment_status = table.Column<int>(type: "int", nullable: false),
                    price_final = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Appointm__3213E83FABC7D14F", x => x.id);
                    table.ForeignKey(
                        name: "FK__Appointme__custo__4316F928",
                        column: x => x.customer_id,
                        principalTable: "Account",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__Appointme__denti__440B1D61",
                        column: x => x.dentist_id,
                        principalTable: "Account",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__Appointme__slot___44FF419A",
                        column: x => x.slot_id,
                        principalTable: "ClinicSlot",
                        principalColumn: "slot_id");
                });

            migrationBuilder.CreateTable(
                name: "ClinicService",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    service_name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    price = table.Column<int>(type: "int", nullable: false),
                    available = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    category_id = table.Column<int>(type: "int", nullable: false),
                    removed = table.Column<bool>(type: "bit", nullable: false),
                    weekday = table.Column<byte>(type: "tinyint", nullable: true, defaultValue: (byte)0),
                    in_slot_treatment = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ClinicSe__3213E83FBA4C9E02", x => x.id);
                    table.ForeignKey(
                        name: "FK__ClinicSer__categ__403A8C7D",
                        column: x => x.category_id,
                        principalTable: "ServiceCategory",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "BookedService",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    appointment_id = table.Column<int>(type: "int", nullable: false),
                    service_id = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__BookedSe__3213E83FE26D8143", x => x.id);
                    table.ForeignKey(
                        name: "FK__BookedSer__appoi__4222D4EF",
                        column: x => x.appointment_id,
                        principalTable: "Appointment",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__BookedSer__servi__412EB0B6",
                        column: x => x.service_id,
                        principalTable: "ClinicService",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "UQ__Account__F3DBC5722D6EF97E",
                table: "Account",
                column: "username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_customer_id",
                table: "Appointment",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_dentist_id",
                table: "Appointment",
                column: "dentist_id");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_slot_id",
                table: "Appointment",
                column: "slot_id");

            migrationBuilder.CreateIndex(
                name: "IX_BookedService_appointment_id",
                table: "BookedService",
                column: "appointment_id");

            migrationBuilder.CreateIndex(
                name: "IX_BookedService_service_id",
                table: "BookedService",
                column: "service_id");

            migrationBuilder.CreateIndex(
                name: "IX_ClinicService_category_id",
                table: "ClinicService",
                column: "category_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookedService");

            migrationBuilder.DropTable(
                name: "Clinic");

            migrationBuilder.DropTable(
                name: "Appointment");

            migrationBuilder.DropTable(
                name: "ClinicService");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "ClinicSlot");

            migrationBuilder.DropTable(
                name: "ServiceCategory");
        }
    }
}
