using Microsoft.EntityFrameworkCore.Migrations;

namespace MoviesRental.Migrations
{
    public partial class AddMemberShips : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                "insert into MemberShips (Id,Fee,Name,DurationInMonths,DiscountInProcent) values (1,0,'Free Plan',0,0)");
            migrationBuilder.Sql("insert into MemberShips (Id,Fee,Name,DurationInMonths,DiscountInProcent) values (2,100,'Two Months Plan',1,10)");
            migrationBuilder.Sql("insert into MemberShips (Id,Fee,Name,DurationInMonths,DiscountInProcent) values (3,400,'Six Months Plan',6,25)");
            migrationBuilder.Sql("insert into MemberShips (Id,Fee,Name,DurationInMonths,DiscountInProcent) values (4,650,'Annual Plan',12,30)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
