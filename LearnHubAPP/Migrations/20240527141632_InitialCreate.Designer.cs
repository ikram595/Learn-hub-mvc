﻿// <auto-generated />
using System;
using LearnHubAPP.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LearnHubAPP.Migrations
{
    [DbContext(typeof(LearnHubDbContext))]
    [Migration("20240527141632_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.29")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("LearnHubAPP.Models.Categorie", b =>
                {
                    b.Property<int>("IdCategorie")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCategorie"), 1L, 1);

                    b.Property<string>("DescriptionCat")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomCategorie")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdCategorie");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            IdCategorie = 1,
                            DescriptionCat = "catégorie de formation axée sur l'apprentissage de la science des données et de l'analyse de données.",
                            NomCategorie = "Data Science"
                        },
                        new
                        {
                            IdCategorie = 2,
                            DescriptionCat = "catégorie de formation axée sur la sécurité informatique et la protection des systèmes informatiques.",
                            NomCategorie = "Cybersécurité"
                        });
                });

            modelBuilder.Entity("LearnHubAPP.Models.Formateur", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Biographie")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<DateTime>("DateNaissance")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumTel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Formateurs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Biographie = "professeur à l'université de nantes et formateur en data science depuis 2010",
                            DateNaissance = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "john.doe@example.com",
                            Nom = "john",
                            Prenom = "doe"
                        },
                        new
                        {
                            Id = 2,
                            Biographie = "expert en cybersécurité.",
                            DateNaissance = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "jane.smith@example.com",
                            Nom = "jane",
                            Prenom = "smith"
                        });
                });

            modelBuilder.Entity("LearnHubAPP.Models.Formation", b =>
                {
                    b.Property<int>("IdFormation")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdFormation"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Duree")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdCategorie")
                        .HasColumnType("int");

                    b.Property<int>("IdFormateur")
                        .HasColumnType("int");

                    b.Property<string>("ImgFormationPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomFormation")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<float>("Prix")
                        .HasColumnType("real");

                    b.HasKey("IdFormation");

                    b.HasIndex("IdCategorie");

                    b.HasIndex("IdFormateur");

                    b.ToTable("Formations");

                    b.HasData(
                        new
                        {
                            IdFormation = 1,
                            Description = "formation avancée en data science",
                            Duree = "3 mois",
                            IdCategorie = 1,
                            IdFormateur = 1,
                            ImgFormationPath = "dddd",
                            NomFormation = "Formation en data science avancée",
                            Prix = 1000f
                        },
                        new
                        {
                            IdFormation = 2,
                            Description = "formation professionnelle en cybersécurité",
                            Duree = "2 mois",
                            IdCategorie = 2,
                            IdFormateur = 2,
                            ImgFormationPath = "gggg",
                            NomFormation = "Formation en cybersécurité professionnelle",
                            Prix = 800f
                        });
                });

            modelBuilder.Entity("LearnHubAPP.Models.Module", b =>
                {
                    b.Property<int>("IdModule")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdModule"), 1L, 1);

                    b.Property<string>("DescriptionMod")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdFormation")
                        .HasColumnType("int");

                    b.Property<string>("NomModule")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdModule");

                    b.HasIndex("IdFormation");

                    b.ToTable("Modules");

                    b.HasData(
                        new
                        {
                            IdModule = 1,
                            DescriptionMod = "Ce module couvre les bases de la data science, y compris les statistiques, le traitement des données et la visualisation.",
                            IdFormation = 1,
                            NomModule = "Introduction à la Data Science"
                        },
                        new
                        {
                            IdModule = 2,
                            DescriptionMod = "Les étudiants exploreront les concepts avancés du machine learning et leur application pratique.",
                            IdFormation = 1,
                            NomModule = "Machine Learning"
                        },
                        new
                        {
                            IdModule = 3,
                            DescriptionMod = "Ce module se concentre sur les technologies et les techniques de gestion des grands volumes de données.",
                            IdFormation = 1,
                            NomModule = "Big Data"
                        },
                        new
                        {
                            IdModule = 4,
                            DescriptionMod = "Dans ce module, les étudiants apprendront les principes fondamentaux de la sécurité des réseaux et des systèmes d'information.",
                            IdFormation = 2,
                            NomModule = "Sécurité des Réseaux"
                        },
                        new
                        {
                            IdModule = 5,
                            DescriptionMod = "Ce module aborde les techniques de cryptage et de protection des données.",
                            IdFormation = 2,
                            NomModule = "Cryptographie"
                        },
                        new
                        {
                            IdModule = 6,
                            DescriptionMod = "Les étudiants étudieront les stratégies de gestion des risques et de réponse aux incidents de sécurité.",
                            IdFormation = 2,
                            NomModule = "Gestion des Risques en Cybersécurité"
                        });
                });

            modelBuilder.Entity("LearnHubAPP.Models.Formation", b =>
                {
                    b.HasOne("LearnHubAPP.Models.Categorie", "Categorie")
                        .WithMany("Formations")
                        .HasForeignKey("IdCategorie")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LearnHubAPP.Models.Formateur", "Formateur")
                        .WithMany("Formations")
                        .HasForeignKey("IdFormateur")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categorie");

                    b.Navigation("Formateur");
                });

            modelBuilder.Entity("LearnHubAPP.Models.Module", b =>
                {
                    b.HasOne("LearnHubAPP.Models.Formation", "Formation")
                        .WithMany("Modules")
                        .HasForeignKey("IdFormation")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Formation");
                });

            modelBuilder.Entity("LearnHubAPP.Models.Categorie", b =>
                {
                    b.Navigation("Formations");
                });

            modelBuilder.Entity("LearnHubAPP.Models.Formateur", b =>
                {
                    b.Navigation("Formations");
                });

            modelBuilder.Entity("LearnHubAPP.Models.Formation", b =>
                {
                    b.Navigation("Modules");
                });
#pragma warning restore 612, 618
        }
    }
}
