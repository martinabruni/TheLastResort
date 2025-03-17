using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheLastResort.Core.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _20250317_RenamedNavigationProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BuildingEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    BuildingType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Building__3214EC07013ABE50", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LogEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__LogEntit__3214EC073328503B", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    UserName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__UserEnti__3214EC074A1766AB", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApartmentEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ManagerPhone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Apartmen__3214EC077D46E4EA", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApartmentEntity_BuildingEntity",
                        column: x => x.Id,
                        principalTable: "BuildingEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HotelEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__HotelEnt__3214EC07296D956C", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HotelEntity_BuildingEntity",
                        column: x => x.Id,
                        principalTable: "BuildingEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReservationEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BuildingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReservationType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    Cancelled = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    CancelledDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Reservat__3214EC07F9E6A04E", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReservationEntity_BuildingEntity",
                        column: x => x.BuildingId,
                        principalTable: "BuildingEntity",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ReservationEntity_UserEntity",
                        column: x => x.UserId,
                        principalTable: "UserEntity",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IDX_ReservationEntity_StartDate",
                table: "ReservationEntity",
                column: "StartDate");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationEntity_BuildingId",
                table: "ReservationEntity",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationEntity_UserId",
                table: "ReservationEntity",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "UQ_UserEntity_Email",
                table: "UserEntity",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApartmentEntity");

            migrationBuilder.DropTable(
                name: "HotelEntity");

            migrationBuilder.DropTable(
                name: "LogEntity");

            migrationBuilder.DropTable(
                name: "ReservationEntity");

            migrationBuilder.DropTable(
                name: "BuildingEntity");

            migrationBuilder.DropTable(
                name: "UserEntity");
        }
    }
}
