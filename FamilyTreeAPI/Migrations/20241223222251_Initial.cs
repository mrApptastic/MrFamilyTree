using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FamilyTreeAPI.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FamilyTreeBranches",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Enabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Public = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyTreeBranches", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FamilyTreeUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyTreeUsers", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FamilyTreeArticles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Enabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Public = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Text = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BranchId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyTreeArticles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FamilyTreeArticles_FamilyTreeBranches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "FamilyTreeBranches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FamilyTreeKeywords",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Enabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Public = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BranchId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyTreeKeywords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FamilyTreeKeywords_FamilyTreeBranches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "FamilyTreeBranches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FamilyTreePlaces",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Enabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Public = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Altitude = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    Latitude = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    Longitude = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    BranchId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyTreePlaces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FamilyTreePlaces_FamilyTreeBranches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "FamilyTreeBranches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FamilyTreeBranchUsers",
                columns: table => new
                {
                    BranchId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyTreeBranchUsers", x => new { x.BranchId, x.UserId });
                    table.ForeignKey(
                        name: "FK_FamilyTreeBranchUsers_FamilyTreeBranches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "FamilyTreeBranches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FamilyTreeBranchUsers_FamilyTreeUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "FamilyTreeUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FamilyTreeImages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Enabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Public = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Url = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BranchId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    PlaceId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyTreeImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FamilyTreeImages_FamilyTreeBranches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "FamilyTreeBranches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FamilyTreeImages_FamilyTreePlaces_PlaceId",
                        column: x => x.PlaceId,
                        principalTable: "FamilyTreePlaces",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FamilyTreeImageKeywords",
                columns: table => new
                {
                    ImageId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    KeywordId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyTreeImageKeywords", x => new { x.ImageId, x.KeywordId });
                    table.ForeignKey(
                        name: "FK_FamilyTreeImageKeywords_FamilyTreeImages_ImageId",
                        column: x => x.ImageId,
                        principalTable: "FamilyTreeImages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FamilyTreeImageKeywords_FamilyTreeKeywords_KeywordId",
                        column: x => x.KeywordId,
                        principalTable: "FamilyTreeKeywords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FamilyTreePersons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Enabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Public = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    FirstNames = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: true),
                    DateOfDeath = table.Column<DateOnly>(type: "date", nullable: true),
                    PlaceOfBirthId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    MotherId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    FatherId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    BirthName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Notes = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsFemale = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AvatarId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    BranchId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyTreePersons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FamilyTreePersons_FamilyTreeBranches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "FamilyTreeBranches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FamilyTreePersons_FamilyTreeImages_AvatarId",
                        column: x => x.AvatarId,
                        principalTable: "FamilyTreeImages",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FamilyTreePersons_FamilyTreePersons_FatherId",
                        column: x => x.FatherId,
                        principalTable: "FamilyTreePersons",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FamilyTreePersons_FamilyTreePersons_MotherId",
                        column: x => x.MotherId,
                        principalTable: "FamilyTreePersons",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FamilyTreePersons_FamilyTreePlaces_PlaceOfBirthId",
                        column: x => x.PlaceOfBirthId,
                        principalTable: "FamilyTreePlaces",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FamilyTreeArticlePersons",
                columns: table => new
                {
                    ArticleId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    PersonId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyTreeArticlePersons", x => new { x.ArticleId, x.PersonId });
                    table.ForeignKey(
                        name: "FK_FamilyTreeArticlePersons_FamilyTreeArticles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "FamilyTreeArticles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FamilyTreeArticlePersons_FamilyTreePersons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "FamilyTreePersons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyTreeArticlePersons_PersonId",
                table: "FamilyTreeArticlePersons",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyTreeArticles_BranchId",
                table: "FamilyTreeArticles",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyTreeBranchUsers_UserId",
                table: "FamilyTreeBranchUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyTreeImageKeywords_KeywordId",
                table: "FamilyTreeImageKeywords",
                column: "KeywordId");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyTreeImages_BranchId",
                table: "FamilyTreeImages",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyTreeImages_PlaceId",
                table: "FamilyTreeImages",
                column: "PlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyTreeKeywords_BranchId",
                table: "FamilyTreeKeywords",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyTreePersons_AvatarId",
                table: "FamilyTreePersons",
                column: "AvatarId");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyTreePersons_BranchId",
                table: "FamilyTreePersons",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyTreePersons_FatherId",
                table: "FamilyTreePersons",
                column: "FatherId");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyTreePersons_MotherId",
                table: "FamilyTreePersons",
                column: "MotherId");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyTreePersons_PlaceOfBirthId",
                table: "FamilyTreePersons",
                column: "PlaceOfBirthId");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyTreePlaces_BranchId",
                table: "FamilyTreePlaces",
                column: "BranchId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FamilyTreeArticlePersons");

            migrationBuilder.DropTable(
                name: "FamilyTreeBranchUsers");

            migrationBuilder.DropTable(
                name: "FamilyTreeImageKeywords");

            migrationBuilder.DropTable(
                name: "FamilyTreeArticles");

            migrationBuilder.DropTable(
                name: "FamilyTreePersons");

            migrationBuilder.DropTable(
                name: "FamilyTreeUsers");

            migrationBuilder.DropTable(
                name: "FamilyTreeKeywords");

            migrationBuilder.DropTable(
                name: "FamilyTreeImages");

            migrationBuilder.DropTable(
                name: "FamilyTreePlaces");

            migrationBuilder.DropTable(
                name: "FamilyTreeBranches");
        }
    }
}
