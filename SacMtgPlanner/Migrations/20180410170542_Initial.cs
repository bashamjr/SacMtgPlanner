using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SacMtgPlanner.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Meeting",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CloseHymn = table.Column<string>(nullable: true),
                    ClosePrayer = table.Column<string>(nullable: true),
                    Conducting = table.Column<string>(nullable: true),
                    FirstSpeaker = table.Column<string>(nullable: true),
                    OpenHymn = table.Column<string>(nullable: true),
                    OpenPrayer = table.Column<string>(nullable: true),
                    ReleaseDate = table.Column<DateTime>(nullable: false),
                    SacHymn = table.Column<string>(nullable: true),
                    SecondSpeaker = table.Column<string>(nullable: true),
                    Subject = table.Column<string>(nullable: true),
                    YouthSpeaker = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meeting", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Meeting");
        }
    }
}
