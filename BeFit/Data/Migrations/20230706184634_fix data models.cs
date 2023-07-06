using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeFit.Data.Migrations
{
    public partial class fixdatamodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainingDay_TrainingPlan_TrainingPlanId",
                table: "TrainingDay");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingPlan_AspNetUsers_UserId1",
                table: "TrainingPlan");

            migrationBuilder.DropForeignKey(
                name: "FK_WeightGoal_AspNetUsers_UserId1",
                table: "WeightGoal");

            migrationBuilder.DropForeignKey(
                name: "FK_WeightMeasurement_AspNetUsers_UserId1",
                table: "WeightMeasurement");

            migrationBuilder.DropIndex(
                name: "IX_WeightMeasurement_UserId1",
                table: "WeightMeasurement");

            migrationBuilder.DropIndex(
                name: "IX_WeightGoal_UserId1",
                table: "WeightGoal");

            migrationBuilder.DropIndex(
                name: "IX_TrainingPlan_UserId1",
                table: "TrainingPlan");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "WeightMeasurement");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "WeightGoal");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "TrainingPlan");

            migrationBuilder.AlterColumn<long>(
                name: "NumberOfSets",
                table: "TrainingDayExercise",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "NumberOfRepetitions",
                table: "TrainingDayExercise",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "TrainingPlanId",
                table: "TrainingDay",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdentityUserId = table.Column<int>(type: "int", nullable: false),
                    IdentityUserId1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_AspNetUsers_IdentityUserId1",
                        column: x => x.IdentityUserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c1d078c3-4314-4ac4-be32-4e30b9dde1cd", "AQAAAAEAACcQAAAAEKcAgsM7FqNGt8pMYau7IDceTzPMveWqNIg7c5eerQ+t8GNqy1S0IFcrbVG0NkG9Jw==", "319507e0-df55-49e5-921a-43cc5c330275" });

            migrationBuilder.CreateIndex(
                name: "IX_WeightMeasurement_UserId",
                table: "WeightMeasurement",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WeightGoal_UserId",
                table: "WeightGoal",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingPlan_UserId",
                table: "TrainingPlan",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_User_IdentityUserId1",
                table: "User",
                column: "IdentityUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingDay_TrainingPlan_TrainingPlanId",
                table: "TrainingDay",
                column: "TrainingPlanId",
                principalTable: "TrainingPlan",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingPlan_User_UserId",
                table: "TrainingPlan",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WeightGoal_User_UserId",
                table: "WeightGoal",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WeightMeasurement_User_UserId",
                table: "WeightMeasurement",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainingDay_TrainingPlan_TrainingPlanId",
                table: "TrainingDay");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingPlan_User_UserId",
                table: "TrainingPlan");

            migrationBuilder.DropForeignKey(
                name: "FK_WeightGoal_User_UserId",
                table: "WeightGoal");

            migrationBuilder.DropForeignKey(
                name: "FK_WeightMeasurement_User_UserId",
                table: "WeightMeasurement");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropIndex(
                name: "IX_WeightMeasurement_UserId",
                table: "WeightMeasurement");

            migrationBuilder.DropIndex(
                name: "IX_WeightGoal_UserId",
                table: "WeightGoal");

            migrationBuilder.DropIndex(
                name: "IX_TrainingPlan_UserId",
                table: "TrainingPlan");

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "WeightMeasurement",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "WeightGoal",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "TrainingPlan",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NumberOfSets",
                table: "TrainingDayExercise",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "NumberOfRepetitions",
                table: "TrainingDayExercise",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "TrainingPlanId",
                table: "TrainingDay",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ca56534e-5be7-4857-a1b7-132508e25904", "AQAAAAEAACcQAAAAEOyTQ4gD2t2mXDqAnB1IwPxjbiNr4CGHSGrgqcgNkclV1pVXMWwObswvPs8FVBDPTA==", "e5c3ce05-2e7e-424f-9a7f-951a2182cf6c" });

            migrationBuilder.CreateIndex(
                name: "IX_WeightMeasurement_UserId1",
                table: "WeightMeasurement",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_WeightGoal_UserId1",
                table: "WeightGoal",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingPlan_UserId1",
                table: "TrainingPlan",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingDay_TrainingPlan_TrainingPlanId",
                table: "TrainingDay",
                column: "TrainingPlanId",
                principalTable: "TrainingPlan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingPlan_AspNetUsers_UserId1",
                table: "TrainingPlan",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WeightGoal_AspNetUsers_UserId1",
                table: "WeightGoal",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WeightMeasurement_AspNetUsers_UserId1",
                table: "WeightMeasurement",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
