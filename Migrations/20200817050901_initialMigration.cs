using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication2.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "client",
                columns: table => new
                {
                    clientId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    clientName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_client", x => x.clientId);
                });

            migrationBuilder.CreateTable(
                name: "colors",
                columns: table => new
                {
                    colorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    colorName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_colors", x => x.colorId);
                });

            migrationBuilder.CreateTable(
                name: "designers",
                columns: table => new
                {
                    designerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    designerName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_designers", x => x.designerId);
                });

            migrationBuilder.CreateTable(
                name: "designTopology",
                columns: table => new
                {
                    designTopologyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DesignTopologyName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_designTopology", x => x.designTopologyId);
                });

            migrationBuilder.CreateTable(
                name: "sizes",
                columns: table => new
                {
                    sizeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sizeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sizes", x => x.sizeId);
                });

            migrationBuilder.CreateTable(
                name: "surface",
                columns: table => new
                {
                    surfaceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    surfaceName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_surface", x => x.surfaceId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "requests",
                columns: table => new
                {
                    requestId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    requestType = table.Column<string>(nullable: true),
                    classification = table.Column<string>(nullable: true),
                    requestDate = table.Column<string>(nullable: true),
                    designerObservations = table.Column<string>(nullable: true),
                    commercialObservation = table.Column<string>(nullable: true),
                    technical_consideration = table.Column<string>(nullable: true),
                    status = table.Column<string>(nullable: true),
                    image = table.Column<string>(nullable: true),
                    other = table.Column<string>(nullable: true),
                    market = table.Column<string>(nullable: true),
                    suitibility = table.Column<string>(nullable: true),
                    clientId = table.Column<int>(nullable: false),
                    surfaceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_requests", x => x.requestId);
                    table.ForeignKey(
                        name: "FK_requests_client_clientId",
                        column: x => x.clientId,
                        principalTable: "client",
                        principalColumn: "clientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_requests_surface_surfaceId",
                        column: x => x.surfaceId,
                        principalTable: "surface",
                        principalColumn: "surfaceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "designersInvolved",
                columns: table => new
                {
                    designersInvolvedId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DesignerId = table.Column<int>(nullable: false),
                    RequestsrequestId = table.Column<int>(nullable: true),
                    designersInvolvedId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_designersInvolved", x => x.designersInvolvedId);
                    table.ForeignKey(
                        name: "FK_designersInvolved_designers_DesignerId",
                        column: x => x.DesignerId,
                        principalTable: "designers",
                        principalColumn: "designerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_designersInvolved_requests_RequestsrequestId",
                        column: x => x.RequestsrequestId,
                        principalTable: "requests",
                        principalColumn: "requestId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_designersInvolved_designersInvolved_designersInvolvedId1",
                        column: x => x.designersInvolvedId1,
                        principalTable: "designersInvolved",
                        principalColumn: "designersInvolvedId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "requestedModelSpedcifications",
                columns: table => new
                {
                    specificationsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    thickness = table.Column<double>(nullable: false),
                    colorId = table.Column<int>(nullable: false),
                    sizeId = table.Column<int>(nullable: false),
                    DesignTopologyId = table.Column<int>(nullable: false),
                    RequestsrequestId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_requestedModelSpedcifications", x => x.specificationsId);
                    table.ForeignKey(
                        name: "FK_requestedModelSpedcifications_designTopology_DesignTopologyId",
                        column: x => x.DesignTopologyId,
                        principalTable: "designTopology",
                        principalColumn: "designTopologyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_requestedModelSpedcifications_requests_RequestsrequestId",
                        column: x => x.RequestsrequestId,
                        principalTable: "requests",
                        principalColumn: "requestId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_requestedModelSpedcifications_colors_colorId",
                        column: x => x.colorId,
                        principalTable: "colors",
                        principalColumn: "colorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_requestedModelSpedcifications_sizes_sizeId",
                        column: x => x.sizeId,
                        principalTable: "sizes",
                        principalColumn: "sizeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_designersInvolved_DesignerId",
                table: "designersInvolved",
                column: "DesignerId");

            migrationBuilder.CreateIndex(
                name: "IX_designersInvolved_RequestsrequestId",
                table: "designersInvolved",
                column: "RequestsrequestId");

            migrationBuilder.CreateIndex(
                name: "IX_designersInvolved_designersInvolvedId1",
                table: "designersInvolved",
                column: "designersInvolvedId1");

            migrationBuilder.CreateIndex(
                name: "IX_requestedModelSpedcifications_DesignTopologyId",
                table: "requestedModelSpedcifications",
                column: "DesignTopologyId");

            migrationBuilder.CreateIndex(
                name: "IX_requestedModelSpedcifications_RequestsrequestId",
                table: "requestedModelSpedcifications",
                column: "RequestsrequestId");

            migrationBuilder.CreateIndex(
                name: "IX_requestedModelSpedcifications_colorId",
                table: "requestedModelSpedcifications",
                column: "colorId");

            migrationBuilder.CreateIndex(
                name: "IX_requestedModelSpedcifications_sizeId",
                table: "requestedModelSpedcifications",
                column: "sizeId");

            migrationBuilder.CreateIndex(
                name: "IX_requests_clientId",
                table: "requests",
                column: "clientId");

            migrationBuilder.CreateIndex(
                name: "IX_requests_surfaceId",
                table: "requests",
                column: "surfaceId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "designersInvolved");

            migrationBuilder.DropTable(
                name: "requestedModelSpedcifications");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "designers");

            migrationBuilder.DropTable(
                name: "designTopology");

            migrationBuilder.DropTable(
                name: "requests");

            migrationBuilder.DropTable(
                name: "colors");

            migrationBuilder.DropTable(
                name: "sizes");

            migrationBuilder.DropTable(
                name: "client");

            migrationBuilder.DropTable(
                name: "surface");
        }
    }
}
