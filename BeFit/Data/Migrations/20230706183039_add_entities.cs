using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeFit.Data.Migrations
{
    public partial class add_entities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Exercise",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InstructionalVideoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercise", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrainingPlan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserId1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingPlan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingPlan_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "WeightGoal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Weight = table.Column<float>(type: "real", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserId1 = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeightGoal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeightGoal_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WeightMeasurement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateTaken = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Measurement = table.Column<float>(type: "real", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserId1 = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeightMeasurement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeightMeasurement_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrainingDay",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DayOfTheWeek = table.Column<int>(type: "int", nullable: false),
                    TrainingPlanId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingDay", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingDay_TrainingPlan_TrainingPlanId",
                        column: x => x.TrainingPlanId,
                        principalTable: "TrainingPlan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrainingDayExercise",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberOfSets = table.Column<int>(type: "int", nullable: false),
                    NumberOfRepetitions = table.Column<int>(type: "int", nullable: false),
                    TrainingDayId = table.Column<int>(type: "int", nullable: false),
                    ExerciseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingDayExercise", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingDayExercise_Exercise_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercise",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrainingDayExercise_TrainingDay_TrainingDayId",
                        column: x => x.TrainingDayId,
                        principalTable: "TrainingDay",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ca56534e-5be7-4857-a1b7-132508e25904", "AQAAAAEAACcQAAAAEOyTQ4gD2t2mXDqAnB1IwPxjbiNr4CGHSGrgqcgNkclV1pVXMWwObswvPs8FVBDPTA==", "e5c3ce05-2e7e-424f-9a7f-951a2182cf6c" });

            migrationBuilder.CreateIndex(
                name: "IX_TrainingDay_TrainingPlanId",
                table: "TrainingDay",
                column: "TrainingPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingDayExercise_ExerciseId",
                table: "TrainingDayExercise",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingDayExercise_TrainingDayId",
                table: "TrainingDayExercise",
                column: "TrainingDayId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingPlan_UserId1",
                table: "TrainingPlan",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_WeightGoal_UserId1",
                table: "WeightGoal",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_WeightMeasurement_UserId1",
                table: "WeightMeasurement",
                column: "UserId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrainingDayExercise");

            migrationBuilder.DropTable(
                name: "WeightGoal");

            migrationBuilder.DropTable(
                name: "WeightMeasurement");

            migrationBuilder.DropTable(
                name: "Exercise");

            migrationBuilder.DropTable(
                name: "TrainingDay");

            migrationBuilder.DropTable(
                name: "TrainingPlan");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "52e43f74-3c24-4836-a392-6ace8f939947", "AQAAAAEAACcQAAAAEHjy6MNRpqD5tS96rxtDGlsuzLFIgW9MnrUgRo4YhkkV8vLS8pk6LzTcTck2n82RfQ==", "af53a12b-404a-44cc-8af6-d92c869bd492" });
        }
    }
}
