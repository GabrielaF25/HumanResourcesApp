﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HumanResourcesApp.Migrations
{
    [DbContext(typeof(HRDbContext))]
    [Migration("20241112112947_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.10");

            modelBuilder.Entity("Angajat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataAngajarii")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nume")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("Pozitie")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Prenume")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Angajati");
                });

            modelBuilder.Entity("CerereConcediu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AngajatId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataInceput")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataSfarsit")
                        .HasColumnType("TEXT");

                    b.Property<string>("Motiv")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AngajatId");

                    b.ToTable("CereriConcediu");
                });

            modelBuilder.Entity("Document", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AngajatId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataIncarcare")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nume")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<string>("TipDocument")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AngajatId");

                    b.ToTable("Documente");
                });

            modelBuilder.Entity("Evaluare", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AngajatId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Comentariu")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataEvaluare")
                        .HasColumnType("TEXT");

                    b.Property<int>("Scor")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("AngajatId");

                    b.ToTable("Evaluari");
                });

            modelBuilder.Entity("CerereConcediu", b =>
                {
                    b.HasOne("Angajat", "Angajat")
                        .WithMany("CereriConcediu")
                        .HasForeignKey("AngajatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Angajat");
                });

            modelBuilder.Entity("Document", b =>
                {
                    b.HasOne("Angajat", "Angajat")
                        .WithMany("Documente")
                        .HasForeignKey("AngajatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Angajat");
                });

            modelBuilder.Entity("Evaluare", b =>
                {
                    b.HasOne("Angajat", "Angajat")
                        .WithMany("Evaluari")
                        .HasForeignKey("AngajatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Angajat");
                });

            modelBuilder.Entity("Angajat", b =>
                {
                    b.Navigation("CereriConcediu");

                    b.Navigation("Documente");

                    b.Navigation("Evaluari");
                });
#pragma warning restore 612, 618
        }
    }
}
