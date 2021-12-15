using Microsoft.EntityFrameworkCore.Migrations;

namespace MoviesRental.Migrations
{
    public partial class AddGenres : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into Genres(Id,GenreName) values (1,'Horror')");
            migrationBuilder.Sql("insert into Genres(Id,GenreName) values (2,'Action')");
            migrationBuilder.Sql("insert into Genres(Id,GenreName) values (3,'Comedy')");
            migrationBuilder.Sql("insert into Genres(Id,GenreName) values (4,'Drama')");
            migrationBuilder.Sql("insert into Genres(Id,GenreName) values (5,'Mystery')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
