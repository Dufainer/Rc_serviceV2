using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rc_serviceV2.Migrations
{
    public partial class Mrigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo_Estado = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Logeo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Usuario = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Contraseña = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logeo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Propietarios",
                columns: table => new
                {
                    Id_Propietario = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Name_Propietario = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Lastname_Propietario = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Celular = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Email = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Ubicacion_Id = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Propieta__7360E97DC02ECF4F", x => x.Id_Propietario);
                });

            migrationBuilder.CreateTable(
                name: "Servicios",
                columns: table => new
                {
                    Id_Servicio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo_Servicio = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Detalles_Servicio = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Servicio__5B1345F056719A2D", x => x.Id_Servicio);
                });

            migrationBuilder.CreateTable(
                name: "Inmuebles",
                columns: table => new
                {
                    Id_Inmueble = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo_Inmueble = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Detalles_Inmueble = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Ubicacion_Id = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    Propietarios_Id_Propietario = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Inmueble__DB51280D52C0DB2F", x => x.Id_Inmueble);
                    table.ForeignKey(
                        name: "FK__Inmuebles__Propi__3B75D760",
                        column: x => x.Propietarios_Id_Propietario,
                        principalTable: "Propietarios",
                        principalColumn: "Id_Propietario");
                });

            migrationBuilder.CreateTable(
                name: "Prestadores_de_servicios",
                columns: table => new
                {
                    Id_Prestador = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Name_Prestador = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Lastname_Prestador = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Celular = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Email = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Ubicacion_Id = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    Servicios_Id_Servicio = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Prestado__25950CC513D8503B", x => x.Id_Prestador);
                    table.ForeignKey(
                        name: "FK__Prestador__Servi__403A8C7D",
                        column: x => x.Servicios_Id_Servicio,
                        principalTable: "Servicios",
                        principalColumn: "Id_Servicio");
                });

            migrationBuilder.CreateTable(
                name: "Ofertas",
                columns: table => new
                {
                    Id_Ofertas = table.Column<int>(type: "int", nullable: false),
                    Inmuebles_Id_Inmueble = table.Column<int>(type: "int", nullable: true),
                    Servicios_Id_Servicio = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Ofertas__C41D869B515051DE", x => x.Id_Ofertas);
                    table.ForeignKey(
                        name: "FK__Ofertas__Inmuebl__4316F928",
                        column: x => x.Inmuebles_Id_Inmueble,
                        principalTable: "Inmuebles",
                        principalColumn: "Id_Inmueble");
                    table.ForeignKey(
                        name: "FK__Ofertas__Servici__440B1D61",
                        column: x => x.Servicios_Id_Servicio,
                        principalTable: "Servicios",
                        principalColumn: "Id_Servicio");
                });

            migrationBuilder.CreateTable(
                name: "Contratacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ofertas_Id_Ofertas = table.Column<int>(type: "int", nullable: true),
                    Estados_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contratacion", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Contratac__Estad__49C3F6B7",
                        column: x => x.Estados_Id,
                        principalTable: "Estados",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Contratac__Ofert__48CFD27E",
                        column: x => x.Ofertas_Id_Ofertas,
                        principalTable: "Ofertas",
                        principalColumn: "Id_Ofertas");
                });
            migrationBuilder.CreateTable(
               name: "AspNetRoles",
               columns: table => new
               {
                   Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                   Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                   NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                   ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_AspNetRoles", x => x.Id);
               });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "IX_Contratacion_Estados_Id",
                table: "Contratacion",
                column: "Estados_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Contratacion_Ofertas_Id_Ofertas",
                table: "Contratacion",
                column: "Ofertas_Id_Ofertas");

            migrationBuilder.CreateIndex(
                name: "IX_Inmuebles_Propietarios_Id_Propietario",
                table: "Inmuebles",
                column: "Propietarios_Id_Propietario");

            migrationBuilder.CreateIndex(
                name: "IX_Ofertas_Inmuebles_Id_Inmueble",
                table: "Ofertas",
                column: "Inmuebles_Id_Inmueble");

            migrationBuilder.CreateIndex(
                name: "IX_Ofertas_Servicios_Id_Servicio",
                table: "Ofertas",
                column: "Servicios_Id_Servicio");

            migrationBuilder.CreateIndex(
                name: "IX_Prestadores_de_servicios_Servicios_Id_Servicio",
                table: "Prestadores_de_servicios",
                column: "Servicios_Id_Servicio");
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
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Contratacion");

            migrationBuilder.DropTable(
                name: "Logeo");

            migrationBuilder.DropTable(
                name: "Prestadores_de_servicios");

            migrationBuilder.DropTable(
                name: "Estados");

            migrationBuilder.DropTable(
                name: "Ofertas");

            migrationBuilder.DropTable(
                name: "Inmuebles");

            migrationBuilder.DropTable(
                name: "Servicios");

            migrationBuilder.DropTable(
                name: "Propietarios");
        }
    }
}
