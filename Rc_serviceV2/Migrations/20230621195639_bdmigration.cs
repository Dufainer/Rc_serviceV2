using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rc_serviceV2.Migrations
{
    public partial class bdmigration : Migration
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
