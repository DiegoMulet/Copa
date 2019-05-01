﻿// <auto-generated />
using System;
using Copa.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Copa.Repository.Migrations
{
    [DbContext(typeof(CopaContext))]
    partial class CopaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity("Copa.Domain.Chave", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataConfronto");

                    b.Property<int?>("QtdGols2");

                    b.Property<int?>("QtqGols1");

                    b.Property<int?>("Selecao1Id");

                    b.Property<int?>("Selecao2Id");

                    b.HasKey("Id");

                    b.HasIndex("Selecao1Id");

                    b.HasIndex("Selecao2Id");

                    b.ToTable("Chaves");
                });

            modelBuilder.Entity("Copa.Domain.Selecao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Eliminada");

                    b.Property<string>("Grupo");

                    b.Property<string>("Pais");

                    b.HasKey("Id");

                    b.ToTable("Selecoes");
                });

            modelBuilder.Entity("Copa.Domain.Chave", b =>
                {
                    b.HasOne("Copa.Domain.Selecao", "Selecao1")
                        .WithMany()
                        .HasForeignKey("Selecao1Id");

                    b.HasOne("Copa.Domain.Selecao", "Selecao2")
                        .WithMany()
                        .HasForeignKey("Selecao2Id");
                });
#pragma warning restore 612, 618
        }
    }
}
