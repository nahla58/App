﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mig4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activites",
                columns: table => new
                {
                    ActiviteId = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Ville = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Pays = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Prix = table.Column<double>(type: "float", nullable: false),
                    TypeService = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    zone_Ville = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    zone_Pays = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activites", x => x.ActiviteId);
                });

            migrationBuilder.CreateTable(
                name: "Conseillers",
                columns: table => new
                {
                    ConseillerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Prenom = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conseillers", x => x.ConseillerId);
                });

            migrationBuilder.CreateTable(
                name: "Packs",
                columns: table => new
                {
                    PackId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IntitulePack = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    NbPlaces = table.Column<int>(type: "int", nullable: false),
                    DateDebut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duree = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packs", x => x.PackId);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Identifiant = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    MotDePasse = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    ConseillerFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Identifiant);
                    table.ForeignKey(
                        name: "FK_Clients_Conseillers_ConseillerFk",
                        column: x => x.ConseillerFk,
                        principalTable: "Conseillers",
                        principalColumn: "ConseillerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActivitePack",
                columns: table => new
                {
                    ActivitesActiviteId = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    PacksPackId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivitePack", x => new { x.ActivitesActiviteId, x.PacksPackId });
                    table.ForeignKey(
                        name: "FK_ActivitePack_Activites_ActivitesActiviteId",
                        column: x => x.ActivitesActiviteId,
                        principalTable: "Activites",
                        principalColumn: "ActiviteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivitePack_Packs_PacksPackId",
                        column: x => x.PacksPackId,
                        principalTable: "Packs",
                        principalColumn: "PackId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    IdClient = table.Column<int>(type: "int", nullable: false),
                    IdPack = table.Column<int>(type: "int", nullable: false),
                    DateReservation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NbPersonnes = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => new { x.IdClient, x.IdPack });
                    table.ForeignKey(
                        name: "FK_Reservations_Clients_IdClient",
                        column: x => x.IdClient,
                        principalTable: "Clients",
                        principalColumn: "Identifiant",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_Packs_IdPack",
                        column: x => x.IdPack,
                        principalTable: "Packs",
                        principalColumn: "PackId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActivitePack_PacksPackId",
                table: "ActivitePack",
                column: "PacksPackId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_ConseillerFk",
                table: "Clients",
                column: "ConseillerFk");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_IdPack",
                table: "Reservations",
                column: "IdPack");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivitePack");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Activites");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Packs");

            migrationBuilder.DropTable(
                name: "Conseillers");
        }
    }
}
