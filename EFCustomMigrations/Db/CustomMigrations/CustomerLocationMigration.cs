using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

// Refer to Migrations Namespace, otherwise EF will put the new migrations it generates in this folder
namespace EFCustomMigrations.Db.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("CustomMigration_CustomerLocation")]
    public class CustomerLocationMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerLocation",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerLocation", x => x.ID);
                });

            migrationBuilder.Sql("ALTER TABLE CustomerLocation " +
                                 "ADD GeogCol1 geography, " +
                                 "GeogCol2 AS GeogCol1.STAsText()");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // TODO: Implemnent this how you see fit
            base.Down(migrationBuilder);
        }
    }
}
