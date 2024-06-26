﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Pokemon.Infrastructure.Data;

#nullable disable

namespace Pokemon.Infrastructure.Migrations
{
    [DbContext(typeof(PokemonDbContext))]
    partial class PokemonDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Pokemon.Core.Entities.General.EvoTree", b =>
                {
                    b.Property<string>("PokemonName")
                        .HasMaxLength(32)
                        .HasColumnType("character varying(32)");

                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<int>("Level")
                        .HasColumnType("integer");

                    b.HasKey("PokemonName");

                    b.ToTable("EvoTrees");
                });

            modelBuilder.Entity("Pokemon.Core.Entities.General.Pokemon", b =>
                {
                    b.Property<string>("Name")
                        .HasMaxLength(32)
                        .HasColumnType("character varying(32)");

                    b.Property<int>("Atk")
                        .HasColumnType("integer");

                    b.Property<int>("Def")
                        .HasColumnType("integer");

                    b.Property<int>("EvoTreeId")
                        .HasColumnType("integer");

                    b.Property<int>("Height")
                        .HasColumnType("integer");

                    b.Property<int>("Hp")
                        .HasColumnType("integer");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("TEXT");

                    b.Property<int>("Sa")
                        .HasColumnType("integer");

                    b.Property<int>("Sd")
                        .HasColumnType("integer");

                    b.Property<int>("Spd")
                        .HasColumnType("integer");

                    b.Property<int>("Weight")
                        .HasColumnType("integer");

                    b.HasKey("Name");

                    b.ToTable("Pokemons");
                });

            modelBuilder.Entity("Pokemon.Core.Entities.General.PokemonType", b =>
                {
                    b.Property<string>("PokemonName")
                        .HasColumnType("character varying(32)");

                    b.Property<int>("TypeId")
                        .HasColumnType("integer");

                    b.HasKey("PokemonName", "TypeId");

                    b.HasIndex("TypeId");

                    b.ToTable("PokemonTypes");
                });

            modelBuilder.Entity("Pokemon.Core.Entities.General.Type", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("character varying(32)");

                    b.HasKey("Id");

                    b.ToTable("Types");
                });

            modelBuilder.Entity("Pokemon.Core.Entities.General.EvoTree", b =>
                {
                    b.HasOne("Pokemon.Core.Entities.General.Pokemon", "Pokemon")
                        .WithOne("EvoTree")
                        .HasForeignKey("Pokemon.Core.Entities.General.EvoTree", "PokemonName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pokemon");
                });

            modelBuilder.Entity("Pokemon.Core.Entities.General.PokemonType", b =>
                {
                    b.HasOne("Pokemon.Core.Entities.General.Pokemon", "Pokemon")
                        .WithMany("PokemonTypes")
                        .HasForeignKey("PokemonName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pokemon.Core.Entities.General.Type", "Type")
                        .WithMany("PokemonTypes")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pokemon");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("Pokemon.Core.Entities.General.Pokemon", b =>
                {
                    b.Navigation("EvoTree");

                    b.Navigation("PokemonTypes");
                });

            modelBuilder.Entity("Pokemon.Core.Entities.General.Type", b =>
                {
                    b.Navigation("PokemonTypes");
                });
#pragma warning restore 612, 618
        }
    }
}
