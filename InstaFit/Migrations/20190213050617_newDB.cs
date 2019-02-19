using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InstaFit.Migrations
{
    public partial class newDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FitnessPosts",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    URL = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FitnessPosts", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "FitnessPosts",
                columns: new[] { "ID", "Description", "Location", "URL" },
                values: new object[,]
                {
                    { 1, "This was an exhausting crossFit Workout, EMOM every minute on the minute 10 burpees 1 power clean @75%", "Seattle Crossfit-321 Denny Way", "crossfit.jpeg" },
                    { 2, "Following the roots of the great Arnold doing these 3 shoulder exercises will get you there!", "Golds Gym-Venice Beach", "Bodybuilding.jpeg" },
                    { 3, "Playing tennis every sunday has kept me lean and mean", "Tennis courts of charleston- charleston SC", "Tennis.jpeg" },
                    { 4, "Starting my new journey into weight loss today- lets battle these heart conditions!!", "Anytime FItness- Oralndo, Fla", "Transformation.jpeg" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FitnessPosts");
        }
    }
}
